using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    internal class InvalidSupserCrmModelGroupException : Exception
    {
        public InvalidSupserCrmModelGroupException()
        {
        }

        public InvalidSupserCrmModelGroupException(string message) : base(message)
        {
        }

        public InvalidSupserCrmModelGroupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSupserCrmModelGroupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}