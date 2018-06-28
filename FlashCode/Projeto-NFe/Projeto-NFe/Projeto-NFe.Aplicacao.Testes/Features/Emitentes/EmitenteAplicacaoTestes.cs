using FluentAssertions;
using Moq;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.Emitentes;
using Projeto_NFe.Comuns.Testes.Features.Emitentes;
using Projeto_NFe.Comuns.Testes.Features.Cnpjs;
using Projeto_NFe.Dominio.Excecoes;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Emitentes.Excercoes;
using System;
using System.Collections.Generic;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;

namespace Projeto_NFe.Aplicacao.Testes.Features.Emitentes
{
    [TestFixture]
    public class EmitenteAplicacaoTestes
    {
        Emitente _emitente;
        private IEmitenteServico _emitenteServico;
        private Mock<IEmitenteRepositorio> _mockEmitenteRepositorio;
        private Mock<IEnderecoRepositorio> _mockEnderecoRepositorio;
        private Mock<INotaFiscalRepositorio> _mockNotaFiscalRepositorio;

        [SetUp]
        public void SetUp()
        {
            _emitente = new Emitente();
            _mockEmitenteRepositorio = new Mock<IEmitenteRepositorio>();
            _mockEnderecoRepositorio = new Mock<IEnderecoRepositorio>();
            _mockNotaFiscalRepositorio = new Mock<INotaFiscalRepositorio>();
            _emitenteServico = new EmitenteServico(_mockEmitenteRepositorio.Object, _mockNotaFiscalRepositorio.Object, _mockEnderecoRepositorio.Object);
        }

        [Test]
        public void Emitente_Aplicacao_Inserir_EsperadoOK()
        {
            //cenario
            int id = 1;
            _emitente = EmitenteObjetoMae.ObterValido();
            _mockEmitenteRepositorio
                .Setup(er => er.Inserir(_emitente))
                .Returns(new Emitente { ID = id });

            //acao
            var novoEmitente = _emitenteServico.Inserir(_emitente);

            //verificar
            _mockEmitenteRepositorio.Verify(er => er.Inserir(_emitente));
            novoEmitente.ID.Should().Be(id);
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_EsperadoOK()
        {
            //cenario
            var cpnj = CnpjObjetoMae.ObterValidoComPontosTracos();
            _emitente = EmitenteObjetoMae.ObterValido();
            _mockEmitenteRepositorio
                .Setup(er => er.Atualizar(_emitente))
                .Returns(new Emitente { CNPJ = cpnj });

            //acao
            var novoEmitente = _emitenteServico.Atualizar(_emitente);

            //verificar
            _mockEmitenteRepositorio.Verify(er => er.Atualizar(_emitente));
            novoEmitente.CNPJ.Should().Be(cpnj);
        }

        [Test]
        public void Emitente_Aplicacao_ObterPorId_EsperadoOK()
        {
            //cenario
            int id = 1;
            _mockEmitenteRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Emitente { ID = id, Endereco = new Endereco { ID = 1 } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            //acao
            var emitente = _emitenteServico.ObterPorId(id);

            //verificar
            _mockEmitenteRepositorio.Verify(er => er.ObterPorId(id));
            emitente.ID.Should().Be(id);
        }

        [Test]
        public void Emitente_Aplicacao_ObterPorId_IDInvalido_EsperadoOK()
        {
            //cenario
            int id = 1;
            _mockEmitenteRepositorio
                .Setup(er => er.ObterPorId(id));
            
            //acao
            var emitente = _emitenteServico.ObterPorId(id);

            //verificar
            _mockEmitenteRepositorio.Verify(er => er.ObterPorId(id));
            emitente.Should().BeNull();
        }

        [Test]
        public void Emitente_Aplicacao_ObterTodos_EsperadoOK()
        {
            //cenario
            var id = 1;

            _mockEmitenteRepositorio
                .Setup(er => er.ObterTodos())
                .Returns(new List<Emitente> { new Emitente { ID = 1, Endereco = new Endereco { ID = 1 } } });

            _mockEnderecoRepositorio
                .Setup(er => er.ObterPorId(id))
                .Returns(new Endereco { ID = 1 });

            //acao
            IList<Emitente> listaEmitentes = _emitenteServico.ObterTodos();

            //verificar
            _mockEmitenteRepositorio.Verify(er => er.ObterTodos());
            listaEmitentes.Count.Should().Be(1);
        }

        [Test]
        public void Emitente_Aplicacao_Deletar_EsperadoOK()
        {
            //cenario
            _emitente = EmitenteObjetoMae.ObterValido();

            _mockEmitenteRepositorio
                .Setup(er => er.Deletar(_emitente.ID))
                .Returns(true);

            //acao
            var resultado = _emitenteServico.Deletar(_emitente.ID);

            //verificar
            _mockEmitenteRepositorio.Verify(er => er.Deletar(_emitente.ID));
            resultado.Should().BeTrue();
        }

        [Test]
        public void Emitente_Aplicacao_ObterTodos_EmitentesNulo_EsperadoOK()
        {
            _mockEmitenteRepositorio
                .Setup(dr => dr.ObterTodos());

            IList<Emitente> emitenetes = _emitenteServico.ObterTodos();

            _mockEmitenteRepositorio.Verify(er => er.ObterTodos());
            emitenetes.Should().BeNull();
        }

        [Test]
        public void Emitente_Aplicacao_Deletar_IDInvalido_EsperadoFalha()
        {
            //cenario
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.ID = -1;

            //acao
            Action action = () => _emitenteServico.Deletar(_emitente.ID);

            //verificar
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Emitente_Aplicacao_Obter_IDInvalido_EsperadoFalha()
        {
            //cenario
            long id = -1;

            //action
            Action action = () => _emitenteServico.ObterPorId(id);

            //verificar
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_IDInvalido_EsperadoFalha()
        {
            //cenario
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.ID = -1;
            
            //action
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //verificar
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoIdentificadorInvalido>();
        }

        [Test]
        public void Emitente_Aplicacao_Deletar_ChaveEstrangeira_EsperadoFalha()
        {
            _emitente.ID = 1;

            _mockNotaFiscalRepositorio.
                Setup(nfr => nfr.ObterPorEmitenteID(_emitente.ID))
                .Returns(new NotaFiscal { ID = 1 });

            Action action = () => _emitenteServico.Deletar(_emitente.ID);
            action.Should().Throw<ExcecaoChaveEstrangeira>();
        }
        
        [Test]
        public void Emitente_Aplicacao_Inserir_EnderecoNulo_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;
            //Ação
            Action action = () => _emitenteServico.Inserir(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }
        [Test]
        public void Emitente_Aplicacao_Inserir_NomeFantasiaInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = String.Empty;
            //Ação
            Action action = () => _emitenteServico.Inserir(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoNomeEmBranco>();
        }
        [Test]
        public void Emitente_Aplicacao_Inserir_CNPJInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = CnpjObjetoMae.ObterSegundoDigitoInvalido();
            //Ação
            Action action = () => _emitenteServico.Inserir(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Emitente_Aplicacao_Inserir_InscricaoEstadualnvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = String.Empty;
            //Ação
            Action action = () => _emitenteServico.Inserir(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
        }
        [Test]
        public void Emitente_Aplicacao_Inserir_InscricaoMunicipalInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = String.Empty;
            //Ação
            Action action = () => _emitenteServico.Inserir(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
        }       
        [Test]
        public void Emitente_Aplicacao_Atualizar_EnderecoNulo_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.Endereco = null;
            //Ação
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoEnderecoEmBranco>();
        }
        [Test]
        public void Emitente_Aplicacao_Atualizar_NomeFantasiaInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.NomeFantasia = String.Empty;
            //Ação
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoNomeEmBranco>();
        }
        [Test]
        public void Emitente_Aplicacao_Atualizar_CNPJInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.CNPJ = CnpjObjetoMae.ObterPrimeiroDigitoInvalido();
            //Ação
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoCNPJInvalido>();
        }
        [Test]
        public void Emitente_Aplicacao_Atualizar_InscricaoEstadualnvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoEstadual = String.Empty;
            //Ação
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoInscricaoEstadualInvalido>();
        }
        [Test]
        public void Emitente_Aplicacao_Atualizar_InscricaoMunicipalInvalido_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.InscricaoMunicipal = String.Empty;
            //Ação
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoInscricaoMunicipalInvalido>();
        }

        [Test]
        public void Emitente_Aplicacao_Atualizar_RazaoSocialInvalida_EsperadoFalha()
        {
            //cenário
            _emitente = EmitenteObjetoMae.ObterValido();
            _emitente.RazaoSocial = String.Empty;

            //Action
            Action action = () => _emitenteServico.Atualizar(_emitente);

            //Verificação
            _mockEmitenteRepositorio.VerifyNoOtherCalls();
            action.Should().Throw<ExcecaoRazaoSocialInvalida>();
        }
    }
}
