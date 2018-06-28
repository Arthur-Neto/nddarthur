using GeradorTestes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeradorTestes.Domain;
using System.Data;
using GeradorTestes.Infra.Database;

namespace GeradorTestes.Infra.SQL
{
    public class QuestaoSqlRepository : IQuestaoRepository
    {
        #region SCRIPTS SQL
        private const string _sqlGetByID = @"Select * from TBQuestoes where MateriaID = {0}MateriaID";

        private const string _sqlInsertTBQuestoes = "INSERT INTO TBQuestoes ([Bimestre],[MateriaID], [Questao]) VALUES ({0}Bimestre,  {0}MateriaID, {0}Questao)";

        private const string _sqlInsertTBAlternativas = "INSERT INTO TBAlternativas (A,B,C,D,AlternativaCorreta, QuestaoID) Values ({0}A,{0}B,{0}C,{0}D,{0}AlternativaCorreta,{0}QuestaoID)";

        private const string _sqlSelectAll = @"    SELECT
            questao.Id as QuestaoID, questao.Bimestre as QuestaoBimestre, questao.MateriaID as QuestaoMateriaID, questao.Questao as Questao,
            materia.Nome as MateriaNome, materia.SerieID as MateriaSerieID, materia.DisciplinaID as MateriaDisciplinaID,
            disciplina.Nome as DisciplinaNome,
            serie.Serie as SerieNome,
			alternativas.A, alternativas.B, alternativas.C, alternativas.D, alternativas.AlternativaCorreta, alternativas.Id as AlternativaID
                from TBQuestoes as questao
            inner join TBMaterias as materia on questao.MateriaID = materia.ID
            inner join TBDisciplinas as disciplina on disciplina.ID = materia.DisciplinaID
            inner join TBSeries as serie on serie.ID = materia.SerieID
			inner join TBAlternativas as alternativas on alternativas.QuestaoID = questao.Id";

        private const string _sqlSelectAllRandom = @"  
                    declare @table1 TABLE(temp int )
                    insert into @table1 (temp) values ({0}Quantidade)
                SELECT top (select temp from @table1)
            questao.Id as QuestaoID, questao.Bimestre as QuestaoBimestre, questao.MateriaID as QuestaoMateriaID, questao.Questao as Questao,
            materia.Nome as MateriaNome, materia.SerieID as MateriaSerieID, materia.DisciplinaID as MateriaDisciplinaID,
            disciplina.Nome as DisciplinaNome,
            serie.Serie as SerieNome,
			alternativas.A, alternativas.B, alternativas.C, alternativas.D, alternativas.AlternativaCorreta, alternativas.Id as AlternativaID
                from TBQuestoes as questao
            inner join TBMaterias as materia on questao.MateriaID = materia.ID
            inner join TBDisciplinas as disciplina on disciplina.ID = materia.DisciplinaID
            inner join TBSeries as serie on serie.ID = materia.SerieID
			inner join TBAlternativas as alternativas on alternativas.QuestaoID = questao.Id
           WHERE materia.Nome = {0}MateriaNome	and Bimestre = {0}Bimestre
             order by NEWID()";

        private const string _sqlDeleteTBQuestoes = "DELETE FROM TBQuestoes where ID = {0}ID";

        private const string _sqlDeleteTBAlternativas = "DELETE FROM TBAlternativas where QuestaoID = {0}QuestaoID";

        private const string _sqlUpdateTBQuestoes = @"UPDATE TBQuestoes SET Bimestre = {0}Bimestre, MateriaID = {0}MateriaID, Questao = {0}Questao WHERE ID = {0}ID";

        private const string _sqlUpdateTBAlternativas = @"UPDATE TBAlternativas SET A = {0}A, B = {0}B, C = {0}C, D = {0}D, AlternativaCorreta = {0}AlternativaCorreta, QuestaoID = {0}QuestaoID WHERE ID = {0}ID";

        #endregion

        public Questao Add(Questao entidade)
        {
            entidade.ID = Db.Insert(_sqlInsertTBQuestoes, Take(entidade));
            entidade.Alternativa.ID = Db.Insert(_sqlInsertTBAlternativas, TakeTBQAlternativas(entidade));
            return entidade;
        }

        public void Delete(Questao entidade)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "QuestaoID", entidade.ID } };
            Db.Delete(_sqlDeleteTBAlternativas, parms);

            parms = new Dictionary<string, object> { { "ID", entidade.ID } };
            Db.Delete(_sqlDeleteTBQuestoes, parms);
        }

        public IList<Questao> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }

        public IList<Questao> GetAllRandom(Teste teste, Materia materia, Questao questao)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Quantidade", teste.QuantidadeQuestoes }, { "MateriaNome", materia.Nome }, { "Bimestre", questao.Bimestre } };

            return Db.GetAll(_sqlSelectAllRandom, Make, parms);
        }

        public bool GetByID(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "MateriaID", id } };

            Questao q = Db.Get<Questao>(_sqlGetByID, MakeQustoes, parms);

            if (q == null)
                return true;

            return false;
        }

        public Questao Make(IDataReader reader)
        {
            Questao questao = new Questao();

            questao.ID = Convert.ToInt32(reader["QuestaoID"]);
            questao.Bimestre = Convert.ToString(reader["QuestaoBimestre"]);
            questao.Pergunta = Convert.ToString(reader["Questao"]);
            questao.materia = new Materia
            {
                ID = Convert.ToInt32(reader["QuestaoMateriaID"]),
                Nome = Convert.ToString(reader["MateriaNome"]),
                disciplina = new Disciplina
                {
                    ID = Convert.ToInt32(reader["MateriaDisciplinaID"]),
                    Nome = Convert.ToString(reader["DisciplinaNome"]),

                },
                serie = new Serie
                {
                    ID = Convert.ToInt32(reader["MateriaSerieID"]),
                    Nome = Convert.ToString(reader["SerieNome"])
                }

            };
            questao.Alternativa = new Alternativas
            {
                ID = Convert.ToInt32(reader["AlternativaID"]),
                A = Convert.ToString(reader["A"]),
                B = Convert.ToString(reader["B"]),
                C = Convert.ToString(reader["C"]),
                D = Convert.ToString(reader["D"]),
                Correta = Convert.ToString(reader["AlternativaCorreta"])

            };

            return questao;
        }

        public Questao MakeQustoes(IDataReader reader)
        {
            Questao questao = new Questao();

            questao.ID = Convert.ToInt32(reader["ID"]);
            questao.Bimestre = Convert.ToString(reader["Bimestre"]);
            questao.Pergunta = Convert.ToString(reader["Questao"]);
            questao.materia = new Materia
            {
                ID = Convert.ToInt32(reader["MateriaID"]),
            };

            return questao;
        }

        public Dictionary<string, object> Take(Questao entidade)
        {
            return new Dictionary<string, object>
            {
                { "ID", entidade.ID },
                { "Bimestre", entidade.Bimestre },
                { "MateriaID", entidade.materia.ID},
                { "Questao", entidade.Pergunta }
            };
        }

        public Dictionary<string, object> TakeTBQAlternativas(Questao questao)
        {
            return new Dictionary<string, object>
            {
                { "ID", questao.Alternativa.ID},
                { "A", questao.Alternativa.A},
                { "B", questao.Alternativa.B},
                { "C", questao.Alternativa.C},
                { "D", questao.Alternativa.D},
                { "AlternativaCorreta", questao.Alternativa.Correta},
                { "QuestaoID", questao.ID }
            };
        }

        public void Update(Questao entidade)
        {
            Db.Update(_sqlUpdateTBQuestoes, Take(entidade));
            Db.Update(_sqlUpdateTBAlternativas, TakeTBQAlternativas(entidade));
        }
    }
}
