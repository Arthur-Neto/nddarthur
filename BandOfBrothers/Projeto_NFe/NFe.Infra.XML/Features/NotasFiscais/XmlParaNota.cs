using NFe.Dominio.Features.Destinatarios;
using NFe.Dominio.Features.Emitentes;
using NFe.Dominio.Features.Produtos;
using NFe.Dominio.Features.Transportadores;
using System.Collections.Generic;

namespace NFe.Infra.XML.Features.NotasFiscais
{
    public class XmlParaNota
    {
        public IList<Produto> PegarProdutos(NotaFiscalModeloXml NotaFiscalModeloXml)
        {
            IList<Produto> listaProdutos = new List<Produto>();

            foreach (var prodDet in NotaFiscalModeloXml.infNFe.det)
            {
                Produto produto = new Produto();

                produto.CodigoProduto = prodDet.Prod.CodigoProduto;
                produto.Descricao = prodDet.Prod.DescricaoProduto;
                produto.Quantidade = prodDet.Prod.Quantidade;
                produto.ValorProduto.ICMS = prodDet.Imposto.Icms.IcmsProduto.Icms;
                produto.ValorProduto.Ipi = prodDet.Imposto.Icms.IcmsProduto.Ipi;
                produto.ValorProduto.Unitario = prodDet.Prod.Unitario;

                listaProdutos.Add(produto);
            }

            return listaProdutos;
        }

        public Transportador PegaTransportador(NotaFiscalModeloXml NotaFiscalModeloXml)
        {
            Transportador transportador = new Transportador();

            transportador.Cnpj = NotaFiscalModeloXml.infNFe.transp.Transporta.CnpjDestinatario;
            transportador.Cpf = NotaFiscalModeloXml.infNFe.transp.Transporta.CnpjDestinatario;
            transportador.InscricaoEstadual = NotaFiscalModeloXml.infNFe.transp.Transporta.InscricaoEstadual;
            transportador.Nome = NotaFiscalModeloXml.infNFe.transp.Transporta.Nome;
            transportador.RazaoSocial = NotaFiscalModeloXml.infNFe.transp.Transporta.Nome;
            transportador.ResponsabilidadeFrete = (Frete)NotaFiscalModeloXml.infNFe.transp.modFrete;
            transportador.Endereco.Estado = NotaFiscalModeloXml.infNFe.transp.Transporta.Estado;
            transportador.Endereco.Municipio = NotaFiscalModeloXml.infNFe.transp.Transporta.Municipio;
            transportador.Endereco.Logradouro = NotaFiscalModeloXml.infNFe.transp.Transporta.Logradouro;
            transportador.Endereco.Bairro = "Valor Não Informado";
            transportador.Endereco.Numero = "s/n";
            transportador.Endereco.Pais = "Brasil";


            return transportador;
        }

        public Destinatario PegaDestinatario(NotaFiscalModeloXml NotaFiscalModeloXml)
        {
            Destinatario destinatario = new Destinatario();

            if (!string.IsNullOrEmpty(NotaFiscalModeloXml.infNFe.dest.CpfDestinatario))
                destinatario.Cpf = NotaFiscalModeloXml.infNFe.dest.CpfDestinatario;
            else
                destinatario.Cnpj = NotaFiscalModeloXml.infNFe.dest.CnpjDestinatario;

            destinatario.Nome = NotaFiscalModeloXml.infNFe.dest.Nome;
            destinatario.RazaoSocial = NotaFiscalModeloXml.infNFe.dest.Nome;
            destinatario.InscricaoEstadual = NotaFiscalModeloXml.infNFe.dest.InscricaoEstadual;
            destinatario.Endereco.Bairro = NotaFiscalModeloXml.infNFe.dest.enderDest.Bairro;
            destinatario.Endereco.Estado = NotaFiscalModeloXml.infNFe.dest.enderDest.Estado;
            destinatario.Endereco.Municipio = NotaFiscalModeloXml.infNFe.dest.enderDest.Municipio;
            destinatario.Endereco.Logradouro = NotaFiscalModeloXml.infNFe.dest.enderDest.Logradouro;
            destinatario.Endereco.Numero = NotaFiscalModeloXml.infNFe.dest.enderDest.Numero;
            destinatario.Endereco.Pais = NotaFiscalModeloXml.infNFe.dest.enderDest.Pais;

            return destinatario;
        }

        public Emitente PegaEmitente(NotaFiscalModeloXml NotaFiscalModeloXml)
        {
            Emitente emitente = new Emitente();
            emitente.Cnpj = NotaFiscalModeloXml.infNFe.emit.CnpjEmitente;
            emitente.Nome = NotaFiscalModeloXml.infNFe.emit.Nome;
            emitente.RazaoSocial = NotaFiscalModeloXml.infNFe.emit.RazaoSocial;
            emitente.InscricaoEstadual = NotaFiscalModeloXml.infNFe.emit.InscricaoEstadual;
            emitente.InscricaoMunicipal = NotaFiscalModeloXml.infNFe.emit.InscricaoMunicipal;

            emitente.Endereco.Bairro = NotaFiscalModeloXml.infNFe.emit.enderDest.Bairro;
            emitente.Endereco.Estado = NotaFiscalModeloXml.infNFe.emit.enderDest.Estado;
            emitente.Endereco.Municipio = NotaFiscalModeloXml.infNFe.emit.enderDest.Municipio;
            emitente.Endereco.Logradouro = NotaFiscalModeloXml.infNFe.emit.enderDest.Logradouro;
            emitente.Endereco.Numero = NotaFiscalModeloXml.infNFe.emit.enderDest.Numero;
            emitente.Endereco.Pais = NotaFiscalModeloXml.infNFe.emit.enderDest.Pais;

            return emitente;
        }
    }
}
