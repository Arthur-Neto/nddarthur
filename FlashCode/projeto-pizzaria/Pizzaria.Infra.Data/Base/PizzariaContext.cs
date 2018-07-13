using Pizzaria.Dominio.Features.Clientes;
using Pizzaria.Dominio.Features.Enderecos;
using Pizzaria.Dominio.Features.ItensPedidos;
using Pizzaria.Dominio.Features.Pedidos;
using Pizzaria.Dominio.Features.Produtos;
using Pizzaria.Dominio.Features.Produtos.Adicionais;
using Pizzaria.Dominio.Features.Produtos.Bebidas;
using Pizzaria.Dominio.Features.Produtos.Calzones;
using Pizzaria.Dominio.Features.Produtos.Pizzas;
using Pizzaria.Infra.Data.Features.Clientes;
using Pizzaria.Infra.Data.Features.Enderecos;
using Pizzaria.Infra.Data.Features.ItensPedido;
using Pizzaria.Infra.Data.Features.Pedidos;
using Pizzaria.Infra.Data.Features.Produtos;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Pizzaria.Infra.Data.Base
{
    public class PizzariaContext : DbContext
    {
        public PizzariaContext() : base("PizzariaDB_FlashCode")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Calzone> Calzones { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Adicional> Adicionais { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ItemPedidoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
        }
    }
}
