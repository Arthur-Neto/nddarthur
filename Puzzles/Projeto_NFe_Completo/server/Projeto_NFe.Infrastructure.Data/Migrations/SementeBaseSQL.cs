using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Documentos;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Enderecos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infrastructure.Data.Migrations
{
    public class SementeBaseSQL
    {
        ProjetoNFeContexto _contexto;

        public SementeBaseSQL(ProjetoNFeContexto contexto)
        {
            _contexto = contexto;
        }

        public void Semear()
        {
            SemearDestinatario();
            SemearEmitente();
            SemearTransportador();
            SemearProduto();
            SemearNotaFiscal();
        }

        private Destinatario SemearDestinatario()
        {
            Destinatario destinatario = new Destinatario()
            {
                NomeRazaoSocial = "Nome",
                Documento = new Documento("603.486.029-60", TipoDocumento.CPF),
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                }
            };
            _contexto.Destinatarios.Add(destinatario);
            _contexto.SaveChanges();
            return destinatario;
        }

        private Emitente SemearEmitente()
        {
            Emitente emitente = new Emitente
            {
                Id = 10,
                NomeFantasia = "nome fantasia",
                RazaoSocial = "razão social",
                CNPJ = new Documento("99.327.235/0001-50", TipoDocumento.CNPJ),
                InscricaoEstadual = "478648383",
                InscricaoMunicipal = "478548383",
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                }
            };
            _contexto.Emitentes.Add(emitente);
            _contexto.SaveChanges();
            return emitente;
        }

        private Transportador SemearTransportador()
        {
            Transportador transportador = new Transportador()
            {
                NomeRazaoSocial = "Razão Social",
                InscricaoEstadual = "636.330.646.110",
                ResponsabilidadeFrete = true,
                Documento = new Documento("99.327.235/0001-50", TipoDocumento.CNPJ),
                Endereco = new Endereco()
                {
                    Logradouro = "Logradouro",
                    Numero = 1,
                    Bairro = "Bairro",
                    Municipio = "Município",
                    Estado = "Estado",
                    Pais = "País"
                }
            };
            _contexto.Transportadoras.Add(transportador);
            _contexto.SaveChanges();
            return transportador;
        }


        private Produto SemearProduto()
        {
            Produto produto = new Produto()
            {
                Codigo = "123",
                Descricao = "Produto",
                Valor = 1
            };
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
            return produto;
        }

        private NotaFiscal SemearNotaFiscal()
        {
            Destinatario destinatario = SemearDestinatario();
            Emitente emitente = SemearEmitente();
            Transportador transportador = SemearTransportador();
            Produto produto = SemearProduto();

            NotaFiscal notaFiscal = new NotaFiscal
            {
                ValorTotalICMS = 90,
                ValorTotalIPI = 10,
                ValorTotalFrete = 50,
                ValorTotalNota = 1000,
                ValorTotalProdutos = 800,
                ValorTotalImpostos = 100,
                NaturezaOperacao = "Natureza",
                DataEntrada = DateTime.Now,
                Destinatario = destinatario,
                Emitente = emitente,
                Transportador = transportador
            };

            _contexto.NotasFiscais.Add(notaFiscal);
            _contexto.SaveChanges();

            ProdutoNotaFiscal produtoNotaFiscal = new ProdutoNotaFiscal(notaFiscal, produto, 10);

            notaFiscal.Produtos.Add(produtoNotaFiscal);

            _contexto.SaveChanges();

            return notaFiscal;
        }

    }
}
