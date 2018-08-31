using Arthur.MF7.WebAPI.Exceptions;

namespace Arthur.MF7.WebAPI.Logger
{
    public class LogMetadata
    {
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public int? ResponseCode { get; set; }
        public ExceptionPayload ResponseException { get; set; }
    }
}