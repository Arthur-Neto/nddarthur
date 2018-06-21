using TutorialORM.Infra.Data.Base;

namespace TutorialORM.Common.Testes.Base
{
    public static class BaseSqlTestes
    {
        public static void SeedDatabase(EscolaContext escolaContext)
        {
            escolaContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('TBAluno', RESEED, 0)");
            escolaContext.Database.ExecuteSqlCommand("DELETE FROM TBAluno");

            escolaContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('TBTurma', RESEED, 0)");
            escolaContext.Database.ExecuteSqlCommand("DELETE FROM TBTurma");

            escolaContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('TBEndereco', RESEED, 0)");
            escolaContext.Database.ExecuteSqlCommand("DELETE FROM TBEndereco");
        }
    }
}
