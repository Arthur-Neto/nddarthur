using NFe.Aplicacao.Base;
using NFe.Dominio.Exceptions;
using NFe.Dominio.Features.Produtos;
using System.Collections.Generic;

namespace NFe.Aplicacao.Features.Produtos
{
    public class ProdutoServico : Servico<Produto>
    {
        public ProdutoServico(IProdutoRepositorio repositorio) : base(repositorio)
        {
        }

        public override Produto Atualizar(Produto entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            entidade.Validar();

            return base.Atualizar(entidade);
        }

        public override void Deletar(Produto entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            base.Deletar(entidade);
        }

        public override Produto PegarPorId(long id)
        {
            return base.PegarPorId(id);
        }

        public override IEnumerable<Produto> PegarTodos()
        {
            return base.PegarTodos();
        }

        public override Produto Salvar(Produto entidade)
        {
            entidade.Validar();

            return base.Salvar(entidade);
        }
    }
}
