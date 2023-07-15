using PayamGostarClient.Initializer.Abstractions.Utilities.Validator;
using PayamGostarClient.Initializer.Exceptions;

namespace PayamGostarClient.Initializer.Utilities.Validator
{
    internal class MatchingValidator : IMatchingValidator
    {
        public void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            if (!AreTheFieldsMatched(first, second))
            {
                throw CreateMisMatchException(first, second, errorMessage);
            }
        }

        internal bool AreTheFieldsMatched<TField>(TField first, TField second)
        {
            if (typeof(TField) == typeof(string))
            {
                if (
                    string.IsNullOrEmpty(first as string) && !string.IsNullOrEmpty(second as string) ||
                    !string.IsNullOrEmpty(first as string) && string.IsNullOrEmpty(second as string))
                {
                    return false;
                }

                if (string.IsNullOrEmpty(first as string) && string.IsNullOrEmpty(second as string))
                {
                    return true;
                }
            }

            if (first == null && second == null)
            {
                return true;
            }

            return first.Equals(second);
        }

        private static MisMatchException CreateMisMatchException<TField>(TField first, TField second, string errorMessage)
        {
            return new MisMatchException($"{(!string.IsNullOrEmpty(errorMessage) ? errorMessage : "")}\nExpected: {first} != Actually: {second}");
        }
    }
}
