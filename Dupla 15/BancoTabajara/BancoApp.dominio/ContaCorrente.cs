using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.dominio
{
    public class ContaCorrente
    {
        public double Numero { get; set; }

        public double Saldo { get; set; }

        public bool StatusContaEspecial { get; set; }

        public double Limite { get; set; }

        public Cliente Cliente { get; set; }
        
        public List<Movimentacao> _mov = new List<Movimentacao>();

        public double Saque(double value)
        {
            try
            {
                if (value < (Saldo + Limite))
                {
                    Saldo = (Saldo - value);
                    RegistraMovimentacao(value, "Debito", "Saque");
                }
            }
            catch(Exception)
            {
                throw new Exception();
            }
            return Saldo;
        }

        public void Deposito(double value)
        {
            Saldo = (Saldo + value);
            RegistraMovimentacao(value, "Crédito", "Deposito");
        }

        public void EmissaoDeSaldo()
        {
            Console.WriteLine("Numero Conta Corrente: {0}\n" +
                                "Saldo Conta Corrente: {1} \n" +
                                "Saldo Limite: {2}\n" +
                                "Total Disponível: {3}",
                                Numero, Saldo, Limite, (Saldo + Limite));
        }

        public void Transferencia(ContaCorrente contaDestino, double value)
        {
            try
            {
                if (Saldo > value)
                {
                    this.Saque(value);
                    contaDestino.Deposito(value);
                    this.RegistraMovimentacao(value, "Debito", "Transferência");

                }
            }
            catch (Exception )
            {
                throw new Exception("Saldo insuficiente para transferência.");
            }

        }

        public string Extrato()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (Movimentacao movi in _mov)
            {
                if (movi != null)
                {
                    sb.Append(movi.ToString()).AppendLine();
                }
            }

            return sb.ToString();
        }

        private void RegistraMovimentacao(double value, String type, String operation)
        {
            Movimentacao _movimentacao = new Movimentacao();
            _movimentacao.Valor = value;
            _movimentacao.Tipo = type;
            _movimentacao.Operacao = operation;

            _mov.Add(_movimentacao);
        }

        public override string ToString()
        {
            return String.Format("Cliente: {0} | Numero: {1} - Saldo: R${2} - Limite: R${3} | Saldo Total: R${4}", Cliente.Nome, Numero, Saldo, Limite, (Saldo+Limite));
        }
    }
}
