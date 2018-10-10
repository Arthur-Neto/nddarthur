using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Common.Tests.Base;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Excecoes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Infrastructure.Data.Base;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Destinatarios;
using Projeto_NFe.Infrastructure.Data.Funcionalidades.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integration.Tests.Funcionalidades.Destinatarios
{
    [TestFixture]
    public class DestinatarioIntegracaoDeSistemaSqlTeste
    {
        //ProjetoNFeContexto _projetoNFeContexto;
        //IDestinatarioServico _servicoDestinatario;
        //IDestinatarioRepositorio _destinatarioRepositorio;
        //IEnderecoRepositorio _enderecoRepositorio;

        //[SetUp]
        //public void IniciarCenario()
        //{
        //    _projetoNFeContexto = new ProjetoNFeContexto();
        //    _enderecoRepositorio = new EnderecoRepositorioSql();
        //    _destinatarioRepositorio = new DestinatarioRepositorioSql(_projetoNFeContexto);
        //    _servicoDestinatario = new DestinatarioServico(_enderecoRepositorio, _destinatarioRepositorio);

        //}

        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_Adicionar_Sucesso()
        //{
        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

        //    Destinatario destinatarioAdicionado = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

        //    Destinatario destinatarioBuscado = _servicoDestinatario.BuscarPorId(destinatarioParaAdicionar.Id);

        //    destinatarioBuscado.InscricaoEstadual.Should().Be(destinatarioAdicionado.InscricaoEstadual);
        //    destinatarioBuscado.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
        //    destinatarioBuscado.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
        //    destinatarioBuscado.Documento.Numero.Should().Be(destinatarioAdicionado.Documento.Numero);
        //}

        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_Excluir_Sucesso()
        //{
        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

        //    Destinatario destinatarioAdicionado = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

        //    _servicoDestinatario.Excluir(destinatarioAdicionado);

        //    Destinatario destinatarioBuscado = _servicoDestinatario.BuscarPorId(destinatarioAdicionado.Id);

        //    destinatarioBuscado.Should().BeNull();
        //}

        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_Excluir_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

        //    destinatarioParaAdicionar.Id = 0;

        //    Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Excluir(destinatarioParaAdicionar);

        //    acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_BuscarTodos_Sucesso()
        //{
        //    int numeroDeRegistrosDeDestinatariosInseridos = 1;

        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();


        //    for (int i = 0; i < 5; i++)
        //    {
        //        var destinatario = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);
        //        numeroDeRegistrosDeDestinatariosInseridos++;
        //    }

        //    IEnumerable<Destinatario> listaDeDestinatarios = _servicoDestinatario.BuscarTodos();

        //    listaDeDestinatarios.Count().Should().Be(numeroDeRegistrosDeDestinatariosInseridos);

        //}


        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_BuscarPorId_Sucesso()
        //{
        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

        //    Destinatario destinatarioAdicionado = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

        //    Destinatario destinatarioBuscado = _servicoDestinatario.BuscarPorId(destinatarioAdicionado.Id);

        //    destinatarioBuscado.InscricaoEstadual.Should().Be(destinatarioAdicionado.InscricaoEstadual);
        //    destinatarioBuscado.NomeRazaoSocial.Should().Be(destinatarioAdicionado.NomeRazaoSocial);
        //    destinatarioBuscado.Endereco.Pais.Should().Be(destinatarioAdicionado.Endereco.Pais);
        //    destinatarioBuscado.Documento.Numero.Should().Be(destinatarioAdicionado.Documento.Numero);
        //}


        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_BuscarPorId_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    long idInvalido = 0;

        //    Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.BuscarPorId(idInvalido);

        //    acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();
        //}

        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_Atualizar_Sucesso()
        //{
        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

        //    Destinatario destinatarioAdicionadoParaAtualizar = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);

        //    destinatarioAdicionadoParaAtualizar.InscricaoEstadual = null;
        //    destinatarioAdicionadoParaAtualizar.Documento = new Documento("115.372.669-69", TipoDocumento.CPF);
        //    Destinatario destinatarioAtualizado = _servicoDestinatario.Atualizar(destinatarioAdicionadoParaAtualizar);

        //    destinatarioAtualizado.Should().NotBeNull();
        //    destinatarioAtualizado.Id.Should().Be(destinatarioParaAdicionar.Id);
        //    destinatarioAtualizado.InscricaoEstadual.Should().BeNull();
        //    destinatarioAtualizado.Documento.Tipo.Should().Be(TipoDocumento.CPF);

        //}

        //[Test]
        //public void Destinatario_IntegracaoDeSistema_Sql_Atualizar_ExcecaoIdentificadorIndefinido_Falha()
        //{
        //    long idInvalido = 0;

        //    Destinatario destinatarioParaAdicionar = ObjectMother.PegarDestinatarioValidoComCNPJSemDependencias();

        //    Destinatario destinatarioAdicionadoParaAtualizar = _servicoDestinatario.Adicionar(destinatarioParaAdicionar);
        //    destinatarioAdicionadoParaAtualizar.Id = idInvalido;

        //    Action acaoParaRetornarExcecaoIdentificadorIndefinido = () => _servicoDestinatario.Atualizar(destinatarioAdicionadoParaAtualizar);

        //    acaoParaRetornarExcecaoIdentificadorIndefinido.Should().Throw<ExcecaoNaoEncontrado>();

        //}
    }
}
