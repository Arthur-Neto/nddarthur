using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Destinatarios.Perfis
{
    public class PerfilMapeadorDestinatario : Profile
    {
        public PerfilMapeadorDestinatario()
        {
            CreateMap<Destinatario, DestinatarioModelo>()
                .ForMember(dm => dm.Documento, dm => dm.MapFrom(destinatario => destinatario.Documento.Numero))
                .ForMember(dm => dm.EnderecoBairro, dm => dm.MapFrom(destinatario => destinatario.Endereco.Bairro))
                .ForMember(dm => dm.EnderecoEstado, dm => dm.MapFrom(destinatario => destinatario.Endereco.Estado))
                .ForMember(dm => dm.EnderecoLogradouro, dm => dm.MapFrom(destinatario => destinatario.Endereco.Logradouro))
                .ForMember(dm => dm.EnderecoMunicipio, dm => dm.MapFrom(destinatario => destinatario.Endereco.Municipio))
                .ForMember(dm => dm.EnderecoNumero, dm => dm.MapFrom(destinatario => destinatario.Endereco.Numero))
                .ForMember(dm => dm.EnderecoPais, dm => dm.MapFrom(destinatario => destinatario.Endereco.Pais));

            CreateMap<DestinatarioAdicionarComando, Destinatario>()
                .ForMember(destinatario => destinatario.Id, comando => comando.Ignore());

            CreateMap<DestinatarioEditarComando, Destinatario>();

            CreateMap<DestinatarioRemoverComando, Destinatario>()
                .ForMember(destinatario => destinatario.NomeRazaoSocial, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.Documento, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.InscricaoEstadual, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.Endereco, comando => comando.Ignore());
        }
    }
}
