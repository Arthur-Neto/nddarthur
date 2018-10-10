using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.CNPJs
{
    public class CNPJ
    {
        public string Numero { get; set; }
        public virtual void Validar()
        {
            //int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            //int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            //int soma;
            //int resto;
            //string digito;
            //string tempCnpj;
            //NumeroFormatado = NumeroFormatado.Trim();
            //NumeroFormatado = NumeroFormatado.Replace(".", "").Replace("-", "").Replace("/", "");

            //if (NumeroFormatado.Length != 14)
            //    throw

            //tempCnpj = NumeroFormatado.Substring(0, 12);
            //soma = 0;
            //for (int i = 0; i < 12; i++)
            //    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            //resto = (soma % 11);
            //if (resto < 2)
            //    resto = 0;
            //else
            //    resto = 11 - resto;
            //digito = resto.ToString();
            //tempCnpj = tempCnpj + digito;
            //soma = 0;
            //for (int i = 0; i < 13; i++)
            //    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            //resto = (soma % 11);
            //if (resto < 2)
            //    resto = 0;
            //else
            //    resto = 11 - resto;
            //digito = digito + resto.ToString();

            //return NumeroFormatado.EndsWith(digito);
        }
    }
}
