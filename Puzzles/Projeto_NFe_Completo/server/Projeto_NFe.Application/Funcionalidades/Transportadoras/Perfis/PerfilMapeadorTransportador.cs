using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;

namespace Projeto_NFe.Application.Funcionalidades.Transportadoras.Perfis
{
    public class PerfilMapeadorTransportador : Profile
    {
        public PerfilMapeadorTransportador()
        {
            CreateMap<Transportador, TransportadorModelo>()
                .ForMember(tm => tm.Documento, dm => dm.MapFrom(transportador => transportador.Documento.Numero))
                .ForMember(tm => tm.TipoDeDocumento, tm => tm.MapFrom(transportador => transportador.Documento.Tipo.ToString()))
                .ForMember(tm => tm.EnderecoBairro, tm => tm.MapFrom(transportador => transportador.Endereco.Bairro))
                .ForMember(tm => tm.EnderecoEstado, tm => tm.MapFrom(transportador => transportador.Endereco.Estado))
                .ForMember(tm => tm.EnderecoLogradouro, tm => tm.MapFrom(transportador => transportador.Endereco.Logradouro))
                .ForMember(tm => tm.EnderecoMunicipio, tm => tm.MapFrom(transportador => transportador.Endereco.Municipio))
                .ForMember(tm => tm.EnderecoNumero, tm => tm.MapFrom(transportador => transportador.Endereco.Numero))
                .ForMember(tm => tm.EnderecoPais, tm => tm.MapFrom(transportador => transportador.Endereco.Pais));

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
