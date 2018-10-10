using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Base;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Funcionalidades.Transportadoras
{
    public class TransportadorIntegracaoDeSistemaSqlTeste
    {
        //ProjetoNFeContexto _projetoNFeContexto;
        //ITransportadorRepositorio _transportadorRepositorio;
        //IEnderecoRepositorio _enderecoRepositorio;
        //ITransportadorServico _transportadorServico;
        //CNPJ _cnpj;
        //CPF _cpf;
        //Endereco _endereco;

        //[SetUp]
        //public void IniciarCenario()
        //{
        //    _cnpj = new CNPJ();
        //    _cpf = new CPF();
        //    _endereco = new Endereco();
        //    _projetoNFeContexto = new ProjetoNFeContexto();
        //    _transportadorRepositorio = new TransportadorRepositorioSql(_projetoNFeContexto);
        //    _enderecoRepositorio = new EnderecoRepositorioSql();
        //    _transportadorServico = new TransportadorServico(_transportadorRepositorio, _enderecoRepositorio);

        //    _endereco.Numero = 22;
        //    _endereco.Bairro = "Coral";
        //    _endereco.Logradouro = "Rua";
        //    _endereco.Municipio = "Lages";
        //    _endereco.Estado = "SC";
        //    _endereco.Pais = "BR";
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_Adicionar_Sucesso()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cnpj.NumeroComPontuacao = "37.311.068/0001-00";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _cnpj);
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    transportador = _transportadorServico.Adicionar(transportador);

        //    transportador.Should().NotBeNull();
        //    transportador.Id.Should().BeGreaterOrEqualTo(1);
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_Atualizar_Sucesso()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cnpj.NumeroComPontuacao = "37.311.068/0001-00";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _cnpj);
        //    transportador.Id = 1;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    _transportadorServico.Atualizar(transportador);

        //    Transportador buscarTransportador = _transportadorServico.BuscarPorId(transportador.Id);

        //    buscarTransportador.Should().NotBeNull();
        //    buscarTransportador.NomeRazaoSocial.Should().Be(transportador.NomeRazaoSocial);
        //    buscarTransportador.InscricaoEstadual.Should().Be(transportador.InscricaoEstadual);
        //    buscarTransportador.ResponsabilidadeFrete.Should().Be(transportador.ResponsabilidadeFrete);
        //    buscarTransportador.Documento.NumeroComPontuacao.Should().Be(transportador.Documento.NumeroComPontuacao);
        //    buscarTransportador.Endereco.Id.Should().Be(transportador.Endereco.Id);
        //    buscarTransportador.Endereco.Numero.Should().Be(transportador.Endereco.Numero);
        //    buscarTransportador.Endereco.Bairro.Should().Be(transportador.Endereco.Bairro);
        //    buscarTransportador.Endereco.Municipio.Should().Be(transportador.Endereco.Municipio);
        //    buscarTransportador.Endereco.Logradouro.Should().Be(transportador.Endereco.Logradouro);
        //    buscarTransportador.Endereco.Estado.Should().Be(transportador.Endereco.Estado);
        //    buscarTransportador.Endereco.Pais.Should().Be(transportador.Endereco.Pais);
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cpf.NumeroComPontuacao = "619.648.783-30";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_endereco, _cpf);
        //    transportador.Id = 0;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    Action acaoComExcecao = () => _transportadorServico.Atualizar(transportador);

        //    acaoComExcecao.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_Excluir_Sucesso()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cpf.NumeroComPontuacao = "619.648.783-30";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _cpf);
        //    transportador.Id = 1;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    _transportadorServico.Excluir(transportador);

        //    Transportador buscarTransportador = _transportadorServico.BuscarPorId(transportador.Id);

        //    buscarTransportador.Should().BeNull();
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cnpj.NumeroComPontuacao = "37.311.068/0001-00";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCPF(_endereco, _cnpj);
        //    transportador.Id = 0;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    Action acaoComExcecao = () => _transportadorServico.Excluir(transportador);

        //    acaoComExcecao.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_BuscarPorId_Sucesso()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cpf.NumeroComPontuacao = "619.648.783-30";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _cpf);
        //    transportador.Id = 1;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    Transportador adicionarTransportador = _transportadorServico.Adicionar(transportador);

        //    Transportador buscarTransportador = _transportadorServico.BuscarPorId(transportador.Id);

        //    buscarTransportador.Id.Should().Be(adicionarTransportador.Id);
        //    buscarTransportador.InscricaoEstadual.Should().Be(adicionarTransportador.InscricaoEstadual);
        //    buscarTransportador.NomeRazaoSocial.Should().Be(adicionarTransportador.NomeRazaoSocial);
        //    buscarTransportador.ResponsabilidadeFrete.Should().Be(adicionarTransportador.ResponsabilidadeFrete);
        //    buscarTransportador.Endereco.Id.Should().Be(adicionarTransportador.Endereco.Id);
        //    buscarTransportador.Endereco.Numero.Should().Be(adicionarTransportador.Endereco.Numero);
        //    buscarTransportador.Endereco.Bairro.Should().Be(adicionarTransportador.Endereco.Bairro);
        //    buscarTransportador.Endereco.Municipio.Should().Be(adicionarTransportador.Endereco.Municipio);
        //    buscarTransportador.Endereco.Logradouro.Should().Be(adicionarTransportador.Endereco.Logradouro);
        //    buscarTransportador.Endereco.Estado.Should().Be(adicionarTransportador.Endereco.Estado);
        //    buscarTransportador.Endereco.Pais.Should().Be(adicionarTransportador.Endereco.Pais);
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cpf.NumeroComPontuacao = "619.648.783-30";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _cpf);
        //    transportador.Id = 0;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    Action acaoComExcecao = () => _transportadorServico.BuscarPorId(transportador.Id);

        //    acaoComExcecao.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Transportador_IntegracaoDeSistema_Sql_BuscarTodos_Sucesso()
        //{
        //    long idDoEnderecoDaBaseSql = 3;
        //    _cpf.NumeroComPontuacao = "619.648.783-30";
        //    Transportador transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, _cpf);
        //    transportador.Id = 1;
        //    transportador.Endereco.Id = idDoEnderecoDaBaseSql;
        //    transportador.Endereco = _endereco;

        //    IEnumerable<Transportador> listaTransportadoras = _transportadorServico.BuscarTodos();

        //    listaTransportadoras.Should().HaveCountGreaterOrEqualTo(1);
        //}

    }
}
