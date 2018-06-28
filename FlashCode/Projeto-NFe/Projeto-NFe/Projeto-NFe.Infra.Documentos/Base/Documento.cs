using Projeto_NFe.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Documentos.Base
{
    public abstract class Documento
    {
        private int[] _numeros;
        public Documento(int quantidadeDigitos) => _numeros = new int[quantidadeDigitos];

        protected int this[int index]
        {
            get => _numeros[index];
            set => _numeros[index] = value;
        }
        protected abstract int SomaDigito(int fim);

        protected string Remove(string numeros) {
            if (numeros == null)
                return "";
            return numeros.Replace(".", "").Replace("-", "").Replace("/", "");
        }
        protected bool VerificaDigito(int resto, int digito)
        {
            if ((resto >= 0 && resto <= 1) && digito != 0)
                return false;
            if ((resto >= 2 && resto <= 10) && digito != 11 - resto)
                return false;
            return true;
        }
        protected virtual bool Calcular()
        {
            if (!VerificaDigito(SomaDigito(_numeros.Length - 3) % 11, this[_numeros.Length - 2]))
                return false;
            if (!VerificaDigito(SomaDigito(_numeros.Length - 2) % 11, this[_numeros.Length - 1]))
                return false;
            return true;
        }
        public virtual void Validar()
        {
            var digitos = Remove(this.ToString())
                        .Replace(this[0].ToString(), " ");

            if (string.IsNullOrEmpty(digitos.Trim()))
                throw new ExcecaoDocumento();
            if (!Calcular())
                throw new ExcecaoDocumento();
        }
    }
}
