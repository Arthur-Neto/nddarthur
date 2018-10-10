using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Tests.Objetos_de_Valor
{
    [TestFixture]
    public class CPFTeste
    {

        [Test]
        public void CPF_Infraestrutura_Validar_Sucesso()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "111.444.777-35";

            Action resultado = () => cpf.Validar();

            resultado.Should().NotThrow<Exception>();
            cpf.Numero.Should().Be("11144477735");
            cpf.NumeroComPontuacao.Should().Be("111.444.777-35");
        }

        [Test]
        public void CPF_Infraestrutura_Validar_NumeroZerado_ExcecaoNumeroCPFInvalido_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "000.000.000-00";

            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoNumeroCPFInvalido>();
        }

        [Test]
        public void CPF_Infraestrutura_Validar_NumeroPequeno_ExcecaoCPFNaoPossuiOnzeNumeros_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "000.000-00";
            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoCPFNaoPossuiOnzeNumeros>();
        }

        [Test]
        public void CPF_Infraestrutura_Validar_NumeroGrande_ExcecaoCPFNaoPossuiOnzeNumeros_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "000.000.000.000-00";
            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoCPFNaoPossuiOnzeNumeros>();
        }

        [Test]
        public void CPF_Infraestrutura_Validar_PrimeiroDigitoVerificador_Sucesso()
        {
            CPF cpfPrimeiroDigitoVerificador = new CPF();
            cpfPrimeiroDigitoVerificador.NumeroComPontuacao = "867.513.141-08";

            Action resultadoPrimeiroDigitoVerificador = () => cpfPrimeiroDigitoVerificador.Validar();

            resultadoPrimeiroDigitoVerificador.Should().NotThrow<Exception>();
            cpfPrimeiroDigitoVerificador.Numero.Should().Be("86751314108");
            cpfPrimeiroDigitoVerificador.NumeroComPontuacao.Should().Be("867.513.141-08");
        }

        [Test]
        public void CPF_Infraestrutura_Validar_SegundoDigitoVerificador_Sucesso()
        {
            CPF cpfSegundoDigitoVerificador = new CPF();
            cpfSegundoDigitoVerificador.NumeroComPontuacao = "696.629.258-30";

            Action resultadoSegundoDigitoVerificador = () => cpfSegundoDigitoVerificador.Validar();

            resultadoSegundoDigitoVerificador.Should().NotThrow<Exception>();
            cpfSegundoDigitoVerificador.Numero.Should().Be("69662925830");
            cpfSegundoDigitoVerificador.NumeroComPontuacao.Should().Be("696.629.258-30");
        }



        [Test]
        public void CPF_Infraestrutura_Validar_NumeroInvalido_ExcecaoNumeroCPFInvalido_Falha()
        {
            CPF cpf = new CPF();
            cpf.NumeroComPontuacao = "123.456.789-00";

            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoNumeroCPFInvalido>();
        }

    }
}
