using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoChaveInvalida : ExcecaoDeNegocio
    {
        public ExcecaoChaveInvalida() : base("Chave de acesso invalida")
        {
        }
    }
}
