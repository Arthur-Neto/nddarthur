using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoListaDeProdutoVazia : ExcecaoDeNegocio
    {
        public ExcecaoListaDeProdutoVazia() : base(CodigosErros.InvalidObject, "A nota fiscal não pode ser emitida sem nenhum produto.")
        {
        }
    }
}
