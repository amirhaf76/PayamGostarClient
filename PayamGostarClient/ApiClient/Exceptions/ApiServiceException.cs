using PayamGostarClient.ApiClient.Dtos.ExceptionDtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace PayamGostarClient.ApiClient.Exceptions
{
    public class ApiServiceException : Exception
    {
        public ApiServiceException()
        {
        }

        public ApiServiceException(Exception e) : base(e.Message, e.InnerException)
        {
        }

        public ApiServiceException(string message) : base(message)
        {
        }

        public ApiServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApiServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public HttpStatusCode StatusCode { get; set; }

        public string Response { get; set; }

        public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; set; }

        public ApiErrorDto ApiError { get; set; }

    }
}
