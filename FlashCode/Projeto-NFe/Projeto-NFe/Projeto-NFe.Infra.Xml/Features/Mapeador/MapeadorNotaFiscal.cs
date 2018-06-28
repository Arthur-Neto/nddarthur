using Projeto_NFe.Dominio.Features.NotasFiscais;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Xml.Features.Mapeador
{
    public static class MapeadorNotaFiscal
    {
        public static NotaFiscalXmlModel MapearParaNFeModel(NotaFiscal notaFiscal)
        {
            NotaFiscalXmlModel NFe = new NotaFiscalXmlModel();

            NFe.InfNFe = MapeadorInfNFe.MapearParaInfNFeXmlModel(notaFiscal);

            NFe.InfNFe.Emit = MapeadorEmitente.MapearParaEmitenteXmlModel(notaFiscal.Emitente);

            NFe.InfNFe.Dest = MapeadorDestinatario.MapearParaDestinatarioXmlModel(notaFiscal.Destinatario);

            NFe.InfNFe.Trans = MapeadorTransportador.MapearParaTransportadorXmlModel(notaFiscal.Transportador);

            NFe.InfNFe.Dets = MapeadorDet.MapearParaNFeDetModel(notaFiscal.Produtos);


            return NFe;
        }
        public static NotaFiscal MapearDeNFeModel(NotaFiscalXmlModel NFe)
        {
            NotaFiscal notaFiscal = new NotaFiscal();

            notaFiscal = MapeadorInfNFe.MapearDeInfNFeXmlModel(NFe.InfNFe);

            notaFiscal.Emitente = MapeadorEmitente.MapearDeEmitenteXmlModel(NFe.InfNFe.Emit);

            notaFiscal.Destinatario = MapeadorDestinatario.MapearDeDestinatarioXmlModel(NFe.InfNFe.Dest);

            notaFiscal.Transportador = MapeadorTransportador.MapearDeTransportadorXmlModel(NFe.InfNFe.Trans);

            notaFiscal.Produtos = MapeadorDet.MapearDeNFeDetModel(NFe.InfNFe.Dets);


            return notaFiscal;
        }
    }
}
