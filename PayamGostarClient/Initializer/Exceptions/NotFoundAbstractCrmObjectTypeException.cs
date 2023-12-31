﻿using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    internal class NotFoundAbstractCrmObjectTypeException : Exception
    {
        public NotFoundAbstractCrmObjectTypeException()
        {
        }

        public NotFoundAbstractCrmObjectTypeException(string message) : base(message)
        {
        }

        public NotFoundAbstractCrmObjectTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundAbstractCrmObjectTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}