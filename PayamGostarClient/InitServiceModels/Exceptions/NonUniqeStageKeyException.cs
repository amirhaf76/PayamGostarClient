using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    public class NonUniqeStageKeyException : Exception
    {
        public NonUniqeStageKeyException()
        {
        }

        public NonUniqeStageKeyException(string message) : base(message)
        {
        }

        public NonUniqeStageKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonUniqeStageKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}