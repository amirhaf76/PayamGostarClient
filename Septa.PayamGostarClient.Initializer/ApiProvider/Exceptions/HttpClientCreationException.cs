using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.ApiClient.ApiProvider.Exceptions
{
    [Serializable]
    public class HttpClientCreationException : Exception
    {
        public HttpClientCreationException()
        {
        }

        public HttpClientCreationException(string message) : base(message)
        {
        }

        public HttpClientCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpClientCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}