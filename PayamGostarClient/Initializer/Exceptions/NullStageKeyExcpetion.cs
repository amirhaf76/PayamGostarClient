﻿using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
{
    [Serializable]
    public class NullStageKeyExcpetion : Exception
    {
        public NullStageKeyExcpetion()
        {
        }

        public NullStageKeyExcpetion(string message) : base(message)
        {
        }

        public NullStageKeyExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullStageKeyExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}