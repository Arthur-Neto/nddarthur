using Projeto_NFe.Dominio.Features.Destinatarios;
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
    public static class MapeadorDestinatario
    {
        public static DestinatarioXmlModel MapearParaDestinatarioXmlModel(Destinatario destinatario)
        {
            DestinatarioXmlModel destinatarioModel = new DestinatarioXmlModel();

            destinatarioModel.Cnpj = destinatario.Cnpj != null ? destinatario.Cnpj.ToString() : null;
            destinatarioModel.Cpf = destinatario.Cpf != null ? destinatario.Cpf.ToString() : null;
            destinatarioModel.IE = destinatario.InscricaoEstadual;
            destinatarioModel.XFant = destinatario.Nome != "" ? destinatario.Nome : null;
            destinatarioModel.XNome = destinatario.RazaoSocial != "" ? destinatario.RazaoSocial : null;
            destinatarioModel.EnderDest = MapeadorEndereco.MapearParaEnderecoXmlModel(destinatario.Endereco);

            return destinatarioModel;
        }

        public static Destinatario MapearDeDestinatarioXmlModel(DestinatarioXmlModel destinatarioXmlModel)
        {
            Destinatario destinatario = new Destinatario();

            if (!string.IsNullOrEmpty(destinatarioXmlModel.Cnpj))
            {
                destinatario.Cnpj = new Cnpj();
                destinatario.Cnpj.SetarNumeros(destinatarioXmlModel.Cnpj);
                destinatario.RazaoSocial = destinatarioXmlModel.XNome;
            }
            if (!string.IsNullOrEmpty(destinatarioXmlModel.Cpf))
            {
                destinatario.Cpf = new Cpf();
                destinatario.Cnpj.SetarNumeros(destinatarioXmlModel.Cpf);
            }
            destinatario.InscricaoEstadual = destinatario.InscricaoEstadual;
            destinatario.Nome = destinatarioXmlModel.XFant;
            destinatario.Endereco = MapeadorEndereco.MapearDeEnderecoXmlModel(destinatarioXmlModel.EnderDest);

            return destinatario;
        }
    }
}
