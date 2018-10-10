using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Transportadoras.Excecoes
{
    public class ExcecaoTransportadorSemDocumento : ExcecaoDeNegocio
    {
        public ExcecaoTransportadorSemDocumento() : base(CodigosErros.InvalidObject, "Favor preencher o CNPJ/CPF do transportador")
        {
        }
    }
}
