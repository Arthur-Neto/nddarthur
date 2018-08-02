using ArthurProva.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArthurProva.Domain
{
    public class Contato : Entidade
    {   
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Departamento { get; set; }

        public string Endereco { get; set; }

        public int Telefone { get; set; }

        public override void Validar()
        {
            if (Nome.Length > 50 || Email.Length > 50 || Departamento.Length > 50 || Endereco.Length > 50)
                throw new ValidacaoException("O número máximo de caracteres para cada campo é 50");

            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Departamento) || string.IsNullOrWhiteSpace(Endereco))
                throw new ValidacaoException("Nenhum campo pode estar em branco");

            if (Telefone <= 0)
                throw new ValidacaoException("Telefone não pode ser menor do que zero");
        }

        public override string ToString()
        {
            return String.Format("Nome: {0} Email: {1} Dep: {2} Endereço: {3} Telefone: {4}", Nome, Email, Departamento, Endereco, Telefone);
        }
    }
}
