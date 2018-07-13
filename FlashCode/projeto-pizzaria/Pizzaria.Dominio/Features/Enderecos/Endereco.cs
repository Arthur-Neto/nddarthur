using Pizzaria.Dominio.Base;
using System;

namespace Pizzaria.Dominio.Features.Enderecos
{
    public class Endereco : Entidade
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public override void Validar()
        {
            if (String.IsNullOrWhiteSpace(Rua))
                throw new EnderecoRuaVaziaExcecao();
            if (String.IsNullOrWhiteSpace(Bairro))
                throw new EnderecoBairroVaziaExcecao();
            if (String.IsNullOrWhiteSpace(Cidade))
                throw new EnderecoCidadeVaziaExcecao();
            if (String.IsNullOrWhiteSpace(Estado))
                throw new EnderecoEstadoVaziaExcecao();
            if (String.IsNullOrWhiteSpace(Cep))
                throw new EnderecoCepVaziaExcecao();
            if (Numero <= 0)
                throw new EnderecoNumeroInvalidoExcecao();
        }

        public override string ToString()
        {
            return Cep;
        }
    }
}