using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TutorialORM.Dominio.Features.Alunos;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Infra.Data.Features.Alunos
{
    public class AlunoRepositorio : RepositorioGenerico<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(EscolaContext context) : base(context)
        {
        }
    }
}
