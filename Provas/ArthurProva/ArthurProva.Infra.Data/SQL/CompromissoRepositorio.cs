using ArthurProva.Domain;
using ArthurProva.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace ArthurProva.Infra.Data.SQL
{
    public class CompromissoRepositorio : Db<Compromisso>, ICompromissoRepositorio
    {
        #region Querys 
        private const string _inserir = @"INSERT INTO Compromisso (Assunto, Local, DiaInteiro, DataInicio, DataTermino) VALUES (@Assunto, @Local, @DiaInteiro, @DataInicio, @DataTermino);";

        private const string _inserirEmIntermediaria = @"INSERT INTO Compromisso_Contato (IdCompromisso, IdContato) VALUES (@IdCompromisso, @IdContato)";

        private const string _deletarDaTabelaIntermediaria = @"DELETE FROM Compromisso_Contato WHERE IdCompromisso = @Id";

        private const string _carregarTodos = @"SELECT * FROM Compromisso";

        private const string _carregarPorId = @"SELECT * FROM Compromisso WHERE Id = @Id";

        private const string _atualizar = @"UPDATE Compromisso SET Assunto = @Assunto, Local = @Local, DiaInteiro = @DiaInteiro, DataInicio = @DataInicio, DataTermino = @DataTermino WHERE Id = @Id";

        private const string _excluir = @"DELETE FROM Compromisso WHERE Id = @Id";
        #endregion Querys

        public CompromissoRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Compromisso Adicionar(Compromisso compromisso)
        {
            compromisso.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(compromisso, false));
            AdicionarCompromissoContato(compromisso);
            return compromisso;
        }

        public override Compromisso Atualizar(Compromisso entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            base.Excluir(_deletarDaTabelaIntermediaria, entidade.Id);
            AdicionarCompromissoContato(entidade);
            return entidade;
        }

        public override IList<Compromisso> BuscarTodos()
        {

            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public override Compromisso ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public override int Excluir(int id)
        {
            base.Excluir(_deletarDaTabelaIntermediaria, id);
            return base.Excluir(_excluir, id);
        }

        public void AdicionarCompromissoContato(Compromisso compromisso)
        {
            foreach (var item in compromisso.Contatos)
            {
                base.ExecutarAtualizacao(_inserirEmIntermediaria, GetParamCompromissoContato(compromisso, item));
            }
        }

        public Dictionary<string, object> GetParamCompromissoContato(Compromisso compromisso, Contato contato)
        {
            var dic = new Dictionary<string, object>();

            dic.Add("IdCompromisso", compromisso.Id);
            dic.Add("IdContato", contato.Id);

            return dic;
        }

        public Dictionary<String, Object> EntidadeParaTupla(Compromisso compromisso, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("Assunto", compromisso.Assunto);
            parametros.Add("Local", compromisso.Local);
            parametros.Add("DataInicio", compromisso.DataInicio);
            parametros.Add("DataTermino", compromisso.DataTermino);
            parametros.Add("DiaInteiro", compromisso.IsDiaInteiro);

            if (temId)
            {
                parametros.Add("Id", compromisso.Id);
            }

            return parametros;
        }

        private static Func<IDataReader, Compromisso> TuplaParaEntidade = reader =>
          new Compromisso()
          {
              Id = Convert.ToInt32(reader["Id"]),
              Assunto = Convert.ToString(reader["Assunto"]),
              Local = Convert.ToString(reader["Local"]),
              DataInicio = Convert.ToDateTime(reader["DataInicio"]),
              DataTermino = Convert.ToDateTime(reader["DataTermino"]),
              IsDiaInteiro = Convert.ToBoolean(reader["DiaInteiro"])
          };
    }
}
