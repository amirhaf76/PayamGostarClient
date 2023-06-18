using System;
using System.Collections.Generic;
using System.Text;

namespace PayamGostarClient.Helper
{
    internal class Helper
    {
        public static string GetStringsFromProperties<T>(T obj) where T: class
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            var messages = new List<string>();

            foreach (var property in properties)
            {
                var value = property.GetValue(obj);

                messages.Add($"{property.Name}: {(value ?? "null")}");
            }

            var message = string.Join(", ", messages);

            return $"{{<{type.Name}>: {message}}}";
        }
    }
}
