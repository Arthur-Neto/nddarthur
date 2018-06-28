using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeradorTestes.Domain;

namespace UnitTest.Domain_Test
{
    [TestClass]
    public class UnitTestSerie
    {
        Serie _serie = new Serie();

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Digite um número valido para a série")]
        public void TestSerieEmBranco()
        {
            _serie.Nome = "  ªSérie";
            _serie.Validacao();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Digite um número valido para a série")]
        public void TestSerieZerada()
        {
            _serie.Nome = "0 ªSérie";
            _serie.Validacao();
        }
    }
}
