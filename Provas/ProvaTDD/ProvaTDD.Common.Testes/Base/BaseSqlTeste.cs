using ProvaTDD.Infra;

namespace ProvaTDD.Common.Testes.Base
{
    public static class BaseSqlTeste
    {
        private const string DELETE_ALUNO_TABLE = "DELETE FROM [dbo].[TBAluno] DBCC CHECKIDENT('[dbo].[TBAluno]', RESEED, 0)";
        private const string INSERT_ALUNO = "INSERT INTO TBAluno(Nome, Media, Idade) VALUES ('Fulano', 6, 20)";

        public static void SeedDatabase()
        {
            Db.Update(DELETE_ALUNO_TABLE);

            Db.Update(INSERT_ALUNO);
        }
    }
}
