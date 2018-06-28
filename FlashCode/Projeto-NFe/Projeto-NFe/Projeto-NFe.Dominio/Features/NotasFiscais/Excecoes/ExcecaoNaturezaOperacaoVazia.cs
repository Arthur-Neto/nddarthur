using Projeto_NFe.Dominio.Excecoes;

namespace Projeto_NFe.Dominio.Features.NotasFiscais.Excecoes
{
    public class ExcecaoNaturezaOperacaoVazia : ExcecaoDeNegocio
    {
        public ExcecaoNaturezaOperacaoVazia() : base("A natureza da operação não pode ser vazio")
        {
        }
    }
}
