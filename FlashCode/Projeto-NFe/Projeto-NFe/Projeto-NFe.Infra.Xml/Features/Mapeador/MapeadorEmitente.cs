using Projeto_NFe.Dominio.Features.Emitentes;
using Projeto_NFe.Infra.Documentos.Features.Cnpjs;
using Projeto_NFe.Infra.Xml.Features.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Xml.Features.Mapeador
{
    public static class MapeadorEmitente
    {
        public static EmitenteXmlModel MapearParaEmitenteXmlModel(Emitente emitente)
        {
            EmitenteXmlModel emitenteXmlModel = new EmitenteXmlModel();
            emitenteXmlModel.Cnpj = emitente.CNPJ.Equals("") ? emitente.CNPJ.ToString() : null;
            emitenteXmlModel.IE = emitente.InscricaoEstadual;
            emitenteXmlModel.IM= emitente.InscricaoMunicipal;
            emitenteXmlModel.XFant = emitente.NomeFantasia.Equals("") ? emitente.NomeFantasia : null;
            emitenteXmlModel.XNome = emitente.RazaoSocial.Equals("") ? emitente.RazaoSocial : null;
            emitenteXmlModel.EnderEmit = MapeadorEndereco.MapearParaEnderecoXmlModel(emitente.Endereco);

            return emitenteXmlModel;
        }

        public static Emitente MapearDeEmitenteXmlModel(EmitenteXmlModel emitenteXmlModel)
        {
            Emitente emitente = new Emitente();
            if (!string.IsNullOrEmpty(emitenteXmlModel.Cnpj))
            {
                emitente.CNPJ = new Cnpj();
                emitente.CNPJ.SetarNumeros(emitenteXmlModel.Cnpj);
            }
            emitente.InscricaoEstadual = emitenteXmlModel.IE;
            emitente.InscricaoMunicipal = emitenteXmlModel.IM;
            emitente.NomeFantasia = emitenteXmlModel.XFant;
            emitente.RazaoSocial = emitenteXmlModel.XNome;
            emitente.Endereco = MapeadorEndereco.MapearDeEnderecoXmlModel(emitenteXmlModel.EnderEmit);

            return emitente;
        }
    }
}
