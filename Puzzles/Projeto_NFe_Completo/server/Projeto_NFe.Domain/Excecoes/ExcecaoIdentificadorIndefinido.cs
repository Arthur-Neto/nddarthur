namespace Projeto_NFe.Domain.Excecoes
{
    public class ExcecaoNaoEncontrado : ExcecaoDeNegocio
    {
        public ExcecaoNaoEncontrado() : base(CodigosErros.NotFound, "Registro não encontrado") { }
    }
}
