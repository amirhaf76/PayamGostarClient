﻿using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    public class InvalidGpCrmObjectTypeException : Exception
    {
        public InvalidGpCrmObjectTypeException()
        {
        }

        public InvalidGpCrmObjectTypeException(string message) : base(message)
        {
        }

        public InvalidGpCrmObjectTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGpCrmObjectTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}