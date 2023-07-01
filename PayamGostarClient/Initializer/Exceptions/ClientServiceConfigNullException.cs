using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    internal class ClientServiceConfigNullException : Exception
    {
        public ClientServiceConfigNullException() 
        {
        }

        public ClientServiceConfigNullException(string message) : base(message)
        {
        }

        public ClientServiceConfigNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientServiceConfigNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}