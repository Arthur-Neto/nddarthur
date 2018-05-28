using Loterica.Dominio.Exceptions;
using Loterica.Dominio.Features.Concursos;
using Loterica.Dominio.Features.Ganhadores;
using Loterica.Dominio.Features.Premios;
using Loterica.Dominio.Features.Resultados;
using Loterica.Infra.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Loterica.Infra.Data.Features.Concursos
{
    public class ConcursoRepository : IConcursoRepository
    {

        #region Querys
        private const string _insert = @"INSERT INTO Concurso (Data, IsFechado, Premio, IdResultado, PremioQuadra, PremioQuina, PremioSena, GanhadoresQuadra, GanhadoresQuina, GanhadoresSena) VALUES (@Data, @IsFechado, @Premio, @IdResultado, @PremioQuadra, @PremioQuina, @PremioSena, @GanhadoresQuadra, @GanhadoresQuina, @GanhadoresSena)";
        private const string _insertResultado = @"INSERT INTO Resultado (NumerosSorteados, MediaQuadra, MediaQuina, MediaSena) VALUES (@NumerosSorteados, @MediaQuadra, @MediaQuina, @MediaSena)";
        private const string _insertFaturamento = @"INSERT INTO Faturamento (IdConcurso, ValorGanho) VALUES (@IdConcurso, @ValorGanho)";
        private const string _update = @"UPDATE Concurso Set Data = @Data, IsFechado = @IsFechado, Premio = @Premio, IdResultado = @IdResultado, PremioQuadra = @PremioQuadra, PremioQuina = @PremioQuina, PremioSena = @PremioSena, GanhadoresQuadra = @GanhadoresQuadra, GanhadoresQuina = @GanhadoresQuina, GanhadoresSena = @GanhadoresSena WHERE Id = @Id";
        private const string _getById = @"SELECT * FROM Concurso Where Id = @Id";
        private const string _getAll = @"SELECT * FROM Concurso";
        private const string _delete = @"DELETE FROM Concurso Where Id = @Id";
        private const string _faturamento = @"SELECT * FROM Faturamento";
        #endregion

        public Concurso Adicionar(Concurso entidade)
        {
            long _idResultado = Db.Insert(_insertResultado, TakeResultado(entidade));
            entidade.Resultado.Id = _idResultado;
            long _id = Db.Insert(_insert, Take(entidade));

            Db.Insert(_insertFaturamento, TakeFaturamento(entidade));

            entidade = ObterPorId(Convert.ToInt32(_id));

            return entidade;
        }

        public Concurso Atualizar(Concurso entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();
            else if (entidade.IsFechado == true)
                throw new ConcursoFechadoException();

            Db.Update(_insert, Take(entidade));

            entidade = ObterPorId(entidade.Id);

            return entidade;
        }

        public void Deletar(Concurso entidade)
        {
            if (entidade.Id == 0)
                throw new IdentifierUndefinedException();

            try
            {
                Db.Delete(_delete, Take(entidade));
            }
            catch (SqlException)
            {
                throw new DependenciaException();
            }
        }

        public Concurso ObterPorId(long id)
        {
            if (id == 0)
                throw new IdentifierUndefinedException();

            return Db.Get(_getById, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Concurso> PegarTodos()
        {
            return Db.GetAll(_getAll, Make);
        }

        public string RelatorioFaturamento()
        {
            StringBuilder relatorio = new StringBuilder();
            IEnumerable<Concurso> concursos = Db.GetAll(_faturamento, MakeFaturamento);
            foreach (Concurso concurso in concursos)
            {
                relatorio.Append("Concurso numero: ");
                relatorio.Append(concurso.Id);
                relatorio.Append("\n");
                relatorio.Append("Faturamento do concurso: ");
                relatorio.Append(concurso.Faturamento);
                relatorio.Append("\n");
                relatorio.Append("Numero de apostas: ");
                relatorio.Append(concurso.Apostas.Count + concurso.Boloes.Count);
                relatorio.Append("\n");
            }

            return relatorio.ToString();
        }

        private static Func<IDataReader, Concurso> Make = reader =>
         new Concurso
         {
             Id = Convert.ToInt64(reader["Id"]),
             Data = Convert.ToDateTime(reader["Data"]),
             IsFechado = Convert.ToBoolean(reader["IsFechado"]),
             Premio = new Premio() { Total = Convert.ToDecimal(reader["Premio"]), Quadra = Convert.ToDecimal(reader["PremioQuadra"]), Quina = Convert.ToDecimal(reader["PremioQuina"]), Sena = Convert.ToDecimal(reader["PremioSena"]) },
             Resultado = new Resultado() { Id = Convert.ToInt32(reader["IdResultado"]) },
             Ganhadores = new Ganhador() { Quadra = Convert.ToInt32(reader["GanhadoresQuadra"]), Quina = Convert.ToInt32(reader["GanhadoresQuina"]), Sena = Convert.ToInt32(reader["GanhadoresSena"]) }
         };

        private static Func<IDataReader, Concurso> MakeFaturamento = reader =>
         new Concurso
         {
             Id = Convert.ToInt64(reader["Id"]),
             Faturamento = Convert.ToDecimal(reader["ValorGanho"])
         };

        private object[] Take(Concurso concurso)
        {
            return new object[]
            {
                "@Id", concurso.Id,
                "@Data", concurso.Data,
                "@IsFechado", concurso.IsFechado,
                "@Premio", concurso.Premio.Total,
                "@IdResultado", concurso.Resultado.Id,
                "@GanhadoresQuadra", concurso.Ganhadores.Quadra,
                "@GanhadoresQuina", concurso.Ganhadores.Quina,
                "@GanhadoresSena", concurso.Ganhadores.Sena,
                "@PremioQuadra", concurso.Premio.Quadra,
                "@PremioQuina", concurso.Premio.Quina,
                "@PremioSena", concurso.Premio.Sena
            };
        }

        private object[] TakeResultado(Concurso concurso)
        {
            return new object[]
            {
                "@NumerosSorteados", string.Join(",", concurso.Resultado.NumerosSorteados.Select(n => n.ToString()).ToArray()),
                "@MediaQuadra", concurso.Resultado.MediaQuadra,
                "@MediaQuina", concurso.Resultado.MediaQuina,
                "@MediaSena", concurso.Resultado.MediaSena
            };
        }

        private object[] TakeFaturamento(Concurso concurso)
        {
            return new object[]
            {
                "@IdConcurso", concurso.Id,
                "@ValorGanho", concurso.Faturamento
            };
        }
    }
}
