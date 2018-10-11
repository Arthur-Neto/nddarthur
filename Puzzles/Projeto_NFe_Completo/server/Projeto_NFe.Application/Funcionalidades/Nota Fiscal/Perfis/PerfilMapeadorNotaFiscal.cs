using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Perfis
{
    public class PerfilMapeadorNotaFiscal : Profile
    {
        public PerfilMapeadorNotaFiscal()
        {
            CreateMap<NotaFiscal, NotaFiscalModelo>()
                .ForMember(nfm => nfm.ChaveAcesso, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ChaveAcesso))
                .ForMember(nfm => nfm.Destinatario, nfm => nfm.MapFrom(notaFiscal => notaFiscal.Destinatario.NomeRazaoSocial))
                .ForMember(nfm => nfm.Emitente, nfm => nfm.MapFrom(notaFiscal => notaFiscal.Emitente.RazaoSocial))
                .ForMember(nfm => nfm.NaturezaOperacao, nfm => nfm.MapFrom(notaFiscal => notaFiscal.NaturezaOperacao))
                .ForMember(nfm => nfm.Transportador, nfm => nfm.MapFrom(notaFiscal => notaFiscal.Transportador.NomeRazaoSocial))
                .ForMember(nfm => nfm.ValorTotalFrete, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ValorTotalFrete))
                .ForMember(nfm => nfm.ValorTotalICMS, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ValorTotalICMS))
                .ForMember(nfm => nfm.ValorTotalImpostos, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ValorTotalImpostos))
                .ForMember(nfm => nfm.ValorTotalIPI, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ValorTotalIPI))
                .ForMember(nfm => nfm.ValorTotalNota, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ValorTotalNota))
                .ForMember(nfm => nfm.ValorTotalProdutos, nfm => nfm.MapFrom(notaFiscal => notaFiscal.ValorTotalProdutos))
                .ForMember(nfm => nfm.DataEmissao, nfm => nfm.MapFrom(notaFiscal => notaFiscal.DataEmissao.ToString()))
                .ForMember(nfm => nfm.DataEntrada, nfm => nfm.MapFrom(notaFiscal => notaFiscal.DataEntrada.ToShortDateString()));

            CreateMap<NotaFiscalAdicionarComando, NotaFiscal>()
                .ForMember(notaFiscal => notaFiscal.Id, comando => comando.Ignore());

            CreateMap<NotaFiscalEditarComando, NotaFiscal>();

            CreateMap<NotaFiscalRemoverComando, NotaFiscal>()
                .ForMember(notaFiscal => notaFiscal.Transportador, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.Destinatario, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.Emitente, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.NaturezaOperacao, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.DataEntrada, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.DataEmissao, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.Produtos, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ChaveAcesso, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ValorTotalFrete, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ValorTotalICMS, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ValorTotalImpostos, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ValorTotalIPI, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ValorTotalNota, comando => comando.Ignore())
                .ForMember(notaFiscal => notaFiscal.ValorTotalProdutos, comando => comando.Ignore());
        }
    }
}
