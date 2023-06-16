using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Models
{
    [Serializable]
    internal class NonUniqeUserKeyException : Exception
    {
        public NonUniqeUserKeyException()
        {
        }

        public NonUniqeUserKeyException(string message) : base(message)
        {
        }

        public NonUniqeUserKeyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonUniqeUserKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}