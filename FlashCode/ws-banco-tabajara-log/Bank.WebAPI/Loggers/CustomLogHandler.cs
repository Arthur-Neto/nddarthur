using Bank.Infra.Logger;
using Bank.WebAPI.Exceptions;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.WebAPI.Loggers
{
    public class CustomLogHandler : DelegatingHandler
    {
        public CustomLogHandler()
        {
            LoggerManager.Initialize();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogMetadata logMetadata = BuildMetadata(request);

            WriteStartLog(logMetadata);

            return await base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                HttpResponseMessage result = task.Result;
                logMetadata.ResponseCode = (int)result.StatusCode;

                if (result.Content != null && result.Content is ObjectContent<ExceptionPayload>)
                {
                    logMetadata.ResponseException = (result.Content as ObjectContent<ExceptionPayload>).Value as ExceptionPayload;
                }

                WriteEndLog(logMetadata);

                return result;
            }, cancellationToken);
        }

        private LogMetadata BuildMetadata(HttpRequestMessage request)
        {
            return new LogMetadata
            {
                RequestMethod = request.Method.Method,
                RequestUri = request.RequestUri.ToString(),
            };
        }

        private void WriteStartLog(LogMetadata metadata)
        {
            string message = string.Format("[{0}] - START: {1}", metadata.RequestMethod, metadata.RequestUri);
            LoggerManager.Info(message);
        }

        private void WriteEndLog(LogMetadata metadata)
        {
            string message;
            if (metadata.ResponseException != null)
            {
                message = string.Format("[{0}] - EXCEPTION - STATUS: {1} - MESSAGE: {2}\r\nStackTrace: {3}", metadata.RequestMethod, metadata.ResponseException.ErrorCode, metadata.ResponseException.ErrorMessage, metadata.ResponseException.Exception.StackTrace);
                LoggerManager.Error(message);
            }

            message = string.Format("[{0}] - END: {1} [Status: {2}]", metadata.RequestMethod, metadata.RequestUri, metadata.ResponseCode);
            LoggerManager.Info(message);
        }
    }
}