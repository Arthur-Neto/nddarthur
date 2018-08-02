using ProvaTDD.Dominio.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ProvaTDD.Dominio.Features.Avaliacoes
{
    public class AvaliacaoAssuntoVazioException : BusinessException
    {
        public AvaliacaoAssuntoVazioException() : base("Avaliação deve ter um assunto válido")
        {
        }
    }
}