using System;

namespace Arthur.ORM.Dominio.Exceptions {
    public class IdentifierUndefinedException : Exception {
        public IdentifierUndefinedException() : base("Identificador inválido") {
        }
    }
}
