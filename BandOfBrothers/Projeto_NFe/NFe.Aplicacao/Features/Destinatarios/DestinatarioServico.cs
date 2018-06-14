using NFe.Aplicacao.Base;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Enderecos;
using System.Collections.Generic;

namespace NFe.Aplicacao.Features.Destinatarios
{
    public class DestinatarioServico : Servico<Destinatario>
    {
        IEnderecoRepositorio enderecoRepositorio;

        public DestinatarioServico(IDestinatarioRepositorio repositorio, IEnderecoRepositorio enderecoRepositorio) : base(repositorio)
        {
            this.enderecoRepositorio = enderecoRepositorio;
        }

        public override Destinatario Atualizar(Destinatario entidade)
        {
            if (entidade.Id == 0 || entidade.Endereco.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();
            
            enderecoRepositorio.Atualizar(entidade.Endereco);
            base.Atualizar(entidade);

            return PegarPorId(entidade.Id);
        }

        public override void Deletar(Destinatario entidade)
        {
            if (entidade.Id == 0 || entidade.Endereco.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
            enderecoRepositorio.Deletar(entidade.Endereco);
        }

        public override Destinatario PegarPorId(long id)
        {
            Destinatario destinatario = base.PegarPorId(id);

            if (destinatario == null)
                return null;

            destinatario.Endereco = enderecoRepositorio.PegarPorId(destinatario.Endereco.Id);

            return destinatario;
        }

        public override IEnumerable<Destinatario> PegarTodos()
        {
            IEnumerable<Destinatario> destinatarios = base.PegarTodos();

            PegarDependencias(destinatarios);

            return destinatarios;
        }

        public override Destinatario Salvar(Destinatario entidade)
        {
            entidade.Validar();

            if (enderecoRepositorio.PegarPorId(entidade.Endereco.Id) == null)
                enderecoRepositorio.Salvar(entidade.Endereco);

            entidade = base.Salvar(entidade);

            return PegarPorId(entidade.Id);
        }

        private void PegarDependencias(IEnumerable<Destinatario> destinatarios)
        {
            foreach (var destinatario in destinatarios)
            {
                destinatario.Endereco = enderecoRepositorio.PegarPorId(destinatario.Endereco.Id);
            }
        }
    }
}
