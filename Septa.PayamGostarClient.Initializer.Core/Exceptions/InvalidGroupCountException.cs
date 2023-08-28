using System;
using System.Runtime.Serialization;

namespace Septa.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    public class InvalidGroupCountException : Exception
    {
        public InvalidGroupCountException()
        {
        }

        public InvalidGroupCountException(string message) : base(message)
        {
        }

        public InvalidGroupCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGroupCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}