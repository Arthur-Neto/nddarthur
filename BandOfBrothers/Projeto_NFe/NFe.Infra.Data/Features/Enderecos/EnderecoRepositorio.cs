using NFe.Dominio.Features.Enderecos;
using System;
using System.Collections.Generic;
using System.Data;

namespace NFe.Infra.Data.Features.Enderecos
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        #region Queries
        private const string _inserir = @"Insert into TBEndereco(Bairro,Estado,Logradouro,Municipio,Numero,Pais)values(@Bairro,@Estado,@Logradouro,@Municipio,@Numero,@Pais)";
        private const string _pegarPorId = @"Select * from TBEndereco where Id = @Id";
        private const string _pegarTodos = @"Select * from TBEndereco";
        private const string _deletar = @"Delete from TBEndereco where Id = @Id";
        private const string _atualizar = @"Update TBEndereco set Bairro = @Bairro, Estado = @Estado, Logradouro = @Logradouro, Municipio = @Municipio, Numero = @Numero, Pais = @Pais";
        #endregion

        public Endereco Atualizar(Endereco entidade)
        {
            Db.Update(_atualizar, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Endereco entidade)
        {
            Db.Delete(_deletar, Take(entidade));
        }

        public Endereco PegarPorId(long id)
        {
            return Db.Get(_pegarPorId, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Endereco> PegarTodos()
        {
            return Db.GetAll(_pegarTodos, Make);
        }

        public Endereco Salvar(Endereco entidade)
        {
            entidade.Id = Db.Insert(_inserir, Take(entidade));

            return entidade;
        }

        private static Func<IDataReader, Endereco> Make = reader =>
            new Endereco
            {
                Id = Convert.ToInt64(reader["Id"]),
                Bairro = Convert.ToString(reader["Bairro"]),
                Estado = Convert.ToString(reader["Estado"]),
                Logradouro = Convert.ToString(reader["Logradouro"]),
                Municipio = Convert.ToString(reader["Municipio"]),
                Numero = Convert.ToString(reader["Numero"]),
                Pais = Convert.ToString(reader["Pais"]),
            };

        private object[] Take(Endereco endereco)
        {
            return new object[]
            {
                "@Id", endereco.Id,
                "@Bairro", endereco.Bairro,
                "@Estado", endereco.Estado,
                "@Logradouro", endereco.Logradouro,
                "@Municipio",endereco.Municipio,
                "@Numero", endereco.Numero,
                "@Pais", endereco.Pais
            };
        }
    }
}
