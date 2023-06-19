using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    internal class NullNameException : Exception
    {
        public NullNameException()
        {
        }

        public NullNameException(string message) : base(message)
        {
        }

        public NullNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}