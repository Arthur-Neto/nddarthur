using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Infrastructure.Objetos_de_Valor.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Tests.Objetos_de_Valor
{
    [TestFixture]
    public class CNPJTeste
    {
        [Test]
        public void CNPJ_Infraestrutura_Validar_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "99.327.235/0001-50";

            Action resultado = () => cnpj.Validar();

            resultado.Should().NotThrow<Exception>();
            cnpj.Numero.Should().Be("99327235000150");
            cnpj.NumeroComPontuacao.Should().Be("99.327.235/0001-50");
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_NumeroZerado_Falha()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "00.000.000/0000-00";

            Action resultado = () => cnpj.Validar();

            resultado.Should().Throw<ExcecaoNumeroCNPJInvalido>();
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_NumeroPequeno_Falha()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "35253445";
            Action resultado = () => cnpj.Validar();

            resultado.Should().Throw<ExcecaoCNPJNaoPossuiQuatorzeNumeros>();
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_NumeroInvalido_Falha()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "00.000.000/0000-45";

            Action resultado = () => cnpj.Validar();

            resultado.Should().Throw<ExcecaoNumeroCNPJInvalido>();
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_ObterDigitoVerificador_Sucesso()
        {
            CNPJ cnpj = new CNPJ();
            cnpj.NumeroComPontuacao = "11.222.333/0001-81";

            Action resultado = () => cnpj.Validar();

            resultado.Should().NotThrow<Exception>();
        }
    }
}
