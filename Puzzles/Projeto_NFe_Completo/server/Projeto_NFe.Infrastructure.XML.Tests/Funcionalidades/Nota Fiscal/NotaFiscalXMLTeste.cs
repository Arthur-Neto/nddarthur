using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_NFe.Common.Tests.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Infrastructure.XML.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using System.IO;
using FluentAssertions;
using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Documentos;

namespace Projeto_NFe.Infrastructure.XML.Tests.Funcionalidades.Nota_Fiscal
{
    [TestFixture]
    public class NotaFiscalXMLTeste
    {
        Emitente _emitente;
        Destinatario _destinatario;
        Transportador _transportador;
        NotaFiscal _notaFiscal;
        Produto _produto;
        ProdutoNotaFiscal _produtoNotaFiscal;
        Endereco _endereco;

        NotaFiscalRepositorioXML _notaFiscalRepositorioXML;

        string _caminho = @"..\..\..\NotaFiscal.xml";

        [SetUp]
        public void IniciarCenario()
        {
            _notaFiscalRepositorioXML = new NotaFiscalRepositorioXML();

            _endereco = ObjectMother.PegarEnderecoValido();

            _emitente = ObjectMother.PegarEmitenteValido(_endereco, new Documento("99.327.235/0001-50", TipoDocumento.CNPJ));
            _destinatario = ObjectMother.PegarDestinatarioValidoComCNPJ(_endereco, new Documento("13.106.137/0001-77", TipoDocumento.CNPJ));
            _transportador = ObjectMother.PegarTransportadorValidoComCNPJ(_endereco, new Documento("11.222.333/0001-81", TipoDocumento.CNPJ));
            
            _notaFiscal = ObjectMother.PegarNotaFiscalValida(_emitente, _destinatario, _transportador);
            _notaFiscal.DataEmissao = DateTime.Now;
            _produto = ObjectMother.ObterProdutoValido();
            _produtoNotaFiscal = ObjectMother.PegarProdutoNotaFiscalValido(_produto, _notaFiscal);

            _notaFiscal.Produtos = new List<ProdutoNotaFiscal>();
            _notaFiscal.Produtos.Add(_produtoNotaFiscal);

            _notaFiscal.CalcularValoresTotais();
            _notaFiscal.GerarChaveDeAcesso(new Random());
            _notaFiscal.DataEmissao = DateTime.Now;
        }

        [Test]
        public void NotaFiscal_InfraXML_Serializar_Sucesso()
        {
            string resultado = _notaFiscalRepositorioXML.Serializar(_notaFiscal);

            resultado.Should().NotBeNull();
            resultado.Should().NotBeEmpty();
        }

        [Test]
        public void NotaFiscal_InfraXML_SerializarParaArquivo_Sucesso()
        {
            _notaFiscalRepositorioXML.Serializar(_notaFiscal, _caminho);

            Action acaoParaVerificarSeArquivoExiste = () => File.Exists(_caminho);

            acaoParaVerificarSeArquivoExiste.Should().Equals(true);

            File.Delete(_caminho);
        }
    }
}
