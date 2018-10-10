using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoInscricacaoEstadualEmitenteComLetras : ExcecaoDeNegocio
    {
        public ExcecaoInscricacaoEstadualEmitenteComLetras(): base(CodigosErros.InvalidObject, "A inscricao estadual deve possuir apenas numeros.")
        {
        }
    }
}
