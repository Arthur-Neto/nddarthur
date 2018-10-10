using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemInscricaoMunicipal : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemInscricaoMunicipal(): base(CodigosErros.InvalidObject, "O Emitente deve possuir uma Inscrição Municipal.")
        {
        }
    }
}
