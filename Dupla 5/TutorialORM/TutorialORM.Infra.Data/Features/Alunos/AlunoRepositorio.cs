using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Dominio.Features.Alunos;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Infra.Data.Features.Alunos
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        public Aluno Atualizar(Aluno aluno)
        {
            using (var db = new EscolaContext())
            {
                db.Alunos.Attach(aluno);
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
            }
            return aluno;
        }

        public void Deletar(Aluno aluno)
        {
            using (var db = new EscolaContext())
            {
                db.Alunos.Attach(aluno);
                db.Alunos.Remove(aluno);
                db.SaveChanges();
            }
        }

        public Aluno PegarPorId(long id)
        {
            Aluno aluno;
            using (var db = new EscolaContext())
            {
                aluno = db.Alunos.Find(id);
            }
            return aluno;
        }

        public IEnumerable<Aluno> PegarTodos()
        {
            IEnumerable<Aluno> alunos;
            using (var db = new EscolaContext())
            {
                alunos = db.Alunos.ToList();
            }
            return alunos;
        }

        public Aluno Salvar(Aluno aluno)
        {
            using (var db = new EscolaContext())
            {
                aluno = db.Alunos.Add(aluno);
                db.SaveChanges();
            }
            return aluno;
        }
    }
}
