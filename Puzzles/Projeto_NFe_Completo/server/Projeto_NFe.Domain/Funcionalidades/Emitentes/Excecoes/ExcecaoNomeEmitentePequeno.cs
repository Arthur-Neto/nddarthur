using Projeto_NFe.Domain.Excecoes;

namespace Projeto_NFe.Domain.Funcionalidades.Emitentes.Excecoes
{
    public class ExcecaoNomeEmitentePequeno : ExcecaoDeNegocio
    {
        public ExcecaoNomeEmitentePequeno() : base(CodigosErros.InvalidObject, "O nome do emitente deve possuir no minimo 5 caracteres")
        {

        }
    }
}
