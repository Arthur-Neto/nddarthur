using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoRazaoSocialEmitentePequeno : ExcecaoDeNegocio
    {
        public ExcecaoRazaoSocialEmitentePequeno() : base(CodigosErros.InvalidObject, "A Razão Social do emitente deve possuir no minimo 5 caracteres")
        {

        }
    }
}
