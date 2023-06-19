﻿using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.InitServiceModels.Exceptions
{
    [Serializable]
    internal class NotFoundExtendedPropertyTypeException : Exception
    {
        public NotFoundExtendedPropertyTypeException()
        {
        }

        public NotFoundExtendedPropertyTypeException(string message) : base(message)
        {
        }

        public NotFoundExtendedPropertyTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundExtendedPropertyTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}