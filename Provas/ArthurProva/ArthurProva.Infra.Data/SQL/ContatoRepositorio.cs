using ArthurProva.Domain;
using ArthurProva.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace ArthurProva.Infra.Data.SQL
{
    public class ContatoRepositorio : Db<Contato>, IContatoRepositorio
    {
        #region Querys 
        private const string _inserir = @"INSERT INTO Contato (Nome, Email, Departamento, Endereco, Telefone) VALUES (@Nome, @Email, @Departamento, @Endereco, @Telefone);";

        private const string _carregarContatos = @"SELECT * FROM Contato INNER JOIN Compromisso_Contato ON Contato.Id = Compromisso_Contato.IdContato WHERE Compromisso_Contato.IdCompromisso = @Id";

        private const string _carregarTodos = @"SELECT Id, Nome, Email, Departamento, Endereco, Telefone FROM Contato";

        private const string _buscarContatosLinkados = @"SELECT * FROM Contato INNER JOIN Compromisso_Contato ON Compromisso_Contato.IdContato = Contato.Id WHERE IdContato = @Id";

        private const string _carregarPorId = @"SELECT Id, Nome, Email, Departamento, Endereco, Telefone FROM Contato WHERE Id = @Id";

        private const string _carregarPorNomeEId = @"SELECT Id, Nome, Email, Departamento, Endereco, Telefone FROM Contato WHERE Nome = @Nome AND Id <> @Id";

        private const string _atualizar = @"UPDATE Contato SET Nome = @Nome, Email = @Email, Departamento = @Departamento, Endereco = @Endereco, Telefone = @Telefone WHERE Id = @Id";

        private readonly string _carregarPorNome = @"SELECT * FROM Contato WHERE Nome = {0}Nome";

        private const string _excluir = @"DELETE FROM Contato WHERE Id = @Id";
        #endregion Querys

        public ContatoRepositorio(TipoRepositorio tipo) : base(tipo)
        {
        }

        public override Contato Adicionar(Contato entidade)
        {
            entidade.Id = base.ExecutarAtualizacao(_inserir, EntidadeParaTupla(entidade, false));
            return entidade;
        }

        public override Contato Atualizar(Contato entidade)
        {
            base.ExecutarAtualizacao(_atualizar, EntidadeParaTupla(entidade, true), false);
            return entidade;
        }

        public override IList<Contato> BuscarTodos()
        {
            return base.ConsultarLista(_carregarTodos, TuplaParaEntidade);
        }

        public override Contato ConsultarPorId(int id)
        {
            return base.ConsultarEntidade(_carregarPorId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public IList<Contato> BuscarContatosLinkados(int id)
        {
            return base.ConsultarLista(_buscarContatosLinkados, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public IList<Contato> ConsultarPorNome(string nome)
        {
            return base.ConsultarLista(_carregarPorNome, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", nome } });
        }

        public IList<Contato> ConsultarPorNomeEId(string nome, int id)
        {
            return base.ConsultarLista(_carregarPorNomeEId, TuplaParaEntidade, new Dictionary<String, Object>() { { "Nome", nome }, { "Id", id } });
        }

        public override int Excluir(int id)
        {
            return base.Excluir(_excluir, id);
        }

        public IList<Contato> BuscarContatosPorIdCompromisso(int id)
        {
            return base.ConsultarLista(_carregarContatos, TuplaParaEntidade, new Dictionary<String, Object>() { { "Id", id } });
        }

        public Dictionary<String, Object> EntidadeParaTupla(Contato contato, bool temId)
        {
            Dictionary<String, Object> parametros = new Dictionary<string, object>();
            parametros.Add("Nome", contato.Nome);
            parametros.Add("Email", contato.Email);
            parametros.Add("Departamento", contato.Departamento);
            parametros.Add("Endereco", contato.Endereco);
            parametros.Add("Telefone", contato.Telefone);

            if (temId)
            {
                parametros.Add("Id", contato.Id);
            }

            return parametros;
        }

        private static Func<IDataReader, Contato> TuplaParaEntidade = reader =>
          new Contato()
          {
              Id = Convert.ToInt32(reader["Id"]),
              Nome = Convert.ToString(reader["Nome"]),
              Email = Convert.ToString(reader["Email"]),
              Departamento = Convert.ToString(reader["Departamento"]),
              Endereco = Convert.ToString(reader["Endereco"]),
              Telefone = Convert.ToInt32(reader["Telefone"])
          };
    }
}
