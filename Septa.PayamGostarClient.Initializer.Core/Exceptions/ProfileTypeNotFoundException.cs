using System;
using System.Runtime.Serialization;

namespace Septa.PayamGostarClient.Initializer.Core.Exceptions
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