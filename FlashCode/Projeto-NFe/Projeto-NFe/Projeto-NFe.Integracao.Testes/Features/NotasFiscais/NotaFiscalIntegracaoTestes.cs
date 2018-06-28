using FluentAssertions;
using NUnit.Framework;
using Projeto_NFe.Aplicacao.Features.NotasFiscais;
using Projeto_NFe.Comuns.Testes.Features.Base;
using Projeto_NFe.Comuns.Testes.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.Destinatarios;
using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Dominio.Features.ProdutosNFe;
using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Data.Features.Destinatarios;
using Projeto_NFe.Infra.Data.Features.Emitentes;
using Projeto_NFe.Infra.Data.Features.Enderecos;
using Projeto_NFe.Infra.Data.Features.NotasFiscais;
using Projeto_NFe.Infra.Data.Features.ProdutosNFe;
using Projeto_NFe.Infra.Data.Features.Transportadores;
using Projeto_NFe.Infra.Pdf.Features.NotasFiscais;
using Projeto_NFe.Infra.Xml.Features.NotasFiscais;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Integracao.Testes.Features.NotasFiscais
{
    [TestFixture]
    class NotaFiscalIntegracaoTestes
    {
        private INotaFiscalServico _notaFiscalServico;
        private INotaFiscalRepositorio _notaFiscalRepositorio;
        private INotaFiscalExportacao _notaFiscalExportacaoXML;
        private INotaFiscalExportacao _notaFiscalExportacaoPDF;
        private IEnderecoRepositorio _enderecoRepositorio;
        private IEmitenteRepositorio _emitenteRepositorio;
        private ITransportadorRepositorio _transportadorRepositorio;
        private IDestinatarioRepositorio _destinatarioRepositorio;
        private IProdutoNFeRepositorio _produtoNfeRepositorio;
        private Random _random;
        private NotaFiscal _notaFiscal;
        private string _caminhoXml;
        private string _caminhoPdf;

        [SetUp]
        public void SetUp()
        {
            _caminhoXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _caminhoXml = Path.Combine(_caminhoXml, "NotaFiscal.xml");

            _caminhoPdf = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            _caminhoPdf = Path.Combine(_caminhoPdf, "NotaFiscal.pdf");

            _notaFiscal = new NotaFiscal();
            _produtoNfeRepositorio = new ProdutoNFeRepositorioSql();
            _notaFiscalRepositorio = new NotaFiscalRepositorioSql();
            _notaFiscalExportacaoXML = new NotaFiscalXmlRepository(_caminhoXml);
            _notaFiscalExportacaoPDF = new NotaFiscalPdf(_caminhoPdf);
            _enderecoRepositorio = new EnderecoRepositorioSql();
            _emitenteRepositorio = new EmitenteRepositorioSql();
            _transportadorRepositorio = new TransportadorRepositorioSql(); ;
            _destinatarioRepositorio = new DestinatarioRepositorioSql();
            _random = new Random();
            _notaFiscalServico = new NotaFiscalServico(_notaFiscalRepositorio, _notaFiscalExportacaoXML, _notaFiscalExportacaoPDF, _enderecoRepositorio, _emitenteRepositorio, _destinatarioRepositorio, _transportadorRepositorio,_produtoNfeRepositorio, _random);

            BaseSqlTeste.SemearBancoParaNotaFiscal();
        }

        [Test]
        public void NotaFiscal_Integracao_Inserir_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            _notaFiscal = _notaFiscalServico.Inserir(_notaFiscal);

            var notaFiscal = _notaFiscalServico.ObterPorId(_notaFiscal.ID);

            notaFiscal.ID.Should().Be(_notaFiscal.ID);
        }

        [Test]
        public void NotaFiscal_Integracao_Atualizar_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            _notaFiscal = _notaFiscalServico.Atualizar(_notaFiscal);

            var notaFiscal = _notaFiscalServico.ObterPorId(_notaFiscal.ID);

            notaFiscal.NaturezaOperacao.Should().Be(_notaFiscal.NaturezaOperacao);
        }

        [Test]
        public void NotaFiscal_Integracao_Deletar_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            _notaFiscal = _notaFiscalServico.Inserir(_notaFiscal);

            var notaFiscal = _notaFiscalServico.Deletar(_notaFiscal.ID);

            var buscar = _notaFiscalServico.ObterPorId(_notaFiscal.ID);

            //buscar.Should().BeNull();
            notaFiscal.Should().BeTrue();
        }

        [Test]
        public void NotaFiscal_Integracao_ObterPorId_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            _notaFiscal = _notaFiscalServico.Inserir(_notaFiscal);
                        
            var buscar = _notaFiscalServico.ObterPorId(_notaFiscal.ID);

            buscar.ID.Should().Be(_notaFiscal.ID);
        }

        [Test]
        public void NotaFiscal_Integracao_ObterTodos_EsperadoOK()
        {
            var id = 1;



            var notasFiscais = _notaFiscalServico.ObterTodos();

            notasFiscais.First().ID.Should().Be(id);
        }

        [Test]
        public void NotaFiscal_Integracao_EmitirNota_EsperadoOK()
        {
            _notaFiscal = NotaFiscalObjetoMae.ObterValidoNotaFiscal();

            var notasFiscais = _notaFiscalServico.EmitirNota(_notaFiscal);

            var buscar = _notaFiscalServico.ObterPorId(_notaFiscal.ID);

            buscar.Should().BeNull();
            notasFiscais.Should().BeTrue();
        }

    }
}
