using FluentAssertions;
using NFe.Infra.Features.Cnpj;
using NUnit.Framework;

namespace NFe.Infra.Testes.Features.CNPJs
{
    [TestFixture]
    public class CnpjTeste
    {

        [Test]
        public void CNPJ_Infra_DeveValidarCnpjOk()
        {
            Cnpj cnpj = "06255692000103";
            cnpj.EhValido.Should().BeTrue();
        }

        [Test]
        public void CNPJ_Infra_DeveValidarCnpjNaoFormatado()
        {
            Cnpj cnpj = "062.556.92/0001-03";
            cnpj.EhValido.Should().BeTrue();
        }

        [Test]
        public void CNPJ_Infra_DeveSerFalsoCnpjInvalido()
        {
            Cnpj cnpj = "000.000.000-00";
            cnpj.EhValido.Should().BeFalse();
        }

        [Test]
        public void CNPJ_Infra_DeveSerInvalidoCnpjSuperiorA14Caracteres()
        {
            Cnpj cnpj = "000.000.000-00000.11.22";
            cnpj.EhValido.Should().BeFalse();
        }

        [Test]
        public void CNPJ_Infra_DeveSerInvalidoCnpjVazio()
        {
            Cnpj cnpj = "";
            cnpj.EhValido.Should().BeFalse();
        }

        [Test]
        public void CNPJ_Infra_DeveSerInvalidoCnpjComUmDigitoInvalido()
        {
            Cnpj cnpj = "062.556.92/0001-13";
            cnpj.EhValido.Should().BeFalse();
        }

        [Test]
        public void CNPJ_Infra_DeveSerInvalidoCnpjComDoisDigitoInvalido()
        {
            Cnpj cnpj = "062.556.92/0001-02";
            cnpj.EhValido.Should().BeFalse();
        }

        [Test]
        public void CNPJ_Infra_DeveConverterParaString()
        {
            Cnpj cnpj = "062.556.92/0001-02";

            string result = (string)cnpj;
            result.Should().NotBeNull();
        }
    }
}
