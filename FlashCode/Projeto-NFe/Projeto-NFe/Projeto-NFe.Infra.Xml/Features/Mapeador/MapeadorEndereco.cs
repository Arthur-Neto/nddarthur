using Projeto_NFe.Dominio.Features.Enderecos;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Xml.Features.Mapeador
{
    public static class MapeadorEndereco
    {
        public static EnderecoXmlModel MapearParaEnderecoXmlModel(Endereco endereco)
        {
            EnderecoXmlModel enderecoXmlModel = new EnderecoXmlModel();

            enderecoXmlModel.nro = endereco.Numero.ToString();
            enderecoXmlModel.UF = endereco.UF;
            enderecoXmlModel.xBairro = endereco.Bairro;
            enderecoXmlModel.xLgr = endereco.Rua;
            enderecoXmlModel.xMun = endereco.Cidade;
            enderecoXmlModel.xPais = endereco.Pais;

            return enderecoXmlModel;
        }
        public static Endereco MapearDeEnderecoXmlModel(EnderecoXmlModel enderecoXmlModel)
        {
            Endereco endereco = new Endereco();

            endereco.Numero = Convert.ToInt64(enderecoXmlModel.nro);
            endereco.UF = enderecoXmlModel.UF;
            endereco.Bairro = enderecoXmlModel.xBairro;
            endereco.Rua = enderecoXmlModel.xLgr;
            endereco.Cidade = enderecoXmlModel.xMun;
            endereco.Pais = enderecoXmlModel.xPais;

            return endereco;
        }
    }
}
