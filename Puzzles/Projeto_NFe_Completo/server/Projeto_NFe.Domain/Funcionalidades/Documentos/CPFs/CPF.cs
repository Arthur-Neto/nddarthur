using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs
{
    public struct CPF
    {
        public readonly string numeroComPontuacao;
        public string numeroSemPontuacao;

        private CPF(string numeroComPontuacao)
        {
            this.numeroComPontuacao = numeroComPontuacao;
            this.numeroSemPontuacao = "";

            numeroSemPontuacao = RetirarPontuacao(numeroComPontuacao);

            Validar(numeroSemPontuacao);
        }

        private void Validar(string numeroSemPontuacao)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (numeroSemPontuacao == "00000000000" || numeroSemPontuacao == "11111111111" ||
                numeroSemPontuacao == "22222222222" || numeroSemPontuacao == "33333333333" ||
                numeroSemPontuacao == "44444444444" || numeroSemPontuacao == "55555555555" ||
                numeroSemPontuacao == "66666666666" || numeroSemPontuacao == "77777777777" ||
                numeroSemPontuacao == "88888888888" || numeroSemPontuacao == "99999999999")
            {
                throw new ExcecaoNumeroCPFInvalido();
            }

            if (numeroSemPontuacao.Length != 11)
                throw new ExcecaoCPFNaoPossuiOnzeNumeros();

            tempCpf = numeroSemPontuacao.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            if (numeroSemPontuacao.EndsWith(digito) == false)
                throw new ExcecaoNumeroCPFInvalido();
        }

        private string RetirarPontuacao(string numeroComPontuacao)
        {
            return numeroComPontuacao.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public static implicit operator CPF(Documento documento)
            => new CPF(documento.Numero);

        public static implicit operator Documento(CPF cpf)
            => new Documento(cpf.numeroComPontuacao, TipoDocumento.CPF);
    }
}