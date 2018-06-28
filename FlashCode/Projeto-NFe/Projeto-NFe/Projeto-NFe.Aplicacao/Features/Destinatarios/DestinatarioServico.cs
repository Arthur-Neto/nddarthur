using System.Collections.Generic;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Enderecos;

namespace Projeto_NFe.Aplicacao.Features.Destinatarios
{
    public class DestinatarioServico : IDestinatarioServico
    {
        private IDestinatarioRepositorio _destinatarioRepositorio;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private IEnderecoRepositorio _enderecoRepositorio;

        public DestinatarioServico(IDestinatarioRepositorio destinatarioRepositorio, INotaFiscalRepositorio notaFiscalRepositorio = null, IEnderecoRepositorio enderecoRepositorio = null)
        {
            _destinatarioRepositorio = destinatarioRepositorio;
            _notaFiscalRepositorio = notaFiscalRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Destinatario Atualizar(Destinatario destinatario)
        {
            if (destinatario.ID <= 0)
                throw new ExcecaoIdentificadorInvalido();

            destinatario.Validar();

            return _destinatarioRepositorio.Atualizar(destinatario);
        }

        public bool Deletar(long id)
        {
            if (id <= 0)
                throw new ExcecaoIdentificadorInvalido();

            var notaFiscal = _notaFiscalRepositorio.ObterPorDestinatarioID(id);

            if (notaFiscal != null)
                throw new ExcecaoChaveEstrangeira();

            return _destinatarioRepositorio.Deletar(id);
        }

        public Destinatario Inserir(Destinatario destinatario)
        {
            destinatario.Validar();

            return _destinatarioRepositorio.Inserir(destinatario);
        }

        public Destinatario ObterPorId(long id)
        {
            if (id <= 0)
                throw new ExcecaoIdentificadorInvalido();

            var destinatario = _destinatarioRepositorio.ObterPorId(id);

            if (destinatario == null)
                return null;

            destinatario.Endereco = _enderecoRepositorio.ObterPorId(destinatario.Endereco.ID);

            return destinatario;
        }

        public List<Destinatario> ObterTodos()
        {
            var destinatario = _destinatarioRepositorio.ObterTodos();

            if (destinatario == null)
                return null;

            foreach (var item in destinatario)
            {
                item.Endereco = _enderecoRepositorio.ObterPorId(item.Endereco.ID);
            }

            return destinatario;
        }
    }
}
