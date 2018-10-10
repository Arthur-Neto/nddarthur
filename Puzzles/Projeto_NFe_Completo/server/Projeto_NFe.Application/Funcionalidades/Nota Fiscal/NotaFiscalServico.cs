using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais
{
    public class NotaFiscalServico : INotaFiscalServico
    {
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private IProdutoNotaFiscalRepositorio _produtoNotaFiscalRepositorio;
        private INotaFiscalEmitidaRepositorio _notaFiscalEmitidaRepositorio;
        private NotaFiscalRepositorioXML _notaFiscalRepositorioXML;

        public NotaFiscalServico(INotaFiscalRepositorio notaFiscalRepositorio, INotaFiscalEmitidaRepositorio notaFiscalEmitidaRepositorio, IProdutoNotaFiscalRepositorio produtoNotaFiscalRepositorio, NotaFiscalRepositorioXML notaFiscalRepositorioXML)
        {
            this._notaFiscalRepositorio = notaFiscalRepositorio;
            this._produtoNotaFiscalRepositorio = produtoNotaFiscalRepositorio;
            this._notaFiscalEmitidaRepositorio = notaFiscalEmitidaRepositorio;
            this._notaFiscalRepositorioXML = notaFiscalRepositorioXML;
        }

        public long Adicionar(NotaFiscalAdicionarComando comando)
        {
            NotaFiscal notaFiscal = Mapper.Map<NotaFiscalAdicionarComando, NotaFiscal>(comando);

            return _notaFiscalRepositorio.Adicionar(notaFiscal);
        }

        public bool Atualizar(NotaFiscalEditarComando comando)
        {
            NotaFiscal notaDb = _notaFiscalRepositorio.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();
            _produtoNotaFiscalRepositorio.DeletarProdutosPorIdNota(notaDb.Id);

            Mapper.Map<NotaFiscalEditarComando, NotaFiscal>(comando, notaDb);

            return _notaFiscalRepositorio.Atualizar(notaDb);
        }

        public NotaFiscal BuscarPorId(long id)
        {
            return _notaFiscalRepositorio.BuscarPorId(id) ?? throw new ExcecaoNaoEncontrado();
        }

        public bool Excluir(NotaFiscalRemoverComando comando)
        {
            NotaFiscal notaFiscal = _notaFiscalRepositorio.BuscarPorId(comando.Id) ?? throw new ExcecaoNaoEncontrado();
            _notaFiscalRepositorio.Excluir(notaFiscal);

            return _notaFiscalRepositorio.BuscarPorId(notaFiscal.Id) == null ? true : false;
        }

        public IQueryable<NotaFiscal> BuscarTodos()
        {
            return _notaFiscalRepositorio.BuscarTodos();
        }

        public bool ConsultarExistenciaDeNotaEmitida(string chaveDeAcesso)
        {
            long quantidadeDenotasFiscaisEncontrada = _notaFiscalEmitidaRepositorio.ConsultarExistenciaDeNotaEmitida(chaveDeAcesso);

            if (quantidadeDenotasFiscaisEncontrada > 0)
                return true;
            else
                return false;
        }

        public NotaFiscal BuscarNotaFiscalEmitidaPorChave(string chaveDeAcesso)
        {
            NotaFiscal notaFiscalEmitidaBuscada = _notaFiscalEmitidaRepositorio.BuscarNotaFiscalEmitidaPorChave(chaveDeAcesso);

            //XML DESERIALIZE

            return notaFiscalEmitidaBuscada;
        }

        public NotaFiscal Emitir(NotaFiscal notaFiscal, Random sorteador)
        {
            notaFiscal.CalcularValoresTotais();

            notaFiscal.GerarChaveDeAcesso(sorteador);

            while (ConsultarExistenciaDeNotaEmitida(notaFiscal.ChaveAcesso))
            {
                notaFiscal.GerarChaveDeAcesso(sorteador);
            }

            //Gerarando XML para inserção em banco
            string notaFiscalSerializadaParaXML = _notaFiscalRepositorioXML.Serializar(notaFiscal);

            long idNotaFiscalEmitida = _notaFiscalEmitidaRepositorio.Adicionar(notaFiscalSerializadaParaXML, notaFiscal.ChaveAcesso);

            if (idNotaFiscalEmitida != 0)
                _notaFiscalRepositorio.Excluir(notaFiscal);

            return notaFiscal;
        }
    }
}
