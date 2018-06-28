using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Documentos.Features.Cnpjs
{
    public class Cnpj : Documento
    {
        public Cnpj( ) : base(14)
        {

        }
        public void SetarNumeros(string numeros)
        {
            numeros = Remove(numeros);
            if (numeros.Length != 14)
                throw new ExcecaoCNPJInvalido();
            for (int i = 0; i < 14; i++)
                this[i] = Convert.ToInt32(numeros[i].ToString());
        }

        public new int this[int index]
        {
            get => base[index];
            private set => base[index] = value;
        }
        protected override bool Calcular() => base.Calcular();
        protected override int SomaDigito(int fim)
        {
            int soma = new int();
            int multiplicador = 2;
            for (int i = fim; i >= 0; i--)
            {
                soma += this[i] * multiplicador;
                if (multiplicador == 9)
                    multiplicador = 1;
                multiplicador++;
            }
            return soma;
        }
        public override void Validar()
        {
            try { base.Validar(); }
            catch (ExcecaoDocumento) { throw new ExcecaoCNPJInvalido(); }
        }
        public override string ToString()
            => String.Format("{0}{1}.{2}{3}{4}.{5}{6}{7}/{8}{9}{10}{11}-{12}{13}",
                this[0], this[1], this[2], this[3], this[4], this[5], this[6], this[7], this[8], this[9], this[10], this[11], this[12], this[13]);

    }
}
