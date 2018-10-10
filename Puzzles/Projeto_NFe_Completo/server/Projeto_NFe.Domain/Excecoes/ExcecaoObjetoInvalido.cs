namespace Projeto_NFe.Domain.Excecoes
{
    public class ExcecaoObjetoInvalido : ExcecaoDeNegocio
    {
        public ExcecaoObjetoInvalido() : base(CodigosErros.InvalidObject, "Objeto inválido")
        {
        }
    }
}
