namespace Projeto_NFe.Domain.Excecoes
{
    public class ExcecaoObjetoExistente : ExcecaoDeNegocio
    {
        public ExcecaoObjetoExistente() : base(CodigosErros.AlreadyExists, "Esse registro já existe") { }
    }
}
