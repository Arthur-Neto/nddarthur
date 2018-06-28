using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeradorTestes.Domain;

namespace UnitTest
{
    [TestClass]
    public class UnitTestDisciplina
    {
        Disciplina _disc = new Disciplina();
        [TestMethod]
        [ExpectedException(typeof(Exception),
     "O nome da Disciplina não pode ser em branco")]
        public void TestNomeEmBranco()
        {            
            _disc.Nome = "";
            _disc.Validacao();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
    "O nome da Disciplina deve ter mais que 4 caracteres")]
        public void TestNomeMenorQue4()
        {            
            _disc.Nome = "asd";
            _disc.Validacao();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
    "O nome da Disciplina deve ser menor que 25 caracteres")]
        public void TestNomeMaiorQue25()
        {
            _disc.Nome = "asdfghjklzxcvbnmqwertyasdasdasduio";
            _disc.Validacao();
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Nome não pode conter números!")]
        public void TestNomeTemNumero()
        {
            _disc.Nome = "Mat1e1m1át2ic3a";
            _disc.Validacao();            
        }
        [TestMethod]
        [ExpectedException(typeof(Exception),
    "Nome da disciplina não pode conter caracters especiais!")]
        public void TestNomeCaracterEspecial()
        {
            _disc.Nome = "M@tem@tic@";
            _disc.Validacao();
        }
    }
}
