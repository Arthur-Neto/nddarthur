using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Infrastructure.Data.Base;
using System.Linq;

namespace Projeto_NFe.Infrastructure.Data.Funcionalidades.Emitentes
{
    public class EmitenteRepositorioSql : IEmitenteRepositorio
    {
        ProjetoNFeContexto _contexto;
        public EmitenteRepositorioSql(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }
        public long Adicionar(Emitente emitente)
        {
            emitente = _contexto.Emitentes.Add(emitente);
            _contexto.SaveChanges();

            return emitente.Id;
        }

        public bool Atualizar(Emitente emitente)
        {
            return _contexto.SaveChanges() != 0;
        }

        public Emitente BuscarPorId(long Id)
        {
            Emitente emitente = _contexto.Emitentes.Find(Id);

            return emitente;
        }

        public IQueryable<Emitente> BuscarTodos()
        {
            return _contexto.Emitentes;
        }

        public bool Excluir(Emitente emitente)
        {
            _contexto.Emitentes.Remove(emitente);
            return _contexto.SaveChanges() != 0;
        }
    }
}
