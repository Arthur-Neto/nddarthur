using Mariana.Dominio.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Mariana.Dominio
{
    public class Resposta : Entidade
    {
        public string CorpoResposta { get; set; }
        public bool Correta { get; set; }

        public override string ToString()
        {
            return String.Format("Resposta: {0} | Correta: {1}", CorpoResposta, Correta ? "Sim" : "Não");
        }

        public override void Validar()
        {
            if (CorpoResposta.Length > 50)
                throw new ValidacaoException("A resposta não pode conter mais que 50 caracteres.");

            if (string.IsNullOrWhiteSpace(CorpoResposta))
                throw new ValidacaoException("A resposta não pode estar vazio.");

            if (Regex.IsMatch(CorpoResposta, @"\s{2,}"))
            {
                throw new ValidacaoException("A Resposta não deve conter espaços em branco.");
            }
        }
    }
}
