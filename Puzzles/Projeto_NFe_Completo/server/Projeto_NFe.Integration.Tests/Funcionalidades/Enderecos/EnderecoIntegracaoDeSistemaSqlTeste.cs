using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Funcionalidades.Enderecos
{
    public class EnderecoIntegracaoDeSistemaSqlTeste
    {

        ////EnderecoServico _servicoEndereco;
        //IEnderecoRepositorio _repositorioSqlEndereco;

        //[SetUp]
        //public void IniciarCenario()
        //{
        //    //_repositorioSqlEndereco = new EnderecoRepositorioSql();
        //    //_servicoEndereco = new EnderecoServico(_repositorioSqlEndereco);

        //    //BaseSqlTeste.InicializarBancoDeDados();
        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_Adicionar_Sucesso()
        //{
        //    Endereco endereco = ObjectMother.PegarEnderecoValido();

        //    Endereco enderecoAdicionado = _servicoEndereco.Adicionar(endereco);

        //    enderecoAdicionado.Id.Should().BeGreaterOrEqualTo(1);
        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_Atualizar_Sucesso()
        //{
        //    Endereco endereco = ObjectMother.PegarEnderecoValido();
        //    endereco.Id = 1;

        //    _servicoEndereco.Atualizar(endereco);

        //    Endereco enderecoAtualizado = _servicoEndereco.BuscarPorId(endereco.Id);

        //    enderecoAtualizado.Should().NotBeNull();
        //    enderecoAtualizado.Bairro.Should().Be(endereco.Bairro);
        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    Endereco endereco = ObjectMother.PegarEnderecoValido();
        //    endereco.Id = 0;

        //    Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoEndereco.Atualizar(endereco);

        //    acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_BuscarPorId_Sucesso()
        //{
        //    Endereco enderecoParaAdicionar = ObjectMother.PegarEnderecoValido();

        //    Endereco enderecoAdicionado = _servicoEndereco.Adicionar(enderecoParaAdicionar);

        //    Endereco enderecoBuscado = _servicoEndereco.BuscarPorId(enderecoAdicionado.Id);

        //    enderecoBuscado.Municipio.Should().Be(enderecoAdicionado.Municipio);
        //    enderecoBuscado.Pais.Should().Be(enderecoAdicionado.Pais);
        //    enderecoBuscado.Numero.Should().Be(enderecoAdicionado.Numero);
        //    enderecoBuscado.Logradouro.Should().Be(enderecoAdicionado.Logradouro);


        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    Endereco enderecoParaBuscar = ObjectMother.PegarEnderecoValido();
        //    enderecoParaBuscar.Id = 0;

        //    Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoEndereco.BuscarPorId(enderecoParaBuscar.Id);

        //    acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_BuscarTodos_Sucesso()
        //{
        //    Endereco enderecoParaAdicionar = ObjectMother.PegarEnderecoValido();

        //    _servicoEndereco.Adicionar(enderecoParaAdicionar);

        //    IEnumerable<Endereco> listaDeEnderecos = _servicoEndereco.BuscarTodos();

        //    listaDeEnderecos.Should().HaveCountGreaterOrEqualTo(3);
        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_Excluir_Sucesso()
        //{
        //    Endereco enderecoParaAdicionar = ObjectMother.PegarEnderecoValido();

        //    Endereco enderecoAdicionado = _servicoEndereco.Adicionar(enderecoParaAdicionar);

        //    _servicoEndereco.Excluir(enderecoAdicionado);

        //    Endereco enderecoBuscadoAposExclusao = _servicoEndereco.BuscarPorId(enderecoAdicionado.Id);

        //    enderecoBuscadoAposExclusao.Should().BeNull();

        //}

        //[Test]
        //public void Endereco_IntegracaoDeSistema_Sql_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    Endereco enderecoParaAdicionar = ObjectMother.PegarEnderecoValido();

        //    Endereco enderecoAdicionado = _servicoEndereco.Adicionar(enderecoParaAdicionar);
        //    enderecoAdicionado.Id = 0;

        //    Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoEndereco.Excluir(enderecoAdicionado);

        //    acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //}
    }
}
