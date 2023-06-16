using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    internal class CrmCodeIsNullException : Exception
    {
        public CrmCodeIsNullException()
        {
        }

        public CrmCodeIsNullException(string message) : base(message)
        {
        }

        public CrmCodeIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CrmCodeIsNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}