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

            strBuilder.AppendLine(Helper.Helper.WriteAsObject("Message:", message));

            strBuilder.AppendLine(Helper.Helper.AddIndentation($"StatusCode: {statusCode}", 1));

            if (headers == null)
            {
                headers = new Dictionary<string, IEnumerable<string>>();
            }

            var headerStrBuilder = new StringBuilder();

            foreach (var header in headers)
            {
                headerStrBuilder.AppendLine($"\t{header.Key}: {string.Join(", ", header.Value)}");
            }

            strBuilder.AppendLine(Helper.Helper.WriteAsObject("Header:", $"{headerStrBuilder}"));
            strBuilder.AppendLine(Helper.Helper.WriteAsObject("Response:", $"{response}"));
            strBuilder.AppendLine(Helper.Helper.WriteAsObject("ApiError:", $"{apiError}"));


            return new ApiServiceException(strBuilder.ToString());
        }

    }
}
