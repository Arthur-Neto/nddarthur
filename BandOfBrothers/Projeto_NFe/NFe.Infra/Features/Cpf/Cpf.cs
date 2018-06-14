namespace NFe.Infra.Features.Cpf
{
    public struct Cpf
    {
        public readonly string valor;

        public bool EhValido;

        public string valorFormatado;

        private Cpf(string value)
        {
            valor = value;
            valorFormatado = "";
            EhValido = false;

            if (string.IsNullOrEmpty(value))
                return;

            FormatarValor(value);

            ValidarCpf(valorFormatado);
        }

        private void ValidarCpf(string value)
        {
            var posicao = 0;
            var totalDigito1 = 0;
            var totalDigito2 = 0;
            var dv1 = 0;
            var dv2 = 0;

            bool digitosIdenticos = true;
            var ultimoDigito = -1;

            foreach (var c in value)
            {
                if (char.IsDigit(c))
                {
                    var digito = c - '0';
                    if (posicao != 0 && ultimoDigito != digito)
                    {
                        digitosIdenticos = false;
                    }

                    ultimoDigito = digito;
                    if (posicao < 9)
                    {
                        totalDigito1 += digito * (10 - posicao);
                        totalDigito2 += digito * (11 - posicao);
                    }
                    else if (posicao == 9)
                    {
                        dv1 = digito;
                    }
                    else if (posicao == 10)
                    {
                        dv2 = digito;
                    }

                    posicao++;
                }
            }

            if (posicao > 11)
            {
                EhValido = false;
                return;
            }

            if (digitosIdenticos)
            {
                EhValido = false;
                return;
            }

            var digito1 = totalDigito1 % 11;
            digito1 = digito1 < 2
                ? 0
                : 11 - digito1;

            if (dv1 != digito1)
            {
                EhValido = false;
                return;
            }

            totalDigito2 += digito1 * 2;
            var digito2 = totalDigito2 % 11;
            digito2 = digito2 < 2
                ? 0
                : 11 - digito2;

            EhValido = dv2 == digito2;
        }

        private void FormatarValor(string value)
        {
            valorFormatado = value.Replace(".", "").Replace("-", "").Replace("/", "");
        }

        public static implicit operator Cpf(string value)
            => new Cpf(value);

        public static implicit operator string(Cpf cpf)
            => cpf.valor;
    }
}
