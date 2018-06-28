using GeradorTestes.Domain;
using GeradorTestes.Infra.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorTestes.Infra
{
    public class TesteDAO
    {

        #region Scripts SQL
        private const string _sqlGetByQuestion = @"select * from TBTestes_Questoes where QuestaoID = {0}QuestaoID";

        private const string _sqlInsertTBTestes = @"INSERT INTO [TBTestes](
                                                   [DataGeracao]
                                                  ,[Descricao]
                                                  ,[QuantidadeQuestoes])
                                                VALUES                                                
                                                    ({0}DataGeracao
                                                    ,{0}Descricao
                                                    ,{0}QuantidadeQuestoes)";

        private const string _sqlInsertTBTestesQuestoes = @"INSERT INTO [TBTestes_Questoes] (
                                                   [QuestaoID]
                                                  ,[TesteID])
                                                VALUES                                                
                                                    ({0}QuestaoID
                                                    ,{0}TesteID)";

        private const string _sqlSelectAll = "SELECT * FROM TBTestes order by dataGeracao desc";
        private const string _sqlSelectAllComQuestoes = @"select  TesteQuestao.Id as testesquestaoID,
testes.Descricao as Descricao, testes.DataGeracao as dataGeracao, testes.QuantidadeQuestoes as QuantidadeQuestoes, testes.Id as TesteID,  
questoes.Bimestre as Bimestre, questoes.MateriaID as materiaID from TBTestes as testes
inner join TBTestes_Questoes as testeQuestao on testeQuestao.TesteID = testes.Id
inner join TBQuestoes as questoes on questoes.Id = TesteQuestao.QuestaoID
";
        private const string _sqlDeleteTBQuestoesTeste = "DELETE FROM TBTestes_Questoes WHERE TesteID = {0}TesteID";

        private const string _sqlDeleteTBTestes = "DELETE FROM TBTestes WHERE Id = {0}ID";

        private const string _sqlGetAllQuestoes = @"SELECT questoes.Questao as nomeQuestao, alternativas.A as alternativaA, alternativas.B as alternativaB,
	alternativas.C as alternativaC, alternativas.D as alternativaD, alternativas.AlternativaCorreta as alternativaCorreta,
	questoes.Bimestre as bimestre,
	materias.Nome as nomeMateria, disciplinas.Nome as disciplinaNome, series.Serie as serieNome
	from TBTestes_Questoes as testeQuestoes
	inner join TBQuestoes as questoes on questoes.Id = testeQuestoes.QuestaoID
	inner join TBAlternativas as alternativas on alternativas.QuestaoID = questoes.Id
	inner join TBMaterias as materias on materias.ID = questoes.MateriaID
	inner join TBSeries as series on series.ID = materias.SerieID
	inner join TBDisciplinas as disciplinas on disciplinas.ID = materias.DisciplinaID
	where Bimestre = {0}Bimestre and MateriaID = {0}MateriaID";

        private const string _sqlSelectQuestoes = @"select questoes.Questao as Questao, questoes.Bimestre as Bimestre,
 alternativas.A as A, alternativas.B as B, alternativas.C as C, alternativas.D as D, alternativas.AlternativaCorreta as Correta,
 materias.Nome as MateriaNome, disciplina.Nome as DisciplinaNome, Serie.Serie as Serie
 from TBTestes_Questoes  as TesteQuestao
inner join TBQuestoes as questoes on questoes.Id = TesteQuestao.QuestaoID
inner join TBAlternativas as alternativas on questoes.Id = alternativas.QuestaoID
inner join TBMaterias as materias on materias.ID = questoes.MateriaID
inner join TBSeries as serie on serie.ID = materias.SerieID
inner join TBDisciplinas as disciplina on disciplina.ID = materias.DisciplinaID
where TesteID = {0}TesteID ";

        #endregion
        public IList<Teste> GetAll()
        {
            return Db.GetAll(_sqlSelectAll, Make);
        }

        public IList<Teste> GetTestes(Teste teste)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "Bimestre", teste.listaQuestao[0].Bimestre }, { "MateriaID", teste.listaQuestao[0].materia.ID } };
            return Db.GetAll(_sqlGetAllQuestoes, MakeTesteQuestoes, parms);
        }
        public IList<Questao> GetQuestoes(Teste teste)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "TesteID", teste.ID } };
            return Db.GetAll<Questao>(_sqlSelectQuestoes, MakeQuestoes, parms);
        }
        private static Func<IDataReader, Teste> Make = reader =>
         new Teste
         {
             ID = Convert.ToInt32(reader["ID"]),
             Descricao = Convert.ToString(reader["Descricao"]),
             dataGeracao = Convert.ToDateTime(reader["DataGeracao"]),
             QuantidadeQuestoes = Convert.ToInt32(reader["QuantidadeQuestoes"]),

         };
        private static Func<IDataReader, Teste> MakePorquestao = reader =>
              new Teste
              {
                 ID = Convert.ToInt32(reader["TesteID"]),
                 questao = new Questao {
                     ID = Convert.ToInt32(reader["QuestaoID"]),
                 }


              };

        private static Func<IDataReader, Questao> MakeQuestoes = reader =>
        new Questao
        {

            Pergunta = Convert.ToString(reader["Questao"]),
            Bimestre = Convert.ToString(reader["Bimestre"]),

            Alternativa = new Alternativas
            {
                A = Convert.ToString(reader["A"]),
                B = Convert.ToString(reader["B"]),
                C = Convert.ToString(reader["C"]),
                D = Convert.ToString(reader["D"]),
                Correta = Convert.ToString(reader["Correta"])
            },
            materia = new Materia
            {
                Nome = Convert.ToString(reader["MateriaNome"]),
                disciplina = new Disciplina
                {
                    Nome = Convert.ToString(reader["DisciplinaNome"])
                },
                serie = new Serie
                {
                    Nome = Convert.ToString(reader["Serie"])
                }
            }
        };

        private static Func<IDataReader, Teste> MakeTesteQuestoes = reader =>
        new Teste
        {
            questao = new Questao
            {
                Pergunta = Convert.ToString(reader["nomeQuestao"]),
                Bimestre = Convert.ToString(reader["Bimestre"]),

                Alternativa = new Alternativas
                {
                    A = Convert.ToString(reader["AlternativaA"]),
                    B = Convert.ToString(reader["AlternativaB"]),
                    C = Convert.ToString(reader["AlternativaC"]),
                    D = Convert.ToString(reader["AlternativaD"]),
                    Correta = Convert.ToString(reader["AlternativaCorreta"])
                },

                materia = new Materia
                {
                    Nome = Convert.ToString(reader["nomeMateria"]),
                    serie = new Serie
                    {
                        Nome = Convert.ToString(reader["serieNome"])
                    },
                    disciplina = new Disciplina
                    {
                        Nome = Convert.ToString(reader["disciplinaNome"])
                    }
                }

            }

        };


        public int AdicionarTBTestes(Teste teste)
        {
            return Db.Insert(_sqlInsertTBTestes, TakeTBTestes(teste));

        }

        public void Delete(Teste testeDelete)
        {

            Dictionary<string, object> parms = new Dictionary<string, object> { { "TesteID", testeDelete.ID } };

            Db.Delete(_sqlDeleteTBQuestoesTeste, parms);

            parms = new Dictionary<string, object> { { "ID", testeDelete.ID } };

            Db.Delete(_sqlDeleteTBTestes, parms);
        }

        public void AdicionarTBTestes_Questoes(int questaoID, int testeID)
        {
            Db.Insert(_sqlInsertTBTestesQuestoes, TakeTBTestesQuestoes(questaoID, testeID));

        }


        private Dictionary<string, object> TakeTBTestes(Teste teste)
        {
            return new Dictionary<string, object>
            {
                { "DataGeracao", teste.dataGeracao },
                { "Descricao", teste.Descricao},
                { "QuantidadeQuestoes", teste.QuantidadeQuestoes}
            };
        }

        private Dictionary<string, object> TakeTBTestesQuestoes(int questaoID, int testeID)
        {
            return new Dictionary<string, object>
            {
                { "QuestaoID", questaoID},
                { "TesteID", testeID}
            };
        }

        public bool GetByQuestion(int id)
        {
            Dictionary<string, object> parms = new Dictionary<string, object> { { "QuestaoID", id } };
            Teste t = Db.Get<Teste>(_sqlGetByQuestion, MakePorquestao, parms);

            if (t == null)
                return true;

            return false;
        }
    }
}