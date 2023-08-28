using Septa.PayamGostarClient.Initializer.Core.APIs.Dtos.ExceptionDtos;
using Septa.PayamGostarClient.Initializer.Core.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace Septa.PayamGostarClient.Initializer.Core.APIs.Exceptions
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

            strBuilder.AppendLine(Help.WriteAsObject("Message:", message));

            strBuilder.AppendLine(Help.AddIndentation($"StatusCode: {statusCode}", 1));

            if (headers == null)
            {
                headers = new Dictionary<string, IEnumerable<string>>();
            }

            var headerStrBuilder = new StringBuilder();

            foreach (var header in headers)
            {
                headerStrBuilder.AppendLine($"\t{header.Key}: {string.Join(", ", header.Value)}");
            }

            strBuilder.AppendLine(Help.WriteAsObject("Header:", $"{headerStrBuilder}"));
            strBuilder.AppendLine(Help.WriteAsObject("Response:", $"{response}"));
            strBuilder.AppendLine(Help.WriteAsObject("ApiError:", $"{apiError}"));


            return new ApiServiceException(strBuilder.ToString());
        }

    }
}
