using System;
using System.Runtime.Serialization;

namespace Septa.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    public class UnBindedExtendedPropertyToGroupPropertyException : Exception
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