using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialORM.Dominio.Features.Turmas;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Infra.Data.Features.Turmas
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        public Turma Atualizar(Turma turma)
        {
            using (var db = new EscolaContext())
            {
                db.Turmas.Attach(turma);
                db.Entry(turma).State = EntityState.Modified;
                db.SaveChanges();
            }
            return turma;
        }

        public void Deletar(Turma turma)
        {
            using (var db = new EscolaContext())
            {
                db.Turmas.Attach(turma);
                db.Turmas.Remove(turma);
                db.SaveChanges();
            }
        }

        public Turma PegarPorId(long id)
        {
            Turma turma;
            using (var db = new EscolaContext())
            {
                turma = db.Turmas.Find(id);
            }
            return turma;
        }

        public IEnumerable<Turma> PegarTodos()
        {
            IEnumerable<Turma> turmas;
            using (var db = new EscolaContext())
            {
                turmas = db.Turmas.ToList();
            }
            return turmas;
        }

        public Turma Salvar(Turma turma)
        {
            using (var db = new EscolaContext()) {
                turma = db.Turmas.Add(turma);
                db.SaveChanges();
            }
            return turma;
        }
    }
}
