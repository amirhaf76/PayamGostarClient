using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    internal class ProfileTypeNotFoundException : Exception
    {
        public ProfileTypeNotFoundException()
        {
        }

        public ProfileTypeNotFoundException(string message) : base(message)
        {
        }

        public ProfileTypeNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProfileTypeNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}