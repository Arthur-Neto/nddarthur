using System;
using System.Diagnostics.CodeAnalysis;

namespace NFe.Dominio.Features.Destinatarios
{
    [ExcludeFromCodeCoverage]
    public class DestinatarioEmptyRazaoNomeException : Exception
    {
        public DestinatarioEmptyRazaoNomeException() : base("Destinatario com razao social ou nome vazios")
        {
        }
    }
}