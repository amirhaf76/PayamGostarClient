using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.ApiServices.Exceptions
{
    [Serializable]
    internal class ExtendedPropertyTypeNotFoundException : Exception
    {
        public ExtendedPropertyTypeNotFoundException()
        {
        }

        public ExtendedPropertyTypeNotFoundException(string message) : base(message)
        {
        }

        public ExtendedPropertyTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExtendedPropertyTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}