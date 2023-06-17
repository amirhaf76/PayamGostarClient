using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    internal class NullCrmCodeException : Exception
    {
        public NullCrmCodeException()
        {
        }

        public NullCrmCodeException(string message) : base(message)
        {
        }

        public NullCrmCodeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullCrmCodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}