using NFe.Aplicacao.Base;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Enderecos;
using System.Collections.Generic;

namespace NFe.Aplicacao.Features.Emitentes
{
    public class EmitenteServico : Servico<Emitente>
    {
        IEnderecoRepositorio enderecoRepositorio;

        public EmitenteServico(IEmitenteRepositorio repositorio, IEnderecoRepositorio enderecoRepositorio) : base(repositorio)
        {
            this.enderecoRepositorio = enderecoRepositorio;
        }

        public override Emitente Atualizar(Emitente entidade)
        {
            if (entidade.Id == 0 || entidade.Endereco.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            base.Atualizar(entidade);
            enderecoRepositorio.Atualizar(entidade.Endereco);

            return PegarPorId(entidade.Id);
        }

        public override void Deletar(Emitente entidade)
        {
            if (entidade.Id == 0 || entidade.Endereco.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
            enderecoRepositorio.Deletar(entidade.Endereco);
        }

        public override Emitente PegarPorId(long id)
        {
            Emitente emitente = base.PegarPorId(id);

            if (emitente == null)
                return null;

            emitente.Endereco = enderecoRepositorio.PegarPorId(emitente.Endereco.Id);

            return emitente;
        }

        public override IEnumerable<Emitente> PegarTodos()
        {
            IEnumerable<Emitente> emitentes = base.PegarTodos();

            PegarDependencias(emitentes);

            return emitentes;
        }

        public override Emitente Salvar(Emitente entidade)
        {
            entidade.Validar();

            if (enderecoRepositorio.PegarPorId(entidade.Endereco.Id) == null)
                enderecoRepositorio.Salvar(entidade.Endereco);

            entidade = base.Salvar(entidade);
            return PegarPorId(entidade.Id);
        }

        private void PegarDependencias(IEnumerable<Emitente> emitentes)
        {
            foreach (var emitente in emitentes)
            {
                emitente.Endereco = enderecoRepositorio.PegarPorId(emitente.Endereco.Id);
            }
        }

    }
}
