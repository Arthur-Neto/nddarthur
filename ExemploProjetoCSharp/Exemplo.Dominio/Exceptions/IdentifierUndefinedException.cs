using System;

namespace Exemplo.Dominio.Exceptions {
    public class IdentifierUndefinedException : Exception {
        public IdentifierUndefinedException() : base("Identificador inválido") {
        }
    }
}
