using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Models
{
    [Serializable]
    public class MisMatchException : Exception
    {
        public MisMatchException()
        {
        }

        public MisMatchException(string message) : base(message)
        {
        }

        public MisMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MisMatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static MisMatchException Create<T>(T first, T second)
        {
            return new MisMatchException($"{first} != {second}");
        }
    }
}