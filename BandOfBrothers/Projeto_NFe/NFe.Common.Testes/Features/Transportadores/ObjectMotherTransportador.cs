using NFe.Dominio.Features.Transportadores;

namespace NFe.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Transportador ObterTransportadorValidoComCpfENome()
        {
            return new Transportador()
            {
                Id = 1,
                Nome = "Fulano LTDA",
                Cnpj = "",
                Cpf = "05919707917",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorValidoComCpfERazaoSocial()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cpf = "05919707917",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorValidoComCnpjENome()
        {
            return new Transportador()
            {
                Id = 1,
                Nome = "Fulano LTDA",
                Cnpj = "06255692000103",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorValidoComCnpjERazaoSocial()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "06255692000103",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorInvalidoSemCpfOuCnpj()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "",
                Cpf = "",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorComCnpjVazio()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "",
                Cpf = "05919707917",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorComCpfVazio()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "06255692000103",
                Cpf = "",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorInvalidoSemNomeOuRazaoSocial()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "",
                Nome = "",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorInvalidoSemInscricaoEstadual()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                InscricaoEstadual = "",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorSemEndereco()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                InscricaoEstadual = "987654321"
            };
        }
        
        public static Transportador ObterTransportadorCpfInvalido()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "",
                Cpf = "000.000.000-00",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorCnpjZeradoCpfInvalidoUltimoDigito()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "",
                Cpf = "05919707916",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorCnpjZeradoCpfInvalidoPenultimoDigito()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "",
                Cpf = "05919707927",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorCnpjZeradoCpfMenorQue11()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "",
                Cpf = "0591970792",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Transportador ObterTransportadorCpfVazioCnpjMenorQue14()
        {
            return new Transportador()
            {
                Id = 1,
                RazaoSocial = "Fulano Transport",
                Cnpj = "0625569020010",
                Cpf = "",
                InscricaoEstadual = "987654321",
                Endereco = ObterEnderecoValido()
            };
        }
    }
}
