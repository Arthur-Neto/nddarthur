using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios
{
    public class DestinatarioRepositorioSql : IDestinatarioRepositorio
    {
        ProjetoNFeContexto _contexto;

        public DestinatarioRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }

        public long Adicionar(Destinatario destinatario)
        {
            destinatario = _contexto.Destinatarios.Add(destinatario);
            _contexto.SaveChanges();

            return destinatario.Id;
        }

        public bool Atualizar(Destinatario destinatario)
        {
            return _contexto.SaveChanges() != 0;
        }

        public Destinatario BuscarPorId(long Id)
        {
            Destinatario destinatario = _contexto.Destinatarios.Find(Id);
            return destinatario;
        }

        public IQueryable<Destinatario> BuscarTodos()
        {
            return _contexto.Destinatarios;
        }

        public bool Excluir(Destinatario destinatario)
        {
            _contexto.Destinatarios.Remove(destinatario);
            return _contexto.SaveChanges() != 0;
        }
    }
}
