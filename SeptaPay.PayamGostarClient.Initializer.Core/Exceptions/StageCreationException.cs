using System;
using System.Runtime.Serialization;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    public class StageCreationException : Exception
    {
        public StageCreationException()
        {
        }

        public StageCreationException(string message) : base(message)
        {
        }

        public StageCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StageCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}