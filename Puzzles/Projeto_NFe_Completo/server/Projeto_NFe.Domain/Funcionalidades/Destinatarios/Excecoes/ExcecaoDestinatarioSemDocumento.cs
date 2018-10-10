using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Destinatarios.Excecoes
{
    public class ExcecaoDestinatarioSemDocumento : ExcecaoDeNegocio
    {
        public ExcecaoDestinatarioSemDocumento() : base(CodigosErros.InvalidObject, "Não foi preenchido o CNPJ/CPF do destinatário")
        {
        }
    }
}
