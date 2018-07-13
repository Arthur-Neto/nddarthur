using Pizzaria.Dominio.Base;
using Pizzaria.Dominio.Features.Clientes.Excecoes;
using Pizzaria.Dominio.Features.Enderecos;
using System;

namespace Pizzaria.Dominio.Features.Clientes
{
    public class Cliente : Entidade
    {
        public string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public String CPF { get; set; }
        public String CNPJ { get; set; }

        public override string ToString()
        {
            return String.Format("Nome: {0} - Telefone: {1} - CPF: {2} - CNPJ: {3} - Endereco: {4}", Nome, Telefone, CPF, CNPJ, Endereco.Rua);
        }

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Nome))
                throw new NomeInvalidoExcecao();
            if (Endereco == null)
                throw new EnderecoInvalidoExcecao();
            if (String.IsNullOrEmpty(Telefone))
                throw new TelefoneInvalidoExcecao();
            if (DataDeNascimento > DateTime.Now)
                throw new DataNascimentoInvalidaExcecao();
            Endereco.Validar();
        }
    }
}