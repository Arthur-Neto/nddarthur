using System.Collections.Generic;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Enderecos;

namespace Projeto_NFe.Aplicacao.Features.Emitentes
{
    public class EmitenteServico : IEmitenteServico
    {
        private IEmitenteRepositorio _emitenteRepositorio;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private IEnderecoRepositorio _enderecoRepositorio;

        public EmitenteServico(IEmitenteRepositorio emitenteRepositorio, INotaFiscalRepositorio notaFiscalRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _emitenteRepositorio = emitenteRepositorio;
            _notaFiscalRepositorio = notaFiscalRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public Emitente Atualizar(Emitente emitente)
        {
            if (emitente.ID < 1)
                throw new ExcecaoIdentificadorInvalido();

            emitente.Validar();

            return _emitenteRepositorio.Atualizar(emitente);
        }

        public bool Deletar(long id)
        {
            if(id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var notaFiscal = _notaFiscalRepositorio.ObterPorEmitenteID(id);

            if (notaFiscal != null)
                throw new ExcecaoChaveEstrangeira();

            return _emitenteRepositorio.Deletar(id);
        }

        public Emitente Inserir(Emitente emitente)
        {
            emitente.Validar();
            return _emitenteRepositorio.Inserir(emitente);
        }

        public Emitente ObterPorId(long id)
        {
            if (id < 1)
                throw new ExcecaoIdentificadorInvalido();

            var emitente = _emitenteRepositorio.ObterPorId(id);

            if (emitente == null) return null;

            emitente.Endereco = _enderecoRepositorio.ObterPorId(emitente.Endereco.ID);

            return emitente;
        }

        public List<Emitente> ObterTodos()
        {
            var emitentes = _emitenteRepositorio.ObterTodos();

            if (emitentes == null)
                return null;

            foreach (var emitente in emitentes)
            {
                emitente.Endereco = _enderecoRepositorio.ObterPorId(emitente.Endereco.ID);
            }

            return emitentes;
        }
    }
}
