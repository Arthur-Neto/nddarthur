using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Emitentes.Perfis
{
    public class PerfilMapeadorEmitente : Profile
    {
        public PerfilMapeadorEmitente()
        {
            CreateMap<Emitente, EmitenteModelo>()
                .ForMember(em => em.CNPJ, em => em.MapFrom(emitente => emitente.CNPJ.Numero))
                .ForMember(em => em.EnderecoBairro, em => em.MapFrom(emitente => emitente.Endereco.Bairro))
                .ForMember(em => em.EnderecoEstado, em => em.MapFrom(emitente => emitente.Endereco.Estado))
                .ForMember(em => em.EnderecoLogradouro, em => em.MapFrom(emitente => emitente.Endereco.Logradouro))
                .ForMember(em => em.EnderecoMunicipio, em => em.MapFrom(emitente => emitente.Endereco.Municipio))
                .ForMember(em => em.EnderecoNumero, em => em.MapFrom(emitente => emitente.Endereco.Numero))
                .ForMember(em => em.EnderecoPais, em => em.MapFrom(emitente => emitente.Endereco.Pais));

            CreateMap<EmitenteAdicionarComando, Emitente>()
                .ForMember(emitente => emitente.Id, comando => comando.Ignore());

            CreateMap<EmitenteEditarComando, Emitente>();

            CreateMap<EmitenteRemoverComando, Emitente>()
                .ForMember(emitente => emitente.NomeFantasia, comando => comando.Ignore())
                .ForMember(emitente => emitente.RazaoSocial, comando => comando.Ignore())
                .ForMember(emitente => emitente.CNPJ, comando => comando.Ignore())
                .ForMember(emitente => emitente.InscricaoEstadual, comando => comando.Ignore())
                .ForMember(emitente => emitente.InscricaoMunicipal, comando => comando.Ignore())
                .ForMember(emitente => emitente.Endereco, comando => comando.Ignore());
        }
    }
}
