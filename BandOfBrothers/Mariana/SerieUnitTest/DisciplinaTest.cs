using Mariana.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SerieUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Disciplina disciplina;

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DeveValidarNomeEmBrancoDisciplinaException()
        {
            disciplina = new Disciplina();

            disciplina.Nome = "";
            //DominioHelper.ValidarEspaçoVazioETamanho(disciplina.Nome);
            Assert.IsTrue(string.IsNullOrWhiteSpace(disciplina.Nome), "O Nome não pode ser vazio");
        }

        [TestMethod]
        public void DeveValidarNomeEmBrancoDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "";

            // Act
            try
            {
                //DominioHelper.ValidarEspaçoVazioETamanho(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser vazio");
        }

        [TestMethod]
        public void ValidaNomeMenorTresCaracteresDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "ma";

            // Act
            try
            {
                //DominioHelper.ValidarEspaçoVazioETamanho(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser menor que 3 ou maior que 30 caracteres");
        }

        [TestMethod]
        public void ValidaNomeMaiorTrintaCaracteresDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "matematicazinhalegalhahahahahaasasasasas";

            // Act
            try
            {
                //.ValidarEspaçoVazioETamanho(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser menor que 3 ou maior que 30 caracteres");
        }
        [TestMethod]
        public void ValidaNumeroAntesDoNomeDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "1 mat";

            // Act
            try
            {
                //DominioHelper.ValidarNomeComNumero(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser somente números e caracteres especiais");
        }

        [TestMethod]
        public void ValidaNumeroDepoisDoNomeDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "matemática 2";

            // Act
            try
            {
                //DominioHelper.ValidarNomeComNumero(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.IsNull(expectedExcetpion);
        }

        [TestMethod]
        public void ValidarNomeSemNumeroDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "matemática 2";

            // Act
            try
            {
               // DominioHelper.ValidarNomeSemNumero(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser somente números e caracteres especiais");
        }

        [TestMethod]
        public void DeveFormatarPrimeiraLetraNomeDisciplina()
        {
            // Arrange
            disciplina = new Disciplina();
            disciplina.Nome = "matemática 2";

            // Act
           // disciplina.Nome = DominioHelper.FormatarNome(disciplina.Nome);

            // Assert
            Assert.AreEqual(disciplina.Nome, "Matemática 2");
        }

        [TestMethod]
        public void ValidarNomeComCaractereEspecialDisciplina()
        {
            // Arrange
            Exception expectedExcetpion = null;
            disciplina = new Disciplina();
            disciplina.Nome = "!@#$";

            // Act
            try
            {
               // DominioHelper.ValidarNomeComNumero(disciplina.Nome);

            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser somente números e caracteres especiais");
        }

    }
}
