using Loterica.Infra;
using System.Diagnostics.CodeAnalysis;

namespace Loterica.Common.Tests.Base
{
    [ExcludeFromCodeCoverage]
    public static class BaseSqlTest
    {
        private const string DELETE_CONSTRAINTS_APOSTA = "ALTER TABLE Aposta DROP CONSTRAINT FK_Aposta_Concurso; ALTER TABLE Aposta DROP CONSTRAINT FK_Aposta_Bolao";
        private const string DELETE_CONSTRAINTS_FATURAMENTO = "ALTER TABLE Faturamento DROP CONSTRAINT FK_Faturamento_Concurso";
        private const string RECREATE_APOSTA_TABLE = "TRUNCATE TABLE [dbo].[Aposta] ";
        private const string RECREATE_BOLAO_TABLE = "TRUNCATE TABLE [dbo].[Bolao] ";
        private const string RECREATE_CONCURSO_TABLE = "TRUNCATE TABLE [dbo].[Concurso] ";
        private const string RECREATE_FATURAMENTO_TABLE = "TRUNCATE TABLE [dbo].[Faturamento] ";
        private const string RECREATE_RESULTADO_TABLE = "TRUNCATE TABLE [dbo].[Resultado] ";
        private const string RECREATE_CONSTRAINTS_APOSTA = "ALTER TABLE Aposta ADD CONSTRAINT [FK_Aposta_Concurso] FOREIGN KEY ([IdConcurso]) REFERENCES [Concurso]([Id]), " +
                                                                                  "CONSTRAINT [FK_Aposta_Bolao] FOREIGN KEY ([IdBolao]) REFERENCES [Bolao]([Id]) ";
        private const string RECREATE_CONSTRAINTS_FATURAMENTO = "ALTER TABLE Faturamento ADD CONSTRAINT [FK_Faturamento_Concurso] FOREIGN KEY ([IdConcurso]) REFERENCES [Concurso]([Id])";

        private const string INSERT_APOSTA = "INSERT INTO Aposta(Numeros, Data, IdConcurso, Validade, Valor, IdBolao) VALUES ('01,02,03,04,05,06', GETDATE(), 1, GETDATE(), 3, 1)";
        private const string INSERT_BOLAO = "INSERT INTO Bolao DEFAULT VALUES";
        private const string INSERT_CONCURSO = "INSERT INTO Concurso (Data, IsFechado, Premio, IdResultado, GanhadoresQuadra, GanhadoresQuina, GanhadoresSena, PremioQuadra, PremioQuina, PremioSena) VALUES (GETDATE(), 0, 1000, 1, 0, 2, 1, 0, 100, 1000)";
        private const string INSERT_FATURAMENTO = "INSERT INTO Faturamento (IdConcurso, ValorGanho) VALUES (1, 1000)";
        private const string INSERT_RESULTADO = "INSERT INTO Resultado (NumerosSorteados, MediaQuadra, MediaQuina, MediaSena) VALUES ('01,02,03,04,05,06', 0, 0, 0)";

        public static void SeedDatabase()
        {
            Db.Update(DELETE_CONSTRAINTS_APOSTA);
            Db.Update(DELETE_CONSTRAINTS_FATURAMENTO);
            Db.Update(RECREATE_CONCURSO_TABLE);
            Db.Update(RECREATE_BOLAO_TABLE);
            Db.Update(RECREATE_APOSTA_TABLE);
            Db.Update(RECREATE_FATURAMENTO_TABLE);
            Db.Update(RECREATE_RESULTADO_TABLE);
            Db.Update(RECREATE_CONSTRAINTS_APOSTA);
            Db.Update(RECREATE_CONSTRAINTS_FATURAMENTO);
            
            Db.Update(INSERT_RESULTADO);
            Db.Update(INSERT_CONCURSO);
            Db.Update(INSERT_BOLAO);
            Db.Update(INSERT_APOSTA);
            Db.Update(INSERT_FATURAMENTO);
        }

    }
}
