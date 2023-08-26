using System;
using System.Runtime.Serialization;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    public class ExtendedPropertyCreationDtoException : Exception
    {
        public ExtendedPropertyCreationDtoException()
        {
        }

        public ExtendedPropertyCreationDtoException(string message) : base(message)
        {
        }

        public ExtendedPropertyCreationDtoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExtendedPropertyCreationDtoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}