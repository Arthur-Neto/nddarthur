using Mariana.Dominio.Exceptions.Disciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mariana.Dominio.Utils
{
    public class DominioHelper
    {
        public static void ValidarNomeSemNumero(String nome)
        {
            if (!Regex.IsMatch(nome, @"^[a-zA-Z_áéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕ\s]*$"))
            {
                throw new Exception("O nome não pode ser somente números e caracteres especiais");
            }

        }

        public static void ValidarNomeComNumero(String nome)
        {
            if (Regex.IsMatch(nome, @"^[!@#$%¨&]*$"))
            {
                throw new Exception("O nome não pode ser somente números e caracteres especiais");
            }
            else
            {
                if (!Regex.IsMatch(nome, @"^[a-zA-Z_áéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕ\s]*$"))
                {
                    if (Regex.IsMatch(nome, @"^\d+"))
                        throw new Exception("O nome não pode ser somente números e caracteres especiais");
                }
            }
        }

        public static void ValidarEspaçoVazioETamanho(String nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome == "")
            {
                throw new Exception("O nome não pode ser vazio");
            }
            if ((nome.Length < 3) || (nome.Length > 30))
            {
                throw new Exception("O nome não pode ser menor que 3 ou maior que 30 caracteres");
            }
        }

        public static void ValidarRespostaVazio(String nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome == "")
            {
                throw new Exception("O nome não pode ser vazio");
            }
        }

        public static void ValidarResposta(String resposta)
        {
            if (Regex.IsMatch(resposta, @"\s{2,}"))
                throw new Exception("Resposta não deve conter espaços em branco");
        }
        public static void ValidarEnunciado(String enunciado)
        {
            if (string.IsNullOrWhiteSpace(enunciado) || enunciado == "")
            {
                throw new Exception("O enunciado não pode ser vazio");
            }
            if ((enunciado.Length < 10) || (enunciado.Length > 500))
            {
                throw new Exception("O enunciado não pode ser menor que 10 ou maior que 500 caracteres");
            }
        }

        public static string FormatarNome(String nome)
        {
            nome = char.ToUpper(nome[0]) + nome.Substring(1);
            return nome;
        }

        public static void ValidarDisciplinaSerieMateria(Disciplina disciplina, Serie serie, Materia materia = null)
        {
            if (serie.Id == 0 && serie.NumeroSerie == 0)
                throw new Exception("Deve selecionar uma Série");

            if (disciplina.Id == 0)
                throw new Exception("Deve selecionar uma Disciplina");

            if (materia != null)
            {
                if (materia.Id == 0)
                    throw new Exception("Deve selecionar uma Materia");
            }

        }

        public static void ValidarInteiros(int inicio, int fim, int valor)
        {
            if ((valor < inicio) || (valor > fim))
            {
                throw new Exception(string.Format("O Valor não pode ser menor que {0} ou maior que {1} caracteres", inicio, fim));
            }
        }

        public static void ValidarInteirosVaziosOuZerado(int valor)
        {
            if (valor == 0 || valor.ToString() == "")
            {
                throw new Exception("O Valor não pode ser vazio ou zerado");
            }
        }

        public static void ValidarQuestoesMaiorNumeroInformado(int questoes, int numeroInformado)
        {
            if (questoes < numeroInformado)
            {
                throw new Exception("A quantidade de questões é menor que valor informado");
            }
        }

        public static void ValidarListaRespostas(IList<Resposta> respostas)
        {
            if (respostas.Count < 2)
            {
                throw new ListaVaziaException("A lista de respostas deve conter pelo menos duas respostas.");
            }

            if(respostas.Count > 6)
            {
                throw new ListaVaziaException("A lista de respostas não deve ser maior do que seis respostas.");
            }

            int count = 0;
            foreach (var item in respostas)
            {
                if (item.Correta == true)
                    count++;
            }
            if (count != 1)
                throw new Exception(String.Format("Deve cadastrar somente uma resposta correta."));
        }
        
    }
}
