using System;
using System.Runtime.Serialization;

namespace Septa.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    internal class MoreThanOneSimilarNumberingTemplateException : Exception
    {
        public MoreThanOneSimilarNumberingTemplateException()
        {
        }

        public MoreThanOneSimilarNumberingTemplateException(string message) : base(message)
        {
        }

        public MoreThanOneSimilarNumberingTemplateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MoreThanOneSimilarNumberingTemplateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}