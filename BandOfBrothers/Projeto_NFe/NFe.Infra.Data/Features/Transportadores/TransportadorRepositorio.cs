using NFe.Dominio.Features.Enderecos;
using NFe.Dominio.Features.Transportadores;
using System;
using System.Collections.Generic;
using System.Data;

namespace NFe.Infra.Data.Features.Transportadores
{
    public class TransportadorRepositorio : ITransportadorRepositorio
    {
        #region Queries
        private const string SqlInsert = @"Insert into TBTransportador(Cnpj,Cpf,InscricaoEstadual,Nome,RazaoSocial,ResponsabilidadeFrete,IdEndereco)values(@Cnpj,@Cpf,@InscricaoEstadual,@Nome,@RazaoSocial,@ResponsabilidadeFrete,@IdEndereco)";
        private const string SqlGetById = @"Select t.*
                                            , e.Id as IdEndereco
                                            , e.Logradouro
                                            , e.Numero
                                            , e.Municipio
                                            , e.Pais
                                            , e.Bairro
                                            , e.Estado
                                            from TBTransportador as t
                                            inner join TBEndereco as e 
                                            on t.IdEndereco = e.Id 
                                            where t.Id = @Id";
        private const string SqlGetAll = @"Select 
                                            t.*
                                            , e.Id as IdEndereco
                                            , e.Logradouro
                                            , e.Numero
                                            , e.Municipio
                                            , e.Pais
                                            , e.Bairro
                                            , e.Estado
                                            from TBTransportador as t
                                            inner join TBEndereco as e 
                                            on t.IdEndereco = e.Id";
        private const string SqlDeleteById = @"Delete from TBTransportador where Id = @Id";
        private const string SqlUpdate = @"Update TBTransportador set Cnpj = @Cnpj, Cpf = @Cpf, InscricaoEstadual = @InscricaoEstadual, Nome = @Nome, RazaoSocial = @RazaoSocial, ResponsabilidadeFrete = @ResponsabilidadeFrete";
        #endregion

        public Transportador Atualizar(Transportador entidade)
        {
            Db.Update(SqlUpdate, Take(entidade));

            return PegarPorId(entidade.Id);
        }

        public void Deletar(Transportador entidade)
        {
            Db.Delete(SqlDeleteById, Take(entidade));
        }

        public Transportador PegarPorId(long id)
        {
            return Db.Get(SqlGetById, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Transportador> PegarTodos()
        {
            return Db.GetAll(SqlGetAll, Make);
        }

        public Transportador Salvar(Transportador entidade)
        {
            entidade.Id = Db.Insert(SqlInsert, Take(entidade));
            return entidade;
        }

        private static Func<IDataReader, Transportador> Make = reader =>
            new Transportador
            {
                Id = Convert.ToInt64(reader["Id"]),
                Cnpj = Convert.ToString(reader["Cnpj"]),
                Cpf = Convert.ToString(reader["Cpf"]),
                InscricaoEstadual = Convert.ToString(reader["InscricaoEstadual"]),
                Nome = Convert.ToString(reader["Nome"]),
                RazaoSocial = Convert.ToString(reader["RazaoSocial"]),
                ResponsabilidadeFrete = (Frete)(reader["ResponsabilidadeFrete"]),
                Endereco = new Endereco()
                {
                    Id = Convert.ToInt64(reader["IdEndereco"]),
                }
            };

        private object[] Take(Transportador transportador)
        {
            return new object[]
            {
                "@Id", transportador.Id,
                "@IdEndereco", transportador.Endereco.Id,
                "@Cnpj", (string)transportador.Cnpj,
                "@Cpf", (string)transportador.Cpf,
                "@InscricaoEstadual", transportador.InscricaoEstadual,
                "@Nome",transportador.Nome,
                "@RazaoSocial", transportador.RazaoSocial,
                "@ResponsabilidadeFrete", transportador.ResponsabilidadeFrete
            };
        }
    }
}
