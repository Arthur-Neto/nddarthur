using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Enderecos;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Enderecos.Excecoes;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Data.Features.Destinatarios;
using Projeto_NFe.Infra.Data.Features.Emitentes;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using Projeto_NFe.Infra.Data.Features.Transportadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integracao.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoIntegracaoTestes
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        private IDestinatarioRepositorio _destinatarioRepositorio;
        private IEmitenteRepositorio _emitenteRepositorio;
        private ITransportadorRepositorio _transportadorRepositorio;
        private Endereco _endereco;
        private IEnderecoServico _enderecoServico;

        [SetUp]
        public void SetUp()
        {
            _endereco = new Endereco();
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _destinatarioRepositorio = new DestinatarioRepositorioSql();
            _emitenteRepositorio = new EmitenteRepositorioSql();
            _transportadorRepositorio = new TransportadorRepositorioSql();
            _enderecoServico = new EnderecoServico(_enderecoRepositorio, _destinatarioRepositorio, _emitenteRepositorio, _transportadorRepositorio);

            BaseSqlTeste.SemearBancoParaEndereco();
        }

        [Test]
        public void Endereco_Integracao_Inserir_EsperadoOK()
        {
            _endereco = EnderecoObjetoMae.ObterValido();

            var endereco = _enderecoServico.Inserir(_endereco);

            var enderecoInserido = _enderecoRepositorio.ObterPorId(endereco.ID);
            enderecoInserido.ID.Should().Be(endereco.ID);
            endereco.Numero.Should().Be(_endereco.Numero);
        }

        [Test]
        public void Endereco_Integracao_Inserir_CepInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = string.Empty;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoCepInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_CepInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = string.Empty;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoCepInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Inserir_BairroInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = string.Empty;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoBairroInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_BairroInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = string.Empty;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoBairroInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Inserir_CidadeInvalida_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = string.Empty;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoCidadeInvalida>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_CidadeInvalida_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = string.Empty;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoCidadeInvalida>();
        }

        [Test]
        public void Endereco_Integracao_Inserir_NumeroInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoNumeroInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_NumeroInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoNumeroInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Inserir_PaisInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = string.Empty;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoPaisInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_PaisInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = string.Empty;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoPaisInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Inserir_RuaInvalida_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = string.Empty;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoRuaInvalida>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_RuaInvalida_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = string.Empty;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoRuaInvalida>();
        }

        [Test]
        public void Endereco_Integracao_Inserir_UFInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = string.Empty;

            Action action = () => _enderecoServico.Inserir(_endereco);

            action.Should().Throw<ExcecaoUFInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_UFInvalido_EsperadoFalha()
        {
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = string.Empty;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoUFInvalido>();
        }


        [Test]
        public void Endereco_Integracao_Deletar_EsperadoOK()
        {
            _endereco = EnderecoObjetoMae.ObterValido();

            var endereco = _enderecoServico.Inserir(_endereco);

            var enderecoDeletado = _enderecoServico.Deletar(endereco.ID);

            var enderecoBuscar = _enderecoServico.ObterPorId(endereco.ID);
            enderecoBuscar.Should().BeNull();
            enderecoDeletado.Should().BeTrue();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_EsperadoOK()
        {
            _endereco.ID = 1;

            var endereco = _enderecoServico.ObterPorId(_endereco.ID);
            endereco.Numero = 123445;

            var enderecoAtualizado = _enderecoServico.Atualizar(endereco);

            var enderecoBuscar = _enderecoServico.ObterPorId(enderecoAtualizado.ID);
            enderecoBuscar.ID.Should().Be(enderecoAtualizado.ID);
            enderecoAtualizado.ID.Should().Be(endereco.ID);
        }

        [Test]
        public void Endereco_Integracao_ObterPorId_EsperadoOK()
        {
            _endereco = EnderecoObjetoMae.ObterValido();

            var enderecoInserido = _enderecoServico.Inserir(_endereco);

            var endereco = _enderecoServico.ObterPorId(enderecoInserido.ID);

            endereco.ID.Should().Be(enderecoInserido.ID);
        }

        [Test]
        public void Endereco_Integracao_ObterPorId_IDZero_EsperadoFalha()
        {
            _endereco.ID = 0;
            
            Action action = () => _enderecoServico.ObterPorId(_endereco.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Deletar_IDZero_EsperadoFalha()
        {
            _endereco.ID = 0;
            
            Action action = () => _enderecoServico.Deletar(_endereco.ID);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Endereco_Integracao_Deletar_IDInvalido_EsperadoFalso()
        {
            _endereco.ID = 25;

           var deletado = _enderecoServico.Deletar(_endereco.ID);

            deletado.Should().BeFalse();
        }

        [Test]
        public void Endereco_Integracao_Atualizar_IDZero_EsperadoFalha()
        {
            _endereco.ID = 0;

            Action action = () => _enderecoServico.Atualizar(_endereco);

            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Endereco_Integracao_ObterTodos_EsperadoOK()
        {
            var listaEnderecos = _enderecoServico.ObterTodos();

            listaEnderecos.Count.Should().BeGreaterThan(0);
        }
    }
}
