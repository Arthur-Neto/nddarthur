using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeradorTestes.Domain;

namespace UnitTest.Domain_Test
{
    [TestClass]
    public class UnitTestMateria
    {
        Materia _materia = new Materia();

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "A Disciplina não pode ser nula")]
        public void TestDisciplinaNula()
        {
            _materia.disciplina = null;
            _materia.Valida();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "A série não pode ser nula")]
        public void TestSerieNula()
        {
            _materia.serie = null;
            _materia.Valida();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "O nome da Matéria não pode ser em branco")]
        public void TestNomeMateriaEmBranco()
        {
            _materia.Nome = " ";
            _materia.Valida();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "O nome da Matéria não pode conter mais que 25 caracteres")]
        public void TestNomeMateriaMaior25Chars()
        {
            _materia.Nome = "asdfghjklzxcvbnmqwertyasdasdasduio";
            _materia.Valida();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "O nome da Matéria não pode conter menos que 4 caracteres")]
        public void TestNomeMateriaMenor4Chars()
        {
            _materia.Nome = "aaa";
            _materia.Valida();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "O nome da Matéria não pode conter números, favor utilizar algarismos romanos.")]
        public void TestNomeMateriaComNumeros()
        {
            _materia.Nome = "aaa1";
            _materia.Valida();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Nome da disciplina não pode conter caracteres especiais")]
        public void TestNomeMateriaCharsEspeciais()
        {
            _materia.Nome = "aaa@";
            _materia.Valida();
        }
    }
}
