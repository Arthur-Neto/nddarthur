using Pizzaria.Dominio.Features.Enderecos;
using Postmon4Net;

namespace Pizzaria.Infra.Features.CEP
{
    public class PostmonApi
    {
        public Endereco LocalizarEndereco(string CEP)
        {
            var endereco = new Endereco();

            var postMon = EncontrarEndereco.PorCEP(CEP);
            endereco.Cep = postMon.cep;
            endereco.Cidade = postMon.cidade;
            endereco.Estado = postMon.estado;
            endereco.Rua = postMon.logradouro;
            endereco.Bairro = postMon.bairro;
            endereco.Complemento = string.Empty;
            endereco.Numero = 1;
            return endereco;
        }
    }
}
