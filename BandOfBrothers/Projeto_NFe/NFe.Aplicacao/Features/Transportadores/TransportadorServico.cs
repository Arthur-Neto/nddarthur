using NFe.Aplicacao.Base;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Enderecos;
using NFe.Dominio.Features.Transportadores;
using System.Collections.Generic;

namespace NFe.Aplicacao.Features.Transportadores
{
    public class TransportadorServico : Servico<Transportador>
    {
        IEnderecoRepositorio enderecoRepositorio;

        public TransportadorServico(ITransportadorRepositorio repositorio, IEnderecoRepositorio enderecoRepositorio) : base(repositorio)
        {
            this.enderecoRepositorio = enderecoRepositorio;
        }

        public override Transportador Atualizar(Transportador entidade)
        {
            if (entidade.Id == 0 || entidade.Endereco.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            base.Atualizar(entidade);
            enderecoRepositorio.Atualizar(entidade.Endereco);

            return PegarPorId(entidade.Id);
        }

        public override void Deletar(Transportador entidade)
        {
            if (entidade.Id == 0 || entidade.Endereco.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
            enderecoRepositorio.Deletar(entidade.Endereco);
        }

        public override Transportador PegarPorId(long id)
        {
            Transportador transportador = base.PegarPorId(id);

            if (transportador == null)
                return null;

            transportador.Endereco = enderecoRepositorio.PegarPorId(transportador.Endereco.Id);

            return transportador;
        }

        public override IEnumerable<Transportador> PegarTodos()
        {
            IEnumerable<Transportador> transportadores = base.PegarTodos();

            PegarDependencias(transportadores);

            return transportadores;
        }

        public override Transportador Salvar(Transportador entidade)
        {
            entidade.Validar();

            if (enderecoRepositorio.PegarPorId(entidade.Endereco.Id) == null)
                enderecoRepositorio.Salvar(entidade.Endereco);

            entidade = base.Salvar(entidade);

            return PegarPorId(entidade.Id);
        }

        private void PegarDependencias(IEnumerable<Transportador> transportadores)
        {
            foreach (var transportador in transportadores)
            {
                transportador.Endereco = enderecoRepositorio.PegarPorId(transportador.Endereco.Id);
            }
        }
        
    }
}
