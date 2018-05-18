using Mariana.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.DomainUnitTest
{
    [TestClass]
    public class SerieTest
    {
        Serie serie;

        [TestInitialize]
        public void inicializa()
        {
            serie = new Serie();
            serie.Id = 1;
            serie.NumeroSerie = 1;
        }

        [TestMethod]
        public void CadastraSerie()
        {
            serie = new Serie();
            serie.Id = 1;
            serie.NumeroSerie = 1;

            Assert.IsNotNull(serie);
            Assert.AreEqual(serie.Id, 1);
            Assert.AreEqual(serie.NumeroSerie, 1);
        }

        [TestMethod]
        public void ValidaSerie()
        {
            serie.Validar();

            Assert.IsNotNull(serie);
            Assert.AreEqual(serie.Id, 1);
            Assert.AreEqual(serie.NumeroSerie, 1);
        }

        [TestMethod]
        public void ValidaSerieMenorOuMaiorQueLimite()
        {
            // Arrange
            Exception expectedExcetpion = null;
            serie = new Serie();
            serie.NumeroSerie = 0;

            // Act
            try
            {
                //DominioHelper.ValidarInteiros(1, 9, serie.NumeroSerie);
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, string.Format("O Valor não pode ser menor que {0} ou maior que {1} caracteres", 1, 9));
        }

        [TestMethod]
        public void ValidaSerieVazia()
        {
            // Arrange
            Exception expectedExcetpion = null;
            Serie serieTeste = new Serie();

            // Act
            try
            {
                //DominioHelper.ValidarInteirosVaziosOuZerado(serieTeste.NumeroSerie);
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O Valor não pode ser vazio ou zerado");
        }
    }
}
