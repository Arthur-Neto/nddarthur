using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CPFs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Documentos.CPFs
{
    [TestFixture]
    public class CPFTeste
    {
        [Test]
        public void CPF_Dominio_Validar_Sucesso()
        {
            Documento cpf = new Documento("111.444.777-35", TipoDocumento.CPF);

            Action resultado = () => cpf.Validar();

            resultado.Should().NotThrow<Exception>();
            cpf.Numero.Should().Be("111.444.777-35");
        }

        [Test]
        public void CPF_Dominio_Validar_NumeroZerado_ExcecaoNumeroCPFInvalido_Falha()
        {
            Documento cpf = new Documento("000.000.000-00", TipoDocumento.CPF);

            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoNumeroCPFInvalido>();
        }

        [Test]
        public void CPF_Dominio_Validar_NumeroPequeno_ExcecaoCPFNaoPossuiOnzeNumeros_Falha()
        {
            Documento cpf = new Documento("000.000-00", TipoDocumento.CPF);
            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoCPFNaoPossuiOnzeNumeros>();
        }

        [Test]
        public void CPF_Dominio_Validar_NumeroGrande_ExcecaoCPFNaoPossuiOnzeNumeros_Falha()
        {
            Documento cpf = new Documento("000.000.000.000-00", TipoDocumento.CPF);
            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoCPFNaoPossuiOnzeNumeros>();
        }

        [Test]
        public void CPF_Dominio_Validar_PrimeiroDigitoVerificador_Sucesso()
        {
            Documento cpfPrimeiroDigitoVerificador = new Documento("867.513.141-08", TipoDocumento.CPF);

            Action resultadoPrimeiroDigitoVerificador = () => cpfPrimeiroDigitoVerificador.Validar();

            resultadoPrimeiroDigitoVerificador.Should().NotThrow<Exception>();
            cpfPrimeiroDigitoVerificador.Numero.Should().Be("867.513.141-08");
        }

        [Test]
        public void CPF_Dominio_Validar_SegundoDigitoVerificador_Sucesso()
        {
            Documento cpfSegundoDigitoVerificador = new Documento("696.629.258-30", TipoDocumento.CPF);

            Action resultadoSegundoDigitoVerificador = () => cpfSegundoDigitoVerificador.Validar();

            resultadoSegundoDigitoVerificador.Should().NotThrow<Exception>();
            cpfSegundoDigitoVerificador.Numero.Should().Be("696.629.258-30");
        }



        [Test]
        public void CPF_Dominio_Validar_NumeroInvalido_ExcecaoNumeroCPFInvalido_Falha()
        {
            Documento cpf = new Documento("123.456.789-00", TipoDocumento.CPF);

            Action resultado = () => cpf.Validar();

            resultado.Should().Throw<ExcecaoNumeroCPFInvalido>();
        }

    }
}
