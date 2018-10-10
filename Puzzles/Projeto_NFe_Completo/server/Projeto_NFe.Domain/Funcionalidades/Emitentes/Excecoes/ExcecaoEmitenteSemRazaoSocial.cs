using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemRazaoSocial : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemRazaoSocial(): base(CodigosErros.InvalidObject, "O Emitente deve possuir uma razão social.")
        {
        }
    }
}
