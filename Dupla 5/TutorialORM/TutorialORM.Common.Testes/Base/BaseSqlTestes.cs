using System.Data.Entity;
using TutorialORM.Common.Testes.Features;
using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Common.Testes.Base
{
    public class BaseSqlTestes : DropCreateDatabaseAlways<EscolaContext>
    {
        protected override void Seed(EscolaContext context)
        {
            context.Alunos.Add(ObjectMother.ObterAlunoValido());
            context.Enderecos.Add(ObjectMother.ObterEnderecoValido());
            context.Turmas.Add(ObjectMother.ObterTurmaValida());
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
