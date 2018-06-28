using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Destinatarios;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Comuns.Testes.Features.Cpfs;
using Projeto_NFe.Comuns.Testes.Features.Destinatarios;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using System;
using System.Collections.Generic;

namespace Projeto_NFe.Aplicacao.Testes.Features.Destinatarios
{
    [TestFixture]
    public class DestinatarioAplicacaoTestes
    {
        private IDestinatarioServico _destinatarioServico;
        private Mock<IDestinatarioRepositorio> _mockDestinatarioRepositorio;
        private Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        private Mock<INotaFiscalRepositorio> _mockNotaFiscalRepositorio;
        Destinatario _destinatario;

        [SetUp]
        public void SetUp()
        {
            _destinatario = new Destinatario();
            _mockDestinatarioRepositorio = new Mock<IDestinatarioRepositorio>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockNotaFiscalRepositorio = new Mock<INotaFiscalRepositorio>();
            _destinatarioServico = new DestinatarioServico(_mockDestinatarioRepositorio.Object, _mockNotaFiscalRepositorio.Object, _mockEnderecoRepositorio.Object);
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();

            _mockDestinatarioRepositorio
                .Setup(dr => dr.Inserir(_destinatario))
                .Returns(new Destinatario { ID = 1 });

            var destinatario = _destinatarioServico.Inserir(_destinatario);

            _mockDestinatarioRepositorio.Verify(dr => dr.Inserir(_destinatario));
            destinatario.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Empresa_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();

            _mockDestinatarioRepositorio
                .Setup(dr => dr.Inserir(_destinatario))
                .Returns(new Destinatario { ID = 1 });

            var destinatario = _destinatarioServico.Inserir(_destinatario);

            _mockDestinatarioRepositorio.Verify(dr => dr.Inserir(_destinatario));
            destinatario.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Pessoa_EsperadoOK()
        {
            _destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            _destinatario.Nome = "zzz";

            _mockDestinatarioRepositorio
                .Setup(dr => dr.Atualizar(_destinatario))
                .Returns(new Destinatario { Nome = "zzz" });

            var novoDestinatario = _destinatarioServico.Atualizar(_destinatario);

            _mockDestinatarioRepositorio.Verify(dr => dr.Atualizar(_destinatario));
            novoDestinatario.Nome.Should().Be(_destinatario.Nome);
        }

        [Test]
        public void Destinatario_Aplicacao_Obter_EsperadoOK()
        {
            long id = 1;

            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterPorId(id))
                .Returns(new Destinatario { ID = 1, Endereco = new Endereco { ID = 1 } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            var destinatario = _destinatarioServico.ObterPorId(id);

            _mockDestinatarioRepositorio.Verify(dr => dr.ObterPorId(id));
            destinatario.ID.Should().BeGreaterThan(0);
        }

        [Test]
        public void Destinatario_Aplicacao_Obter_IDInvalido_EsperadoNulo()
        {
            long id = 234;

            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterPorId(id));

            var destinatario = _destinatarioServico.ObterPorId(id);

            _mockDestinatarioRepositorio.Verify(dr => dr.ObterPorId(id));
            destinatario.Should().BeNull();
        }
        [Test]
        public void Destinatario_Aplicacao_Deletar_EsperadoOK()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();

            _mockDestinatarioRepositorio
                .Setup(dr => dr.Deletar(destinatario.ID))
                .Returns(true);

            var destinatarioDeletado = _destinatarioServico.Deletar(destinatario.ID);

            destinatarioDeletado.Should().BeTrue();
        }

        [Test]
        public void Destinatario_Aplicacao_ObterTodos_EsperadoOK()
        {
            var id = 1;

            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterTodos())
                .Returns(new List<Destinatario> { new Destinatario { ID = 1, Endereco = new Endereco { ID = 1 } } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            IList<Destinatario> destinatarios = _destinatarioServico.ObterTodos();

            _mockDestinatarioRepositorio.Verify(er => er.ObterTodos());
            destinatarios.Count.Should().Be(1);
        }

        [Test]
        public void Destinatario_Aplicacao_ObterTodos_RetornoNull_EsperadoOK()
        {
            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterTodos());
            
            IList<Destinatario> destinatarios = _destinatarioServico.ObterTodos();

            _mockDestinatarioRepositorio.Verify(er => er.ObterTodos());
            destinatarios.Should().BeNull();
        }

        [Test]
        public void Destinatario_Aplicacao_ObterTodos_DestinatarioNulo_EsperadoOk()
        {
            _mockDestinatarioRepositorio
                .Setup(dr => dr.ObterTodos());

            IList<Destinatario> destinatarios = _destinatarioServico.ObterTodos();

            _mockDestinatarioRepositorio.Verify(er => er.ObterTodos());
            destinatarios.Should().BeNull();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_NomeInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Nome = String.Empty;

            Action action = () => _destinatarioServico.Inserir(destinatario);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_EnderecoNulo_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Endereco = null;

            Action action = () => _destinatarioServico.Inserir(destinatario);

            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Empresa_RazaoSocialInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.RazaoSocial = String.Empty;

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_EmpresaComCnpjNulo_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.Cnpj = null;

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Destinatario_Aplicacao_Inserir_Empresa_ComCpf_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.Cpf = CpfObjetoMae.ObterPrimeiroDigitoInvalido();

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoEmpresaComCpf>();
        }
        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_CpfInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Cpf = CpfObjetoMae.ObterPrimeiroDigitoInvalido();

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoCPFInvalido>();
        }
        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_CpfNulo_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Cpf = null;

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoCpfNaoDefinido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_ComCnpj_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Cnpj = CnpjObjetoMae.ObterValidoComPontosTracos();

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoPessoaComCnpj>();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Pessoa_ComRazaoSocial_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.RazaoSocial = "RazãoSocial";

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoPessoaComRazaoSocial>();
        }

        [Test]
        public void Destinatario_Aplicacao_Inserir_Empresa_CnpjInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.Cnpj = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Empresa_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.ID = -1;

            Action action = () => _destinatarioServico.Atualizar(destinatario);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Pessoa_NomeInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Nome = String.Empty;

            Action action = () => _destinatarioServico.Inserir(destinatario);

            action.Should().Throw<ExcecaoNomeEmBranco>();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Empresa_RazaoSocialInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.RazaoSocial = String.Empty;

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Pessoa_CpfInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoPessoa();
            destinatario.Cpf = CpfObjetoMae.ObterSegundoDigitoInvalido();

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoCPFInvalido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Atualizar_Empresa_CnpjInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.Cnpj = CnpjObjetoMae.ObterSegundoDigitoInvalido();

            Action action = () => _destinatarioServico.Inserir(destinatario);
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Obter_Empresa_ComIdInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.ID = 0;

            Action action = () => _destinatarioServico.ObterPorId(destinatario.ID);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Deletar_EmpresaIdInvalido_EsperadoFalha()
        {
            var destinatario = DestinatarioObjetoMae.ObterValidoEmpresa();
            destinatario.ID = 0;

            Action action = () => _destinatarioServico.Deletar(destinatario.ID);
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Destinatario_Aplicacao_Deletar_ChaveEstrangeira_EsperadoFalha()
        {
            _destinatario.ID = 1;

            _mockNotaFiscalRepositorio.
                Setup(nfr => nfr.ObterPorDestinatarioID(_destinatario.ID))
                .Returns(new NotaFiscal { ID = 1 });

            Action action = () => _destinatarioServico.Deletar(_destinatario.ID);
            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }
    }
}
