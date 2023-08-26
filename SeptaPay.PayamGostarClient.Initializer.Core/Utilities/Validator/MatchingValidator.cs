using SeptaPay.PayamGostarClient.Initializer.Core.Abstractions.Utilities.Validator;
using SeptaPay.PayamGostarClient.Initializer.Core.Exceptions;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Utilities.Validator
{
    internal class MatchingValidator : IMatchingValidator
    {
        public void CheckFieldMatching<TField>(TField expected, TField actually, string errorMessage = "")
        {
            if (!AreTheFieldsMatched(expected, actually))
            {
                throw CreateMisMatchException(expected, actually, errorMessage);
            }
        }

        internal bool AreTheFieldsMatched<TField>(TField expected, TField actually)
        {
            if (typeof(TField) == typeof(string))
            {
                if (
                    string.IsNullOrEmpty(expected as string) && !string.IsNullOrEmpty(actually as string) ||
                    !string.IsNullOrEmpty(expected as string) && string.IsNullOrEmpty(actually as string))
                {
                    return false;
                }

                if (string.IsNullOrEmpty(expected as string) && string.IsNullOrEmpty(actually as string))
                {
                    return true;
                }
            }

            if (expected == null && actually == null)
            {
                return true;
            }

            return expected.Equals(actually);
        }

        private static MisMatchException CreateMisMatchException<TField>(TField expected, TField actually, string errorMessage)
        {
            return new MisMatchException($"{(!string.IsNullOrEmpty(errorMessage) ? errorMessage : "")}\nExpected: {expected} != Actually: {actually}");
        }
    }
}
