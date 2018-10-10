using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemInscricaoEstadual : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemInscricaoEstadual(): base(CodigosErros.InvalidObject, "O Emitente deve possuir uma Inscrição Estadual.")
        {
        }
    }
}
