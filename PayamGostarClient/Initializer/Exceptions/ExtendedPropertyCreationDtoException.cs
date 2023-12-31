﻿using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    public class ExtendedPropertyCreationDtoException : Exception
    {
        public ExtendedPropertyCreationDtoException()
        {
        }

        public ExtendedPropertyCreationDtoException(string message) : base(message)
        {
        }

        public ExtendedPropertyCreationDtoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExtendedPropertyCreationDtoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}