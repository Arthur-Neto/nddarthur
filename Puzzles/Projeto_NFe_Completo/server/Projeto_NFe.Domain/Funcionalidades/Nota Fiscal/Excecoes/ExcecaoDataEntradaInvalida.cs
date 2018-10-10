using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal.Excecoes
{
    public class ExcecaoDataEntradaInvalida : ExcecaoDeNegocio
    {
        public ExcecaoDataEntradaInvalida() : base(CodigosErros.InvalidObject, "A data de entrada não pode ser maior que a data atual.")
        {
        }
    }
}
