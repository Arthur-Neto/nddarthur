using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoInscricacaoMunicipalEmitenteComLetras : ExcecaoDeNegocio
    {
        public ExcecaoInscricacaoMunicipalEmitenteComLetras(): base(CodigosErros.InvalidObject, "A inscrição municipal deve possuir apenas numeros.")
        {
        }
    }
}
