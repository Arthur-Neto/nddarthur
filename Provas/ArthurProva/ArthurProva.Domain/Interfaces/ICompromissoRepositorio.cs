using System.Collections.Generic;

namespace ArthurProva.Domain.Interfaces
{
    public interface ICompromissoRepositorio : IRepositorio<Compromisso>
    {
        void AdicionarCompromissoContato(Compromisso compromisso);
    }
}
