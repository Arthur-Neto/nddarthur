using Mariana.Dominio.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Mariana.Dominio
{
    public class Disciplina : Entidade
    {
        public string Nome { get; set; }

        public override string ToString()
        {
            return String.Format("Nome: {0}", Nome);
        }

        public override void Validar()
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new ValidacaoException("O nome da disciplina deve ser informado.");
            }
            else if (Nome.Length < 4)
            {
                throw new ValidacaoException("O nome da disciplina deve ter pelo menos 4 caracteres.");
            }
            else if (Nome.Length > 25)
            {
                throw new ValidacaoException("O nome da disciplina deve ter no máximo 25 caracteres.");
            }
            else if (!Regex.IsMatch(Nome, @"^[A-Za-z ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+$"))
            {
                throw new ValidacaoException("O nome da disciplina deve conter apenas letras e espaços.");
            }
        }
    }
}