using System.Collections.Generic;

namespace ArthurProva.Domain.Interfaces
{
    public interface IContatoRepositorio : IRepositorio<Contato>
    {
        IList<Contato> ConsultarPorNome(string nome);

        IList<Contato> ConsultarPorNomeEId(string nome, int id);

        IList<Contato> BuscarContatosPorIdCompromisso(int id);

        IList<Contato> BuscarContatosLinkados(int id);
    }
}
