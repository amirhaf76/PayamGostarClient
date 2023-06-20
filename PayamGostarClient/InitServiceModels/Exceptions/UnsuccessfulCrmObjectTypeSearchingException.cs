using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    public class UnsuccessfulCrmObjectTypeSearchingException : Exception
    {
        public UnsuccessfulCrmObjectTypeSearchingException()
        {
        }

        public UnsuccessfulCrmObjectTypeSearchingException(string message) : base(message)
        {
        }

        public UnsuccessfulCrmObjectTypeSearchingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsuccessfulCrmObjectTypeSearchingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}