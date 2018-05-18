using BancoApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoApp.Infra.Data
{

    public class ContaMem
    {
        private List<ContaCorrente> _contas = new List<ContaCorrente>();

        public void AdicionarConta(ContaCorrente NovaConta)
        {
            if (NovaConta != null)
                _contas.Add(NovaConta);
       
        }

        public List<ContaCorrente> ListarContas()
        {
            return _contas;
        }

        public void Excluir(ContaCorrente contaCorrenteSelecionada)
        {
            if (contaCorrenteSelecionada != null)
                _contas.Remove(contaCorrenteSelecionada);
        }

        public void ValidaContaExistente(ContaCorrente conta)
        {
            var contas = ListarContas();

            foreach (var item in contas)
            {
                if (item.Numero == conta.Numero)
                {
                    throw new Exception("Conta existente, altere o número.");
                }
            }
        }
    }
}
