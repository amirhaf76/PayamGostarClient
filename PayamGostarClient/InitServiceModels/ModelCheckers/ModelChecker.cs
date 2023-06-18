using PayamGostarClient.CrmObjectModelInitServiceModels.CrmObjectModels;
using PayamGostarClient.InitServiceModels.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayamGostarClient.InitServiceModels.ModelCheckers
{
    internal static class ModelChecker
    {
        internal static bool CheckResourceValues(this IEnumerable<ResourceValue> first, IEnumerable<ResourceValue> second)
        {
            return first
                .Join(
                    second,
                    outter => outter.LanguageCulture,
                    inner => inner.LanguageCulture,
                    (inner, outter) => new ValueTuple<string, string>(outter.Value, inner.Value))
                .All(join => join.Item1 == join.Item2);
        }

        internal static void CheckFieldMatchingTypeProperties<T>(T first, T second, string errorMessage = "")
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var message = $"{(!string.IsNullOrEmpty(errorMessage) ? errorMessage : "")}'{type.FullName}':\nProperty {property.Name}:";

                CheckFieldMatching(property.GetValue(first), property.GetValue(second), message);
            }
        }

        internal static void CheckFieldMatching<TField>(TField first, TField second, string errorMessage = "")
        {
            if (!AreTheFieldsMatched(first, second))
            {
                throw CreateMisMatchException(first, second, errorMessage);
            }
        }

        internal static bool AreTheFieldsMatched<TField>(TField first, TField second)
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
