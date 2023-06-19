using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Models.Services
{
    [Serializable]
    internal class InvalidPriorityMatrixCount : Exception
    {
        public InvalidPriorityMatrixCount()
        {
        }

        public InvalidPriorityMatrixCount(string message) : base(message)
        {
        }

        public InvalidPriorityMatrixCount(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPriorityMatrixCount(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}