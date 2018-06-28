using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Infra.Documentos.Base;
using System;

namespace Projeto_NFe.Infra.Documentos.Features.Cpfs
{
    public class Cpf : Documento
    {
        public Cpf( ) : base(11)
        {

        }
        public void SetarNumeros(string numeros)
        {
            numeros = Remove(numeros);
            if (numeros.Length != 11)
                throw new ExcecaoCPFInvalido();
            for (int i = 0; i < 11; i++)
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
                multiplicador++;
            }
            return soma;
        }
        public override void Validar()
        {
            try { base.Validar(); }
            catch (ExcecaoDocumento) { throw new ExcecaoCPFInvalido(); }
        }
        public override string ToString()
            => String.Format("{0}{1}{2}.{3}{4}{5}.{6}{7}{8}-{9}{10}",
                this[0], this[1], this[2], this[3], this[4], this[5], this[6], this[7], this[8], this[9], this[10]);
    }
}
