using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controladores.Common;
using Projeto_NFe.API.Filtros;
using Projeto_NFe.Application.Funcionalidades.Destinatarios;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Comandos;
using Projeto_NFe.Application.Funcionalidades.Destinatarios.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Destinatarios;
using System.Web.Http;

namespace Projeto_NFe.API.Controladores.Destinatarios
{
    [RoutePrefix("api/destinatario")]
    public class DestinatarioController : ApiControllerBase
    {
        private readonly IDestinatarioServico _destinatarioServico;

        public DestinatarioController(IDestinatarioServico destinatarioServico) : base()
        {
            _destinatarioServico = destinatarioServico;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult BuscarTodos(ODataQueryOptions<Destinatario> queryOptions)
        {
            return HandleQuery<Destinatario, DestinatarioModelo>(_destinatarioServico.BuscarTodos(), queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            return HandleCallback(() => _destinatarioServico.BuscarPorId(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Add(DestinatarioAdicionarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _destinatarioServico.Adicionar(comando));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Atualizar(DestinatarioEditarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _destinatarioServico.Atualizar(comando));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Excluir(DestinatarioRemoverComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _destinatarioServico.Excluir(comando));
        }

        #endregion HttpDelete
    }
}