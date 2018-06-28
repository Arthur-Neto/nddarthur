using Projeto_NFe.Dominio.Features.Transportadores;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Documentos.Features.Cpfs;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Xml.Features.Mapeador
{
    public static class MapeadorTransportador
    {
        public static TransportadorXmlModel MapearParaTransportadorXmlModel(Transportador transportador)
        {
            TransportadorXmlModel transportadorModel = new TransportadorXmlModel();

            transportadorModel.Cnpj = transportador.Cnpj != null ? transportador.Cnpj.ToString() : null;
            transportadorModel.Cpf = transportador.Cpf != null ? transportador.Cpf.ToString() : null;
            transportadorModel.IE = transportador.InscricaoEstadual;
            transportadorModel.RazaoSocial = transportador.RazaoSocial != "" ? transportador.RazaoSocial : null;
            transportadorModel.Nome = transportador.Nome != "" ? transportador.Nome : null;
            transportadorModel.EnderTrans = MapeadorEndereco.MapearParaEnderecoXmlModel(transportador.Endereco);

            return transportadorModel;
        }

        public static Transportador MapearDeTransportadorXmlModel(TransportadorXmlModel transportadorModel)
        {
            Transportador transportador = new Transportador();
            if (!string.IsNullOrEmpty(transportadorModel.Cnpj))
            {
                transportador.Cnpj = new Cnpj();
                transportador.Cnpj.SetarNumeros(transportadorModel.Cnpj);
                transportador.RazaoSocial = transportadorModel.RazaoSocial;
            }
            if (!string.IsNullOrEmpty(transportadorModel.Cpf))
            {
                transportador.Cpf = new Cpf();
                transportador.Cpf.SetarNumeros(transportadorModel.Cpf);
            }
            transportador.Nome = transportadorModel.Nome;
            transportador.InscricaoEstadual = transportadorModel.IE;
            transportador.Endereco = MapeadorEndereco.MapearDeEnderecoXmlModel(transportadorModel.EnderTrans);

            return transportador;
        }
    }
}
