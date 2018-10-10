using Microsoft.AspNet.OData.Query;
using Projeto_NFe.API.Controladores.Common;
using Projeto_NFe.API.Filtros;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Comandos;
using Projeto_NFe.Application.Funcionalidades.Notas_Fiscais.Modelos;
using Projeto_NFe.Domain.Funcionalidades.Nota_Fiscal;
using System.Web.Http;

namespace Projeto_NFe.API.Controladores.NotaFiscals
{
    [RoutePrefix("api/notaFiscal")]
    public class NotaFiscalControlador : ApiControllerBase
    {
        private readonly INotaFiscalServico _notaFiscalServico;

        public NotaFiscalControlador(INotaFiscalServico notaFiscalServico) : base()
        {
            _notaFiscalServico = notaFiscalServico;
        }

        #region HttpGet
        [HttpGet]
        [ODataQueryOptionsValidate]
        public IHttpActionResult BuscarTodos(ODataQueryOptions<NotaFiscal> queryOptions)
        {
            var query = _notaFiscalServico.BuscarTodos();
            return HandleQuery<NotaFiscal, NotaFiscalModelo>(query, queryOptions);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult BuscarPorId(int id)
        {
            return HandleCallback(() => _notaFiscalServico.BuscarPorId(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Add(NotaFiscalAdicionarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();
            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _notaFiscalServico.Adicionar(comando));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Atualizar(NotaFiscalEditarComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _notaFiscalServico.Atualizar(comando));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Excluir(NotaFiscalRemoverComando comando)
        {
            var validador = comando.RealizarValidacaoDoComando();

            if (!validador.IsValid)
                return HandleValidationFailure(validador.Errors);

            return HandleCallback(() => _notaFiscalServico.Excluir(comando));
        }

        #endregion HttpDelete
    }
}