namespace Projeto_NFe.Domain.Excecoes
{
    public class ExcecaoNaoPermitido : ExcecaoDeNegocio
    {
        public ExcecaoNaoPermitido() : base(CodigosErros.NotAllowed, "Operação não permitida") { }
    }
}
