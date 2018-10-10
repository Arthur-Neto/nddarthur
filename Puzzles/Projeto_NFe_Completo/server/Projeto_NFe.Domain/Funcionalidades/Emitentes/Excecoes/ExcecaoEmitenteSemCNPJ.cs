using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoEmitenteSemCNPJ : ExcecaoDeNegocio
    {
        public ExcecaoEmitenteSemCNPJ(): base(CodigosErros.InvalidObject, "O Emitente deve possuir um CNPJ.")
        {
        }
    }
}
