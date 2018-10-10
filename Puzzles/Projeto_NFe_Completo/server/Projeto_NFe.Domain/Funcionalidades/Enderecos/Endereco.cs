using Projeto_NFe.Domain.Base;

namespace Projeto_NFe.Domain.Funcionalidades.Enderecos
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}
