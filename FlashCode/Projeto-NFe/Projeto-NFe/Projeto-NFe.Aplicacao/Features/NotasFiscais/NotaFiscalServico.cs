using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using Projeto_NFe.Dominio.Features.ProdutosNFe;

namespace Projeto_NFe.Aplicacao.Features.NotasFiscais
{
    public class NotaFiscalServico : INotaFiscalServico
    {
        INotaFiscalRepositorio _notaFiscalRepositorio;
        INotaFiscalExportacao _notaFiscalExportacaoXML;
        INotaFiscalExportacao _notaFiscalExportacaoPDF;
        IEnderecoRepositorio _enderecoRepositorio;
        IEmitenteRepositorio _emitenteRepositorio;
        IDestinatarioRepositorio _destinatarioRepositorio;
        ITransportadorRepositorio _transportadorRepositorio;
        IProdutoNFeRepositorio _produtoNfeRepositorio;
        Random _random;

        public NotaFiscalServico(
            INotaFiscalRepositorio nfRepositorio, INotaFiscalExportacao nfExportacaoXML,
            INotaFiscalExportacao nfExportacaoPDF, IEnderecoRepositorio enderecoRepositorio,
            IEmitenteRepositorio emitenteRepositorio, IDestinatarioRepositorio destinatarioRepositorio,
            ITransportadorRepositorio transportadorRepositorio, IProdutoNFeRepositorio produtonfe, Random random)
        {
            _notaFiscalRepositorio = nfRepositorio;
            _notaFiscalExportacaoXML = nfExportacaoXML;
            _notaFiscalExportacaoPDF = nfExportacaoPDF;
            _enderecoRepositorio = enderecoRepositorio;
            _emitenteRepositorio = emitenteRepositorio;
            _destinatarioRepositorio = destinatarioRepositorio;
            _transportadorRepositorio = transportadorRepositorio;
            _produtoNfeRepositorio = produtonfe;
            _random = random;
        }

        public NotaFiscal Atualizar(NotaFiscal notaFiscal)
        {
            if (notaFiscal.ID < 1)
                throw new ExcecaoIdentificadorInvalido();

            notaFiscal.Validar();

            return _notaFiscalRepositorio.Atualizar(notaFiscal);
        }

        public bool Deletar(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var produtoNfe = _produtoNfeRepositorio.DeletarPorNotaFiscalID(id);

            if (produtoNfe == false)
                return false;

            return _notaFiscalRepositorio.Deletar(id);
        }

        public bool EmitirNota(NotaFiscal notaFiscal)
        {
            notaFiscal.CalcularValorTotalNota();

            bool notaEncontrada;

            do
            {
                notaFiscal.GerarChave(_random);

                notaEncontrada = _notaFiscalRepositorio.ValidarExistenciaPorChave(notaFiscal.Chave);

            } while (notaEncontrada);

            notaFiscal.Validar();

            _notaFiscalRepositorio.InserirNotaFiscalEmitida(notaFiscal);

            var notaDeletada = this.Deletar(notaFiscal.ID);

            return notaDeletada;
        }

        public void ExportarNota(NotaFiscal notaFiscal)
        {
            var nota = _notaFiscalRepositorio.ObterPorChave(notaFiscal.Chave);

            _notaFiscalExportacaoXML.Exportar(nota);
            _notaFiscalExportacaoPDF.Exportar(nota);
        }

        public NotaFiscal Inserir(NotaFiscal notaFiscal)
        {
            notaFiscal.Validar();
            var nota = _notaFiscalRepositorio.Inserir(notaFiscal);
            var produtosNfe = _produtoNfeRepositorio.InserirListaDeProdutos(notaFiscal.Produtos, notaFiscal.ID);

            return nota;
        }

        public NotaFiscal ObterPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var nota = _notaFiscalRepositorio.ObterPorId(id);

            if (nota == null) return null;

            nota.Destinatario = _destinatarioRepositorio.ObterPorId(nota.Destinatario.ID);
            nota.Destinatario.Endereco = _enderecoRepositorio.ObterPorId(nota.Destinatario.Endereco.ID);

            nota.Emitente = _emitenteRepositorio.ObterPorId(nota.Emitente.ID);
            nota.Emitente.Endereco = _enderecoRepositorio.ObterPorId(nota.Emitente.Endereco.ID);

            nota.Transportador = _transportadorRepositorio.ObterPorId(nota.Transportador.ID);
            nota.Transportador.Endereco = _enderecoRepositorio.ObterPorId(nota.Transportador.Endereco.ID);

            return nota;
        }

        public List<NotaFiscal> ObterTodos()
        {
            var listaNotas = _notaFiscalRepositorio.ObterTodos();

            if (listaNotas == null)
                return null;

            foreach (var nota in listaNotas)
            {
                nota.Destinatario = _destinatarioRepositorio.ObterPorId(nota.Destinatario.ID);
                nota.Destinatario.Endereco = _enderecoRepositorio.ObterPorId(nota.Destinatario.Endereco.ID);
            }

            foreach (var nota in listaNotas)
            {
                nota.Emitente = _emitenteRepositorio.ObterPorId(nota.Emitente.ID);
                nota.Emitente.Endereco = _enderecoRepositorio.ObterPorId(nota.Emitente.Endereco.ID);
            }

            foreach (var nota in listaNotas)
            {
                nota.Transportador = _transportadorRepositorio.ObterPorId(nota.Transportador.ID);
                nota.Transportador.Endereco = _enderecoRepositorio.ObterPorId(nota.Transportador.Endereco.ID);
            }

            return listaNotas;
        }
    }
}
