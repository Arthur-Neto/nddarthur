using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Data;

namespace NFe.Infra.Data.Features.Destinatarios
{
    public class DestinatarioRepositorio : IDestinatarioRepositorio
    {
        #region Queries
        private const string _inserir = @"INSERT INTO TBDestinatario(Nome, RazaoSocial, Cpf, Cnpj, InscricaoEstadual, IdEndereco) VALUES(@Nome, @RazaoSocial, @Cpf, @Cnpj, @InscricaoEstadual, @IdEndereco)";
        private const string _pegarPorId = @"SELECT * FROM TBDestinatario WHERE Id = @Id";
        private const string _pegarTodos = @"SELECT * FROM TBDestinatario";
        private const string _deletar = @"DELETE FROM TBDestinatario WHERE Id = @Id";
        private const string _atualizar = @"UPDATE TBDestinatario SET  Nome = @Nome, RazaoSocial = @RazaoSocial, Cpf = @Cpf, Cnpj = @Cnpj, InscricaoEstadual = @InscricaoEstadual, IdEndereco = @IdEndereco WHERE Id = @Id";
        #endregion

        public Destinatario Atualizar(Destinatario entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Destinatario entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Destinatario PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Destinatario> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Destinatario Salvar(Destinatario entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Destinatario> Make = reader =>
            new Destinatario
            {
                Id = Convert.ToInt64(reader["Id"]),
                Cnpj = Convert.ToString(reader["Cnpj"]),
                Cpf = Convert.ToString(reader["Cpf"]),
                InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]),
                Nome = Convert.ToString(reader["Nome"]),
                RazaoSocial = Convert.ToString(reader["RazaoSocial"]),
                Endereco = new Endereco()
                {
                    Id = Convert.ToInt64(reader["IdEndereco"])
                }
            };

        private object[] Take(Destinatario destinatario)
        {
            return new object[]
            {
                "@Id", destinatario.Id,
                "@Cnpj", (string)destinatario.Cnpj,
                "@Cpf", (string)destinatario.Cpf,
                "@InscricaoEstadual", destinatario.InscricaoEstadual,
                "@Nome",destinatario.Nome,
                "@RazaoSocial", destinatario.RazaoSocial,
                "@IdEndereco", destinatario.Endereco.Id
            };
        }
    }
}
