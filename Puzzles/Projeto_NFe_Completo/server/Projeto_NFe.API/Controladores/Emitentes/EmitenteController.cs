using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controladores.Common;
using Projeto_NFe.API.Filtros;
using Projeto_NFe.Application.Funcionalidades.Emitentes;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Comandos;
using Projeto_NFe.Application.Funcionalidades.Emitentes.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Emitentes;
using System.Web.Http;

namespace Projeto_NFe.API.Controladores.Emitentes
{
    [RoutePrefix("api/emitente")]
    public class EmitenteController : ApiControllerBase
    {
        private readonly IEmitenteServico _emitenteServico;

        public EmitenteController(IEmitenteServico emitenteServico) : base()
        {
            _emitenteServico = emitenteServico;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult BuscarTodos(ODataQueryOptions<Emitente> queryOptions)
        {
            return HandleQuery<Emitente, EmitenteModelo>(_emitenteServico.BuscarTodos(), queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            return HandleCallback(() => _emitenteServico.BuscarPorId(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Add(EmitenteAdicionarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _emitenteServico.Adicionar(comando));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Atualizar(EmitenteEditarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _emitenteServico.Atualizar(comando));
        }
        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Excluir(EmitenteRemoverComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _emitenteServico.Excluir(comando));
        }
        #endregion HttpDelete
    }
}