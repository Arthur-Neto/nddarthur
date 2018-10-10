using Projeto_NFe.Common.Tests.Funcionalidades;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
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
    public class BaseSqlTeste : DropCreateDatabaseAlways<ProjetoNFeContexto>
    {

        protected override void Seed(ProjetoNFeContexto projetoNFeContexto)
        {
            Destinatario destinatario = ObjectMother.PegarDestinatarioValidoComCPF();
            Emitente emitente = ObjectMother.PegarEmitenteValidoSemDependencias();
            Transportador transportador = ObjectMother.PegarTransportadorValidoSemDependencias();
            Produto produto = ObjectMother.ObterProdutoValido();
            NotaFiscal notaFiscal = projetoNFeContexto.NotasFiscais.Add(ObjectMother.PegarNotaFiscalValida(emitente, destinatario, transportador));

            projetoNFeContexto.Destinatarios.Add(destinatario);
            projetoNFeContexto.Emitentes.Add(emitente);
            projetoNFeContexto.Transportadoras.Add(transportador);
            projetoNFeContexto.Produtos.Add(produto);

            projetoNFeContexto.SaveChanges();
            base.Seed(projetoNFeContexto);
        }
        
    }
}
