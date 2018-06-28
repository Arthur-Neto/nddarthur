using Projeto_NFe.Dominio.Features.Impostos;
using Projeto_NFe.Dominio.Features.Produtos;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Xml.Features.Mapeador
{
    public static class MapeadorDet
    {
        public static List<DetXmlModel> MapearParaNFeDetModel(List<ProdutoNfe> produtos)
        {

            List<DetXmlModel> dets = new List<DetXmlModel>();

            foreach (var produto in produtos)
            {
                DetXmlModel det = new DetXmlModel();
                det.Id = produto.ID;
                det.Prod = new ProdutoXmlModel();
                det.Prod.CProd = produto.CodigoProduto;
                det.Prod.QCom = produto.Quantidade.ToString();
                det.Prod.VProd = produto.ValorTotal.ToString();
                det.Prod.VUnCom = produto.ValorUnitario.ToString();
                det.Prod.xProd = produto.Descricao;

                det.Imposto = new ImpostoXmlModel();
                det.Imposto.PICMS = produto.Imposto.AliquotaICMS.ToString();
                det.Imposto.VICMS = produto.Imposto.ValorICMS.ToString();

                dets.Add(det);
            }
            return dets;
        }
        public static List<ProdutoNfe> MapearDeNFeDetModel(List<DetXmlModel> dets)
        {

            List<ProdutoNfe> produtos = new List<ProdutoNfe>();

            foreach (var det in dets)
            {
                ProdutoNfe produto = new ProdutoNfe();
                produto.ID = det.Id;
                produto.CodigoProduto = det.Prod.CProd;
                produto.Quantidade = Convert.ToInt32(det.Prod.QCom);
                produto.ValorTotal = Convert.ToInt32(det.Prod.VProd);
                produto.ValorUnitario = Convert.ToDouble(det.Prod.VUnCom);
                produto.Descricao = det.Prod.xProd;



                produto.Imposto = new Imposto(produto);
                produto.Imposto.ValorICMS = Convert.ToDouble(det.Imposto.VICMS);
                det.Imposto = new ImpostoXmlModel();

                produtos.Add(produto);
            }
            return produtos;
        }
    }
}
