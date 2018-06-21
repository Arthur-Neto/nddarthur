using System;
using TutorialORM.Dominio.Base;

namespace TutorialORM.Dominio.Features.Enderecos
{
    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public short Numero { get; set; }
        public string Complemento { get; set; }

        public override void Validar()
        {
            if (String.IsNullOrWhiteSpace(Logradouro))
                throw new EnderecoLogradouroVazioException();
            if (String.IsNullOrWhiteSpace(Bairro))
                throw new EnderecoBairroVazioException();
            if (String.IsNullOrWhiteSpace(Cidade))
                throw new EnderecoCidadeVaziaException();
            if (String.IsNullOrWhiteSpace(UF))
                throw new EnderecoUfVaziaException();
            if (Numero <= 0)
                throw new EnderecoNumeroInvalidoException();

        }
    }
}
