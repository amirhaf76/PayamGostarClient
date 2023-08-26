using System;
using System.Runtime.Serialization;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    internal class InvalidSuperCrmModelGroupException : Exception
    {
        public InvalidSuperCrmModelGroupException()
        {
        }

        public InvalidSuperCrmModelGroupException(string message) : base(message)
        {
        }

        public InvalidSuperCrmModelGroupException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSuperCrmModelGroupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}