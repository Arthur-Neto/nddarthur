using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Xml.Features.Mapeador
{
    public class MapeadorInfNFe
    {
        public static NotaFiscal MapearDeInfNFeXmlModel(InformacaoNFeXmlModel infNFe)
        {
            NotaFiscal notaFiscal = new NotaFiscal();


            notaFiscal.Chave = infNFe.Id;
            notaFiscal.DataEmissao = Convert.ToDateTime(infNFe.Ide.dhEmi);
            notaFiscal.NaturezaOperacao = infNFe.Ide.natOp;

            return notaFiscal;
        }
        public static InformacaoNFeXmlModel MapearParaInfNFeXmlModel(NotaFiscal notaFiscal)
        {
            InformacaoNFeXmlModel infNFe = new InformacaoNFeXmlModel();


            infNFe.Id = notaFiscal.Chave;
            infNFe.Ide = new IdeXmlModel();
            infNFe.Ide.dhEmi = notaFiscal.DataEmissao.ToString();
            infNFe.Ide.natOp = notaFiscal.NaturezaOperacao;

            return infNFe;
        }
    }
}
