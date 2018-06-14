using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Data;

namespace NFe.Infra.Data.Features.Emitentes
{
    public class EmitenteRepositorio : IEmitenteRepositorio
    {
        #region Querys_SQL
        public const string _inserir = @"INSERT INTO TBEmitente (Nome, RazaoSocial, Cpf, Cnpj, InscricaoEstadual, InscricaoMunicipal, IdEndereco) VALUES (@Nome, @RazaoSocial, @Cpf, @Cnpj, @InscricaoEstadual, @InscricaoMunicipal, @IdEndereco)";
        public const string _atualizar = @"UPDATE TBEmitente SET Nome = @Nome, RazaoSocial = @RazaoSocial, Cpf = @Cpf, Cnpj = @Cnpj, InscricaoEstadual = @InscricaoEstadual, InscricaoMunicipal = @InscricaoMunicipal, IdEndereco = @IdEndereco Where Id = @Id";
        public const string _obterPorId = @"SELECT * FROM TBEmitente WHERE Id = @Id";
        public const string _obterTodos = @"SELECT * FROM TBEmitente";
        public const string _deletar = @"DELETE FROM TBEmitente WHERE Id = @Id";
        #endregion

        public Emitente Atualizar(Emitente entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Emitente entidade)
        {
            Db.Delete(_deletar, new object[] { "@Id", entidade.Id });
        }

        public Emitente PegarPorId(long id)
        {
            return Db.Get(_obterPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Emitente> PegarTodos()
        {
            return Db.GetAll(_obterTodos, Make);
        }

        public Emitente Salvar(Emitente entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Emitente> Make = reader =>
            new Emitente
            {
                Id = Convert.ToInt64(reader["Id"]),
                Nome = Convert.ToString(reader["Nome"]),
                RazaoSocial = Convert.ToString(reader["RazaoSocial"]),
                Cpf = Convert.ToString(reader["Cpf"]),
                Cnpj = Convert.ToString(reader["Cnpj"]),
                InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]),
                InscricaoMunicipal = Convert.ToString(reader["InscricaoMunicipal"]),
                Endereco = new Endereco()
                {
                    Id = Convert.ToInt64(reader["IdEndereco"])
                }
            };

        private object[] Take(Emitente emitente)
        {
            return new object[]
            {
                "@Id", emitente.Id,
                "@Nome", emitente.Nome,
                "@RazaoSocial", emitente.RazaoSocial,
                "@Cpf", (string)emitente.Cpf,
                "@Cnpj", (string)emitente.Cnpj,
                "@InscricaoEstadual", emitente.InscricaoEstadual,
                "@InscricaoMunicipal", emitente.InscricaoMunicipal,
                "@IdEndereco", emitente.Endereco.Id
            };
        }
    }
}
