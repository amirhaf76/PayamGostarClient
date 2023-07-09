using System;
using System.Runtime.Serialization;

namespace PayamGostarClient.Initializer.Exceptions
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