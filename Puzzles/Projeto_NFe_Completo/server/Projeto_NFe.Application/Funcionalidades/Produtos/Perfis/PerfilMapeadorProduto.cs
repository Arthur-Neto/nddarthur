using Projeto_NFe.Application.Funcionalidades.Produtos.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Projeto_NFe.Application.Funcionalidades.Produtos.Comandos;

namespace Projeto_NFe.Application.Funcionalidades.Produtos.Perfis
{
    public class PerfilMapeadorProduto : Profile
    {
        public PerfilMapeadorProduto()
        {
            CreateMap<Produto, ProdutoModelo>();

            CreateMap<ProdutoAdicionarComando, Produto>()
                .ForMember(destinatario => destinatario.Id, comando => comando.Ignore());

            CreateMap<ProdutoEditarComando, Produto>();

            CreateMap<ProdutoRemoverComando, Produto>()
                .ForMember(destinatario => destinatario.Codigo, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.Valor, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.AliquotaICMS, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.AliquotaIPI, comando => comando.Ignore())
                .ForMember(destinatario => destinatario.Descricao, comando => comando.Ignore());
        }
    }
}
