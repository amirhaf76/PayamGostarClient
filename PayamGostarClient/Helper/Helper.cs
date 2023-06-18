using System;
using System.Collections.Generic;

namespace PayamGostarClient.Helper
{
    internal class Helper
    {
        public static string GetStringsFromProperties<T>(T obj) where T : class
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            var messages = new List<string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                messages.Add($"{property.Name}: {(value ?? "null")}");
                //if (IsValidTypeForPresentation(property.PropertyType))
                //{
                //}
                //else
                //{
                //    messages.Add($"{property.Name}: <{property.Name}>");
                //}
            }

            var message = string.Join(", ", messages);

            return $"{{<{type.Name}>: {message}}}";
        }

        private static bool IsValidTypeForPresentation(Type type)
        {
            return
                type.IsPrimitive ||
                type == typeof(decimal) ||
                type == typeof(string) ||
                type == typeof(DateTime) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(TimeSpan) ||
                type == typeof(Guid);
        }
    }
}
