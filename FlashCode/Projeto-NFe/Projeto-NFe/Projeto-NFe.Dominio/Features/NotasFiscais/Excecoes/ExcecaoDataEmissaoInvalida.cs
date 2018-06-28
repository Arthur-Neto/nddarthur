using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoDataEmissaoInvalida : ExcecaoDeNegocio
    {
        public ExcecaoDataEmissaoInvalida() : base("A data de emissão invalida")
        {
        }
    }
}
