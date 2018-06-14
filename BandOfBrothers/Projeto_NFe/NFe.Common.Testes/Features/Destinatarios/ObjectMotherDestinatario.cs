using NFe.Dominio.Features.Destinatarios;

namespace NFe.Common.Testes.Features
{
    public static partial class ObjectMother
    {
        public static Destinatario ObtemDestinatarioValido()
        {
            return new Destinatario()
            {
                Id = 1,
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000286",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioValidoComCnpjRazaoSocial()
        {
            return new Destinatario()
            {
                Id = 1,
                Nome = "",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000286",
                Cpf = "",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioSemEndereco()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000104",
                Cpf = "05919707917"
            };
        }

        public static Destinatario ObtemDestinatarioNomeVazio()
        {
            return new Destinatario()
            {
                Nome = "",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioRazaoSocialVazio()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioNomeeRazaoSocialVazio()
        {
            return new Destinatario()
            {
                Nome = "",
                RazaoSocial = "",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioInscricaoEstadualVazio()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "",
                Cnpj = "06255692000103",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioCnpjVazio()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido() // fazer exceção do cnpj incorreto porem preenchido
            };
        }

        public static Destinatario ObtemDestinatarioCpfVazio()
        {
            return new Destinatario()
            {
                Nome = "",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "06255692000103",
                Cpf = "",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioCnpjECpfVazio()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "",
                Cpf = "",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioCnpjInvalidoUltimoDigitoECpfVazio()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "0625569200010",
                Cpf = "",
                Endereco = ObterEnderecoValido()
            };
        }
        public static Destinatario ObtemDestinatarioCnpjVazioECpfInvalidoUltimoDigito()
        {
            return new Destinatario()
            {
                Nome = "FuladoX",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "",
                Cpf = "0591970791",
                Endereco = ObterEnderecoValido()
            };
        }

        public static Destinatario ObtemDestinatarioValidoComCpfERazaoSocial()
        {
            return new Destinatario()
            {
                Id = 1,
                Nome = "",
                RazaoSocial = "FulanoY",
                InscricaoEstadual = "1234567890",
                Cnpj = "",
                Cpf = "05919707917",
                Endereco = ObterEnderecoValido()
            };
        }
    }
}
