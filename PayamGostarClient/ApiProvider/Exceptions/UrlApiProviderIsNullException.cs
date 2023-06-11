using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.ApiProvider.Exceptions
{
    [Serializable]
    internal class UrlApiProviderIsNullException : Exception
    {
        public UrlApiProviderIsNullException()
        {
        }

        public UrlApiProviderIsNullException(string message) : base(message)
        {
        }

        public UrlApiProviderIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UrlApiProviderIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}