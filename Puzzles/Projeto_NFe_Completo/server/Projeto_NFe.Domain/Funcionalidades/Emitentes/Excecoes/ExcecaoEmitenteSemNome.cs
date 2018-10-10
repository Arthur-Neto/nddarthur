using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemNome : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemNome() : base (CodigosErros.InvalidObject, "O Emitente deve possuir um nome fantasia")
        {

        }
    }
}
