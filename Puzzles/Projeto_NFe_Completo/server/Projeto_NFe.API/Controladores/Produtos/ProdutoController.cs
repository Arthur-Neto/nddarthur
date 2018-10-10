using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controladores.Common;
using Projeto_NFe.API.Filtros;
using Projeto_NFe.Application.Funcionalidades.Produtos;
using Projeto_NFe.Application.Funcionalidades.Produtos.Comandos;
using Projeto_NFe.Application.Funcionalidades.Produtos.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Produtos;
using System.Web.Http;

namespace Projeto_NFe.API.Controladores.Produtos
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiControllerBase
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico) : base()
        {
            _produtoServico = produtoServico;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult BuscarTodos(ODataQueryOptions<Produto> queryOptions)
        {
            var query = _produtoServico.BuscarTodos();
            return HandleQuery<Produto, ProdutoModelo>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            return HandleCallback(() => _produtoServico.BuscarPorId(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Add(ProdutoAdicionarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _produtoServico.Adicionar(comando));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Atualizar(ProdutoEditarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _produtoServico.Atualizar(comando));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Excluir(ProdutoRemoverComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _produtoServico.Excluir(comando));
        }

        #endregion HttpDelete
    }
}