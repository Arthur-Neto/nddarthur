using Mariana.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MateriaUnitTest
{
    [TestClass]
    public class MateriaTest
    {
        Materia materia;
        Serie serie;
        Disciplina disciplina;

        [TestInitialize]
        public void inicializa()
        {
            serie = new Serie();
            serie.Id = 1;
            serie.NumeroSerie = 1;

            disciplina = new Disciplina();
            disciplina.Nome = "Matemática";

            materia = new Materia();
            materia.Id = 1;
            materia.Nome = "Adição";
            materia.Disciplina = disciplina;
            materia.Serie = serie;
        }

        [TestMethod]
        public void CadastraMateria()
        {
            materia = new Materia();
            materia.Id = 1;
            materia.Nome = "Adição";
            materia.Disciplina = disciplina;
            materia.Serie = serie;

            Assert.IsNotNull(materia);
            Assert.AreEqual(materia.Id, 1);
            Assert.AreEqual(materia.Nome, "Adição");
        }

        [TestMethod]
        public void ValidaMateria()
        {
            materia.Validar();

            Assert.IsNotNull(materia);
            Assert.AreEqual(materia.Id, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValidaNomeVazio()
        {
            materia = new Materia();

            materia.Nome = "";
            materia.Validar();
            Assert.IsTrue(string.IsNullOrWhiteSpace(materia.Nome), "O Nome não pode ser vazio");
        }

        [TestMethod]
        public void ValidaNomeMenorTresCaracteres()
        {
            // Arrange
            Exception expectedExcetpion = null;
            materia = new Materia();
            materia.Nome = "ma";

            // Act
            try
            {
                //DominioHelper.ValidarEspaçoVazioETamanho(materia.Nome);
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "O nome não pode ser menor que 3 ou maior que 30 caracteres");
        }

        [TestMethod]
        public void ValidaSerieVazia()
        {
            // Arrange
            Exception expectedExcetpion = null;
            Materia materiaTeste = new Materia();
            materiaTeste.Nome = "materia";
            materiaTeste.Disciplina = disciplina;

            // Act
            try
            {
                //DominioHelper.ValidarDisciplinaSerieMateria(materiaTeste.Disciplina, materiaTeste.Serie);
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "Deve selecionar uma Série");
        }

        [TestMethod]
        public void ValidaDisciplinaVazia()
        {
            // Arrange
            Exception expectedExcetpion = null;
            Materia materiaTeste = new Materia();
            materiaTeste.Nome = "materia";
            materiaTeste.Serie = serie;
            
            // Act
            try
            {
                //DominioHelper.ValidarDisciplinaSerieMateria(materiaTeste.Disciplina, materiaTeste.Serie);
            }
            catch (Exception e)
            {
                expectedExcetpion = e;
            }

            // Assert
            Assert.AreEqual(expectedExcetpion.Message, "Deve selecionar uma Disciplina");
        }

    }
}

