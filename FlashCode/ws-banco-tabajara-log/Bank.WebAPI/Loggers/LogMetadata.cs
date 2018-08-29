using Bank.WebAPI.Exceptions;

namespace Bank.WebAPI.Loggers
{
    public class LogMetadata
    {
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public int? ResponseCode { get; set; }
        public ExceptionPayload ResponseException { get; set; }
    }
}