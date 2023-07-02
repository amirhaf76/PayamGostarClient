using PayamGostarClient.ApiClient.Dtos.ExceptionDtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace PayamGostarClient.ApiClient.Exceptions
{
    [Serializable]
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


        public static ApiServiceException Create(string message = "", string response = "", HttpStatusCode? statusCode = null, IReadOnlyDictionary<string, IEnumerable<string>> headers = null, ApiErrorDto apiError = null)
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine($"Message:\n{{\n\t{message}\n}}");

            strBuilder.AppendLine($"StatusCode: {statusCode}");

            if (headers == null)
            {
                headers = new Dictionary<string, IEnumerable<string>>();
            }
            strBuilder.AppendLine($"Headers:\n{{");

            foreach (var header in headers)
            {
                strBuilder.AppendLine($"\t{header.Key}: {header.Value}");
            }

            strBuilder.AppendLine("}");

            strBuilder.AppendLine($"Response:\n{{\n\t{response}\n}}");

            strBuilder.AppendLine($"ApiError:\n{{\n\t{apiError}\n}}");

            return new ApiServiceException(strBuilder.ToString());
        }

    }
}
