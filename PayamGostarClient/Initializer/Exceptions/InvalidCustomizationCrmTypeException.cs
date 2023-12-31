﻿using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    public class InvalidCustomizationCrmTypeException : Exception
    {
        public InvalidCustomizationCrmTypeException()
        {
        }

        public InvalidCustomizationCrmTypeException(string message) : base(message)
        {
        }

        public InvalidCustomizationCrmTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCustomizationCrmTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}