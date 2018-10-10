using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Documentos.CNPJs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Domain.Tests.Funcionalidades.Documentos.CNPJs
{
    [TestFixture]
    public class CNPJTeste
    {
        [Test]
        public void CNPJ_Infraestrutura_Validar_Sucesso()
        {
            Documento cnpj = new Documento("99.327.235/0001-50", TipoDocumento.CNPJ);

            Action resultado = () => cnpj.Validar();

            resultado.Should().NotThrow<Exception>();
            cnpj.Numero.Should().Be("99.327.235/0001-50");
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_NumeroZerado_Falha()
        {
            Documento cnpj = new Documento("00.000.000/0000-00", TipoDocumento.CNPJ);

            Action resultado = () => cnpj.Validar();

            resultado.Should().Throw<ExcecaoNumeroCNPJInvalido>();
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_NumeroPequeno_Falha()
        {
            Documento cnpj = new Documento("35253445", TipoDocumento.CNPJ);
            Action resultado = () => cnpj.Validar();

            resultado.Should().Throw<ExcecaoCNPJNaoPossuiQuatorzeNumeros>();
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_NumeroInvalido_Falha()
        {
            Documento cnpj = new Documento("00.000.000/0000-45", TipoDocumento.CNPJ);

            Action resultado = () => cnpj.Validar();

            resultado.Should().Throw<ExcecaoNumeroCNPJInvalido>();
        }

        [Test]
        public void CNPJ_Infraestrutura_Validar_ObterDigitoVerificador_Sucesso()
        {
            Documento cnpj = new Documento("11.222.333/0001-81", TipoDocumento.CNPJ);

            Action resultado = () => cnpj.Validar();

            resultado.Should().NotThrow<Exception>();
        }
    }
}
