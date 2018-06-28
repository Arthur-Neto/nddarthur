using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Enderecos;
using Projeto_NFe.Comuns.Testes.Features.Enderecos;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.Enderecos.Excecoes;
using Projeto_NFe.Dominio.Features.Transportadores;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Aplicacao.Testes.Features.Enderecos
{
    [TestFixture]
    public class EnderecoAplicacaoTestes
    {
        private IEnderecoServico _enderecoServico;
        private Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        private Mock<IDestinatarioRepositorio> _mockDestinatarioRepositorio;
        private Mock<IEmitenteRepositorio> _mockEmitenteRepositorio;
        private Mock<ITransportadorRepositorio> _mockTransportadorRepositorio;
        Endereco _endereco;

        [SetUp]
        public void SetUp()
        {
            _endereco = new Endereco();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockDestinatarioRepositorio = new Mock<IDestinatarioRepositorio>();
            _mockEmitenteRepositorio = new Mock<IEmitenteRepositorio>();
            _mockTransportadorRepositorio = new Mock<ITransportadorRepositorio>();
            _enderecoServico = new EnderecoServico(_mockEnderecoRepositorio.Object,_mockDestinatarioRepositorio.Object,_mockEmitenteRepositorio.Object,_mockTransportadorRepositorio.Object);
        }

        [Test]
        public void Endereco_Aplicacao_Inserir_EsperadoOK()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _mockEnderecoRepositorio
                .Setup(er => er.Inserir(_endereco))
                .Returns(new Endereco { ID = 1 });

            //acao
            var novoEndereco = _enderecoServico.Inserir(_endereco);


            //verificação
            _mockEnderecoRepositorio.Verify(er => er.Inserir(_endereco));
            novoEndereco.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_EsperadoOK()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 6;
            _mockEnderecoRepositorio
                .Setup(er => er.Atualizar(_endereco))
                .Returns(_endereco);

            //acao
            var novoEndereco = _enderecoServico.Atualizar(_endereco);

            //verificar
            _mockEnderecoRepositorio.Verify(er => er.Atualizar(_endereco));
            novoEndereco.Numero.Should().Be(_endereco.Numero);
        }

        [Test]
        public void Endereco_Aplicacao_Obter_EsperadoOK()
        {
            //cenario
            long id = 1;
            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            //acao
            var endereco = _enderecoServico.ObterPorId(id);

            //verificar
            _mockEnderecoRepositorio.Verify(er => er.ObterPorId(id));
            endereco.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Endereco_Aplicacao_ObterTodos_EsperadoOK()
        {
            //cenario
            _mockEnderecoRepositorio
                .Setup(er => er.ObterTodos())
                .Returns(new List<Endereco> { new Endereco { ID = 1 }, new Endereco { ID = 2 } });

            //acao
            IList<Endereco> enderecos = _enderecoServico.ObterTodos();


            //verificar
            _mockEnderecoRepositorio.Verify(er => er.ObterTodos());
            enderecos.Count.Should().Be(2);
            enderecos[0].ID.Should().Be(1);
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_EsperadoOK()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _mockEnderecoRepositorio
                .Setup(er => er.Deletar(_endereco.ID))
                .Returns(true);

            //acao
            var resultado = _enderecoServico.Deletar(_endereco.ID);

            //cenario
            _mockEnderecoRepositorio.Verify(er => er.Deletar(_endereco.ID));
            resultado.Should().BeTrue();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_DestinatarioValido_EsperadoFalha()
        {
            long id = 1;
            //cenario
            _mockDestinatarioRepositorio.Setup(dr => dr.ObterPorEnderecoID(id))
                .Returns(new Destinatario());

            //acao;
            Action action= ()=> _enderecoServico.Deletar(id);

            //cenario
            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_EmitenteValido_EsperadoFalha()
        {
            long id = 1;
            //cenario
            _mockEmitenteRepositorio.Setup(dr => dr.ObterPorEnderecoID(id))
                .Returns(new Emitente());

            //acao;
            Action action = () => _enderecoServico.Deletar(id);

            //cenario
            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_TransportadorValido_EsperadoFalha()
        {
            long id = 1;
            //cenario
            _mockTransportadorRepositorio.Setup(dr => dr.ObterPorEnderecoID(id))
                .Returns(new Transportador ());

            //acao;
            Action action = () => _enderecoServico.Deletar(id);

            //cenario
            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }

        [Test]
        public void Endereco_Aplicacao_Deletar_IDInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.ID = -1;

            //acao
            Action action = () => _enderecoServico.Deletar(_endereco.ID);

            //verificar
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Obter_IDInvalido_EsperadoFalha()
        {
            //cenario
            long id = -1;

            //acao
            Action action = () => _enderecoServico.ObterPorId(id);

            //verficar
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_IDInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.ID = -1;

            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);

            //verificar
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_CepInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = String.Empty;

            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);

            //verificar
            action.Should().Throw<ExcecaoCepInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Inserir_CepInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cep = String.Empty;
            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);

            //verificar
            action.Should().Throw<ExcecaoCepInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Inserir_BairroInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = String.Empty;

            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);

            //verificar
            action.Should().Throw<ExcecaoBairroInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_BairroInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Bairro = String.Empty;

            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);
            //verificar
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoBairroInvalido>();
        }

        [Test]
        public void Endereco_Aplicacao_Inserir_CidadeInvalida_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = String.Empty;
            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);
            //verificar
            action.Should().Throw<ExcecaoCidadeInvalida>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_CidadeInvalida_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Cidade = String.Empty;
            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);
            //verificar
            action.Should().Throw<ExcecaoCidadeInvalida>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Inserir_PaisInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = String.Empty;
            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);
            //verificar
            action.Should().Throw<ExcecaoPaisInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_PaisInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Pais = String.Empty;
            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);
            //verificar
            action.Should().Throw<ExcecaoPaisInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Endereco_Aplicacao_Inserir_RuaInvalida_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = String.Empty;
            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);
            //verificar
            action.Should().Throw<ExcecaoRuaInvalida>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_RuaInvalida_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Rua = String.Empty;
            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);
            //verificar
            action.Should().Throw<ExcecaoRuaInvalida>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Endereco_Aplicacao_Inserir_UFInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = String.Empty;
            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);
            //verificar
            action.Should().Throw<ExcecaoUFInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_UFInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.UF = String.Empty;
            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);
            //verificar
            action.Should().Throw<ExcecaoUFInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Inserir_NumeroInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;
            //acao
            Action action = () => _enderecoServico.Inserir(_endereco);
            //verificar
            action.Should().Throw<ExcecaoNumeroInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Endereco_Aplicacao_Atualizar_NumeroInvalido_EsperadoFalha()
        {
            //cenario
            _endereco = EnderecoObjetoMae.ObterValido();
            _endereco.Numero = 0;
            //acao
            Action action = () => _enderecoServico.Atualizar(_endereco);
            //verificar
            action.Should().Throw<ExcecaoNumeroInvalido>();
            _mockEnderecoRepositorio.VerifyNoOtherCalls();
        }
    }
}
