using NFe.Dominio.Base;

namespace NFe.Dominio.Features.Enderecos
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(Logradouro))
                throw new EnderecoEmptyLogradouroException();
            if (string.IsNullOrEmpty(Bairro))
                throw new EnderecoEmptyBairroException();
            if (string.IsNullOrEmpty(Municipio))
                throw new EnderecoEmptyMunicipioException();
            if (string.IsNullOrEmpty(Estado))
                throw new EnderecoEmptyEstadoException();
            if (string.IsNullOrEmpty(Pais))
                throw new EnderecoEmptyPaisException();
            if (string.IsNullOrEmpty(Numero))
                Numero = "s/n";
        }
    }
}
