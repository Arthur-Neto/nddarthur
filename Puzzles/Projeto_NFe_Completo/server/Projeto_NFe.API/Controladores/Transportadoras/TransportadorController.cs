using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controladores.Common;
using Projeto_NFe.API.Filtros;
using Projeto_NFe.Application.Funcionalidades.Produtos.Modelos;
using Projeto_NFe.Application.Funcionalidades.Transportadoras;
using Projeto_NFe.Application.Funcionalidades.Transportadoras.Comandos;
using Projeto_NFe.Domain.Funcionalidades.Transportadoras;
using System.Web.Http;

namespace Projeto_NFe.API.Controladores.Transportadors
{
    [RoutePrefix("api/transportador")]
    public class TransportadorController: ApiControllerBase
    {
        private readonly ITransportadorServico _transportadorServico;

        public TransportadorController(ITransportadorServico transportadorServico) : base()
        {
            _transportadorServico = transportadorServico;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult BuscarTodos(ODataQueryOptions<Transportador> queryOptions)
        {
            var query = _transportadorServico.BuscarTodos();
            return HandleQuery<Transportador, TransportadorModelo>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            return HandleCallback(() => _transportadorServico.BuscarPorId(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Add(TransportadorAdicionarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _transportadorServico.Adicionar(comando));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Atualizar(TransportadorEditarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _transportadorServico.Atualizar(comando));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Excluir(TransportadorRemoverComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _transportadorServico.Excluir(comando));
        }

        #endregion HttpDelete
    }
}