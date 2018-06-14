using FluentAssertions;
using NFe.Infra.Features.Cpf;
using NUnit.Framework;

namespace NFe.Infra.Testes.Features.CPFs
{
    [TestFixture]
    public class CpfTeste
    {

       [Test]
       public void CPF_Infra_DeveValidarCpf()
        {
            Cpf cpf = "01253027978";
            cpf.EhValido.Should().BeTrue();
        }
        [Test]
        public void CPF_Infra_DeveValidarCpfFormatado()
        {
            Cpf cpf = "012.530.279-78";
            cpf.EhValido.Should().BeTrue();
        }

        [Test]
        public void CPF_Infra_DeveSerInvalidoCpfComUmDigitoInvalido()
        {
            Cpf cpf = "012.530.279-88";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_Infra_DeveSerInvalidoCpfComDoisDigitoInvalido()
        {
            Cpf cpf = "012.530.279-79";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_Infra_DeveSerInvalidoInicioCpf()
        {
            Cpf cpf = "012.530.288-79";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_Infra_DeveSerInvalidoCpfZerado()
        {
            Cpf cpf = "000.000.000-00";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_Infra_DeveSerInvalidoCpfMaiorQueOnzeDigitos()
        {
            Cpf cpf = "000.000.000-00.00";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_Infra_DeveSerInvalidoCpfVazio()
        {
            Cpf cpf = "";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_Infra_DeveConverterParaString()
        {
            Cpf cpf = "05919707917";

            string result = (string)cpf;
            result.Should().NotBeNull();
        }

        [Test]
        public void CPF_DigitosIdenticos_DeveFalhar()
        {
            Cpf cpf = "11111111111";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_DigitosIdenticosFinal_DeveFalhar()
        {
            Cpf cpf = "05919707911";
            cpf.EhValido.Should().BeFalse();
        }

        [Test]
        public void CPF_String_DeveFalhar()
        {
            Cpf cpf = "s";
            cpf.EhValido.Should().BeFalse();
        }
    }
}
