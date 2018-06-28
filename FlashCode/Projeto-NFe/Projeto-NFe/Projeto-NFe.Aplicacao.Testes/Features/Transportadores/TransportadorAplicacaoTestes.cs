using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Transportadores;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Transportadores;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Aplicacao.Testes.Features.Transportadores
{
    [TestFixture]
    public class TransportadorAplicacaoTestes
    {
        private ITransportadorServico _transportadorServico;
        private Mock<ITransportadorRepositorio> _mockTransportadorRepositorio;
        private Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        private Mock<INotaFiscalRepositorio> _mockNotaFiscalRepositorio;
        Transportador _transportador;

        [SetUp]
        public void SetUp()
        {
            _transportador = new Transportador();
            _mockTransportadorRepositorio = new Mock<ITransportadorRepositorio>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockNotaFiscalRepositorio = new Mock<INotaFiscalRepositorio>();
            _transportadorServico = new TransportadorServico(_mockTransportadorRepositorio.Object, _mockNotaFiscalRepositorio.Object, _mockEnderecoRepositorio.Object);
        }

        [Test]
        public void Transportador_Aplicacao_Inserir_Pessoa_EsperadoOK()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();

            _mockTransportadorRepositorio
                .Setup(tr => tr.Inserir(_transportador))
                .Returns(new Transportador { ID = 1 });

            var transportador = _transportadorServico.Inserir(_transportador);

            _mockTransportadorRepositorio.Verify(tr => tr.Inserir(_transportador));
            transportador.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_Aplicacao_ObterPorId_IDInvalido_EsperadoNulo()
        {
            long id = 234;

            _mockTransportadorRepositorio
                .Setup(dr => dr.ObterPorId(id));

            var transportador = _transportadorServico.ObterPorId(id);

            _mockTransportadorRepositorio.Verify(dr => dr.ObterPorId(id));
            transportador.Should().BeNull();
        }

        [Test]
        public void Transportador_Aplicacao_Inserir_Empresa_EsperadoOK()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();

            _mockTransportadorRepositorio
                .Setup(tr => tr.Inserir(_transportador))
                .Returns(new Transportador { ID = 1 });

            var transportador = _transportadorServico.Inserir(_transportador);

            _mockTransportadorRepositorio.Verify(tr => tr.Inserir(_transportador));
            transportador.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_EsperadoOK()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Nome = "zzz";

            _mockTransportadorRepositorio
                .Setup(tr => tr.Atualizar(_transportador))
                .Returns(new Transportador { Nome = "zzz" });

            var novoTransportador = _transportadorServico.Atualizar(_transportador);

            _mockTransportadorRepositorio.Verify(dr => dr.Atualizar(_transportador));
            novoTransportador.Nome.Should().Be(_transportador.Nome);
        }

        [Test]
        public void Transportador_Aplicacao_Obter_EsperadoOK()
        {
            int id = 1;

            _mockTransportadorRepositorio
                .Setup(tr => tr.ObterPorId(id))
                .Returns(new Transportador { ID = id, Endereco = new Endereco { ID = 1 } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            var transportador = _transportadorServico.ObterPorId(id);

            _mockTransportadorRepositorio.Verify(tr => tr.ObterPorId(id));
            transportador.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Transportador_Aplicacao_Deletar_EsperadoOK()
        {
            var transportador = TransportadorObjetoMae.ObterValidoPessoa();

            _mockTransportadorRepositorio
                .Setup(tr => tr.Deletar(transportador.ID))
                .Returns(true);

            var transportadorDeletado = _transportadorServico.Deletar(transportador.ID);

            transportadorDeletado.Should().BeTrue();
        }

        [Test]
        public void Transportador_Aplicacao_ObterTodos_EsperadoOK()
        {
            var id = 1;

            _mockTransportadorRepositorio
                .Setup(tr => tr.ObterTodos())
                .Returns(new List<Transportador> { new Transportador { ID = 1, Endereco = new Endereco { ID = 1 } } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            IList<Transportador> transportadores = _transportadorServico.ObterTodos();

            _mockTransportadorRepositorio.Verify(tr => tr.ObterTodos());
            transportadores.Count.Should().Be(1);
        }

        [Test]
        public void Transportador_Aplicacao_ObterTodos_TransportadorNulo_EsperadoOK()
        {
            _mockTransportadorRepositorio
                .Setup(tr => tr.ObterTodos());

            IList<Transportador> transportadores = _transportadorServico.ObterTodos();

            _mockTransportadorRepositorio.Verify(tr => tr.ObterTodos());
            transportadores.Should().BeNull();
        }

        [Test]
        public void Transportador_Aplicacao_Inserir_Pessoa_NomeInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoPessoa();
            transportador.Nome = String.Empty;

            Action action = () => _transportadorServico.Inserir(transportador);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Transportador_Aplicacao_Inserir_RazaoSocialInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.RazaoSocial = String.Empty;

            Action action = () => _transportadorServico.Inserir(transportador);
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Transportador_Aplicacao_Inserir_Cpf_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoPessoa();
            transportador.Cpf = CpfObjetoMae.ObterPrimeiroDigitoInvalido();

            Action action = () => _transportadorServico.Inserir(transportador);
            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Transportador_Aplicacao_Inserir_Cnpj_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.Cnpj = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();

            Action action = () => _transportadorServico.Inserir(transportador);
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.ID = -1;

            Action action = () => _transportadorServico.Atualizar(transportador);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_NomeInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoPessoa();
            transportador.Nome = String.Empty;

            Action action = () => _transportadorServico.Inserir(transportador);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_RazaoSocialInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.RazaoSocial = String.Empty;

            Action action = () => _transportadorServico.Inserir(transportador);
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_CpfInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoPessoa();
            transportador.Cpf = CpfObjetoMae.ObterSegundoDigitoInvalido();

            Action action = () => _transportadorServico.Inserir(transportador);
            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Transportador_Aplicacao_Atualizar_CnpjInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.Cnpj = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();

            Action action = () => _transportadorServico.Inserir(transportador);
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Transportador_Aplicacao_Obter_IdInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.ID = 0;

            Action action = () => _transportadorServico.ObterPorId(transportador.ID);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Transportador_Aplicacao_Deletar_IdInvalido_EsperadoFalha()
        {
            var transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            transportador.ID = 0;

            Action action = () => _transportadorServico.Deletar(transportador.ID);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
            _mockTransportadorRepositorio.VerifyNoOtherCalls();
        }


        [Test]
        public void Transportador_Aplicacaos_Inserir_Empresa_ComCpf_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cpf = CpfObjetoMae.ObterValidoSemPontosTracos();

            Action action = () => _transportadorServico.Inserir(_transportador);

            _mockTransportadorRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }
        [Test]
        public void Transportador_Aplicacao_Inserir_Empresa_ComCnpjNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoEmpresa();
            _transportador.Cnpj = null;

            Action action = () => _transportadorServico.Inserir(_transportador);
            
            action.Should().Throw<ExcecaoCNPJInvalido>();
            _mockTransportadorRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Transportador_Aplicacao_Inserir_Pessoa_ComCpfNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cpf = null;

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoCpfNaoDefinido>();
            _mockTransportadorRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Transportador_Aplicacao_Inserir_Pessoa_ComCnpj_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos();

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoPessoaComCnpj>();
            _mockTransportadorRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Transportador_Aplicacao_Inserir_Pessoa_ComRazaoSocial_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.RazaoSocial = "RazaoSocial";

            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
            _mockTransportadorRepositorio.VerifyNoOtherCalls();
        }
        [Test]
        public void Transportador_Aplicacao_Inserir_ComEnderecoNulo_EsperadoFalha()
        {
            _transportador = TransportadorObjetoMae.ObterValidoPessoa();
            _transportador.Endereco = null;
            Action action = () => _transportadorServico.Inserir(_transportador);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
            _mockTransportadorRepositorio.VerifyNoOtherCalls();
        }

        [Test]
        public void Transportador_Aplicacao_Deletar_ChaveEstrangeira_EsperadoFalha()
        {
            _transportador.ID = 1;

            _mockNotaFiscalRepositorio.
                Setup(nfr => nfr.ObterPorTransportadorID(_transportador.ID))
                .Returns(new NotaFiscal { ID = 1 });

            Action action = () => _transportadorServico.Deletar(_transportador.ID);
            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }
    }
}
