using System;
using System.Runtime.Serialization;

namespace Septa.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    internal class CultureNamesException : Exception
    {
        public CultureNamesException()
        {
        }

        public CultureNamesException(string message) : base(message)
        {
        }

        public CultureNamesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CultureNamesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}