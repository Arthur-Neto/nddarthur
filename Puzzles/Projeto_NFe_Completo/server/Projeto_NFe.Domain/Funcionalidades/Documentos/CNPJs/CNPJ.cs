using Projeto_NFe.Domain.Funcionalidades.Documentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs
{
    public struct CNPJ 
    {
        public readonly string numeroComPontuacao;
        public string numeroSemPontuacao;

        private CNPJ(string numeroComPontuacao)
        {
            this.numeroComPontuacao = numeroComPontuacao;
            this.numeroSemPontuacao = "";

            numeroSemPontuacao = RetirarPontuacao(numeroComPontuacao);

            Validar(numeroSemPontuacao);
        }

        private void Validar(string numeroSemPontuacao)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            if (this.numeroSemPontuacao.Length != 14)
                throw new ExcecaoCNPJNaoPossuiQuatorzeNumeros();

            if (this.numeroSemPontuacao == "00000000000000" || this.numeroSemPontuacao == "11111111111111" ||
                this.numeroSemPontuacao == "22222222222222" || this.numeroSemPontuacao == "33333333333333" ||
                this.numeroSemPontuacao == "44444444444444" || this.numeroSemPontuacao == "55555555555555" ||
                this.numeroSemPontuacao == "66666666666666" || this.numeroSemPontuacao == "77777777777777" ||
                this.numeroSemPontuacao == "88888888888888" || this.numeroSemPontuacao == "99999999999999")
            {
                throw new ExcecaoNumeroCNPJInvalido();
            }

            tempCnpj = this.numeroSemPontuacao.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            if (this.numeroSemPontuacao.EndsWith(digito) == false)
                throw new ExcecaoNumeroCNPJInvalido();
        }

        private string RetirarPontuacao(string numeroComPontuacao)
        {
            return numeroComPontuacao.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public static implicit operator CNPJ(Documento documento)
            => new CNPJ(documento.Numero);

        public static implicit operator Documento(CNPJ cnpj)
            => new Documento(cnpj.numeroSemPontuacao, TipoDocumento.CNPJ);
    }
}
