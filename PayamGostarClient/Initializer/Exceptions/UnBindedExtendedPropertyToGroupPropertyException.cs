using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    internal class UnBindedExtendedPropertyToGroupPropertyException : Exception
    {
        public UnBindedExtendedPropertyToGroupPropertyException()
        {
        }

        public UnBindedExtendedPropertyToGroupPropertyException(string message) : base(message)
        {
        }

        public UnBindedExtendedPropertyToGroupPropertyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnBindedExtendedPropertyToGroupPropertyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}