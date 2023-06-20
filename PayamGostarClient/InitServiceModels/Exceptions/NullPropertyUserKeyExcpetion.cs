using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    public class NullPropertyUserKeyExcpetion : Exception
    {
        public NullPropertyUserKeyExcpetion()
        {
        }

        public NullPropertyUserKeyExcpetion(string message) : base(message)
        {
        }

        public NullPropertyUserKeyExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullPropertyUserKeyExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}