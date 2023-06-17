using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.CrmObjectModelInitServiceModels.Exceptions
{
    [Serializable]
    internal class NotSupportedByApiException : Exception
    {
        public NotSupportedByApiException()
        {
        }

        public NotSupportedByApiException(string message) : base(message)
        {
        }

        public NotSupportedByApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSupportedByApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}