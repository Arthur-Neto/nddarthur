using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using Projeto_NFe.Domain.Funcionalidades.ProdutoNotasFiscais;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using Projeto_NFe.Infrastructure.Data.Base;
using Projeto_NFe.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Common.Tests.Base
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
            Destinatario destinatario = ObjectMother.PegarDestinatarioValidoComCPF();
            _contexto.Destinatarios.Add(destinatario);
            _contexto.SaveChanges();
            return destinatario;
        }

        private Emitente SemearEmitente()
        {
            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();
            _contexto.Emitentes.Add(emitente);
            _contexto.SaveChanges();
            return emitente;
        }

        private Transportador SemearTransportador()
        {
            Transportador transportador = ObjectMother.PegarTransportadorValidoSemDependencias();
            _contexto.Transportadoras.Add(transportador);
            _contexto.SaveChanges();
            return transportador;
        }


        private Produto SemearProduto()
        {
            Produto produto = ObjectMother.ObterProdutoValido();
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

            NotaFiscal notaFiscal = ObjectMother.PegarNotaFiscalValida(emitente, destinatario, transportador);

            _contexto.NotasFiscais.Add(notaFiscal);
            _contexto.SaveChanges();

            ProdutoNotaFiscal produtoNotaFiscal = new ProdutoNotaFiscal(notaFiscal, produto, 10);

            notaFiscal.Produtos.Add(produtoNotaFiscal);

            _contexto.SaveChanges();

            return notaFiscal;
        }

    }
}
