using Arthur.MF7.Domain.Exceptions;
using Arthur.MF7.Infra.CSV;
using Arthur.MF7.WebAPI.Exceptions;
using Arthur.MF7.WebAPI.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Arthur.MF7.WebAPI.Controllers.Common
{
    public class ApiControllerBase : ApiController
    {
        protected IHttpActionResult HandleCallback<TSuccess>(Func<TSuccess> func)
        {
            try
            {
                return Ok(func());
            }
            catch (Exception e)
            {
                return HandleFailure(e);
            }
        }

        protected IHttpActionResult HandleQuery<TResult>(IQueryable<TResult> query)
        {
            if (Request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv)))
                return ResponseMessage(HandleCSVFile(query));

            return Ok(query.ToList());
        }


        protected IHttpActionResult HandleQueryable<TSource>(IQueryable<TSource> query)
        {
            if (Request.Headers.Accept.Contains(MediaTypeWithQualityHeaderValue.Parse(MediaTypes.Csv)))
                return ResponseMessage(HandleCSVFile(query));

            return Ok(query.ToList());
        }

        protected IHttpActionResult HandleFailure<T>(T exceptionToHandle) where T : Exception
        {
            ExceptionPayload exceptionPayload = ExceptionPayload.New(exceptionToHandle);
            return exceptionToHandle is BusinessException ?
                Content(HttpStatusCode.BadRequest, exceptionPayload) :
                Content(HttpStatusCode.InternalServerError, exceptionPayload);
        }

        protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure) where T : ValidationFailure
        {
            return Content(HttpStatusCode.BadRequest, validationFailure);
        }

        private HttpResponseMessage HandleCSVFile<TResult>(IQueryable<TResult> query)
        {
            string csv = query.ToCsv<TResult>(";");
            byte[] bytes = Encoding.UTF8.GetBytes(csv);
            MemoryStream stream = new MemoryStream(bytes, 0, bytes.Length, false, true);

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(stream.GetBuffer()) };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = string.Format("export{0}.csv", DateTime.UtcNow.ToString("yyyyMMddhhmmss"))
            };

            return result;
        }
    }
}