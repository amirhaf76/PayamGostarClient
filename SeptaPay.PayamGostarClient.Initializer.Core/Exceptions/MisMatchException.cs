using SeptaPay.PayamGostarClient.Initializer.Core.CrmModels;
using System;
using System.Runtime.Serialization;
using System.Text;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Exceptions
{
    [Serializable]
    public class MisMatchException : Exception
    {
        public MisMatchException()
        {
        }

        public MisMatchException(string message) : base(message)
        {
        }

        public MisMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MisMatchException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public static MisMatchException Create(ResourceValue[] first, ResourceValue[] second)
        {
            var messageBuilder = new StringBuilder();

            messageBuilder = CreateMessageForResourceValues(first, messageBuilder, "First");
            messageBuilder = CreateMessageForResourceValues(second, messageBuilder, "Second");

            return new MisMatchException(messageBuilder.ToString());
        }

        private static StringBuilder CreateMessageForResourceValues(ResourceValue[] first, StringBuilder messageBuilder, string seriName)
        {
            messageBuilder = messageBuilder.Append($"{seriName} ResourceValues:");

            foreach (var resource in first)
            {
                messageBuilder = messageBuilder.AppendLine($"\tValue: {resource.Value}, LanguageCulture: {resource.LanguageCulture}");
            }

            return messageBuilder;
        }
    }
}