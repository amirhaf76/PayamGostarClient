﻿using System;
using System.Runtime.Serialization;

namespace Septa.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    public class NotFoundAtleastAFinalStageException : Exception
    {
        public NotFoundAtleastAFinalStageException()
        {
        }

        public NotFoundAtleastAFinalStageException(string message) : base(message)
        {
        }

        public NotFoundAtleastAFinalStageException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundAtleastAFinalStageException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}