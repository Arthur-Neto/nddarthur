using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemEndereco : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemEndereco(): base(CodigosErros.InvalidObject, "O Emitente deve possuir um Endereço.")
        {
        }
    }
}
