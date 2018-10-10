using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Produtos.Modelos;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Produtos.Perfis
{
    public class PerfilMapeadorTransportador : Profile
    {
        public PerfilMapeadorTransportador()
        {
            CreateMap<Transportador, TransportadorModelo>()
                .ForMember(tm => tm.Documento, dm => dm.MapFrom(destinatario => destinatario.Documento.Numero))
                .ForMember(tm => tm.EnderecoBairro, tm => tm.MapFrom(emitente => emitente.Endereco.Bairro))
                .ForMember(tm => tm.EnderecoEstado, tm => tm.MapFrom(emitente => emitente.Endereco.Estado))
                .ForMember(tm => tm.EnderecoLogradouro, tm => tm.MapFrom(emitente => emitente.Endereco.Logradouro))
                .ForMember(tm => tm.EnderecoMunicipio, tm => tm.MapFrom(emitente => emitente.Endereco.Municipio))
                .ForMember(tm => tm.EnderecoNumero, tm => tm.MapFrom(emitente => emitente.Endereco.Numero))
                .ForMember(tm => tm.EnderecoPais, tm => tm.MapFrom(emitente => emitente.Endereco.Pais));

            CreateMap<TransportadorAdicionarComando, Transportador>()
                .ForMember(transportador => transportador.Id, comando => comando.Ignore());

            CreateMap<TransportadorEditarComando, Transportador>();

            CreateMap<TransportadorRemoverComando, Transportador>()
                .ForMember(transportador => transportador.NomeRazaoSocial, comando => comando.Ignore())
                .ForMember(transportador => transportador.Documento, comando => comando.Ignore())
                .ForMember(transportador => transportador.InscricaoEstadual, comando => comando.Ignore())
                .ForMember(transportador => transportador.Endereco, comando => comando.Ignore())
                .ForMember(transportador => transportador.ResponsabilidadeFrete, comando => comando.Ignore());
        }
    }
}
