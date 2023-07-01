using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace PayamGostarClient.Helper
{
    public class Helper
    {
        public static string GetStringsFromProperties(Type type, object obj, int depth = 1)
        {
            var properties = type.GetProperties();
   
            var messages = new List<string>();

            if (obj != null)
            {
                foreach (var property in properties)
                {
                    var value = property.GetValue(obj);

                    if (IsSimpleTypeOrNullableSimpleType(property.PropertyType))
                    {
                        messages.Add($"{property.Name}: {(value ?? "null")}");
                    }
                    else
                    {
                        if (depth <= 0)
                        {
                            messages.Add($"{property.Name}: <{property.PropertyType.FullName}>");
                        }
                        else
                        {
                            var subType = GetStringsFromProperties(property.PropertyType, value, depth - 1);

                            messages.Add($"{property.Name}"+subType);
                        }
                    }
                }
            }

            var message = obj != null ? string.Join(",\n", messages) : "null";

            return WriteAsObject($"<{type.FullName}>:", message);
        }

        public static string GetStringsFromProperties<T>(T obj, int depth = 1) where T : class
        {
            var type = typeof(T);

            return GetStringsFromProperties(type, obj, depth);
        }


        /// <summary>
        /// Simple types : [ Primitive types ..., decimal, string, DateTime, DateTimeOffset, TimeSpan, Guid ] and Their Nullable<>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsSimpleTypeOrNullableSimpleType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var genericArgument = type.GetGenericArguments().FirstOrDefault() ?? typeof(object);

                return IsSimpleType(genericArgument);
            }

            return IsSimpleType(type);
        }

        private static bool IsEnumerableOfSimpleType(Type type, out Type genericArgument)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                genericArgument = type.GetGenericArguments().FirstOrDefault() ?? typeof(object);

                return IsSimpleType(genericArgument);
            }

            genericArgument = null;

            return false;
        }

        /// <summary>
        /// Simple base types : [ Primitive types ..., Enums..., decimal, string, DateTime, DateTimeOffset, TimeSpan, Guid ].
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsSimpleType(Type type)
        {
            return
                type.IsPrimitive ||
                type == typeof(decimal) ||
                type == typeof(string) ||
                type == typeof(DateTime) ||
                type == typeof(DateTimeOffset) ||
                type == typeof(TimeSpan) ||
                type == typeof(Guid) ||
                type.IsEnum;
        }

        private static string AddIndentation(string str, int count)
        {
            var separators = new char[]{ '\r', '\n' };
  
            var indentation = new string('\t', count);

            var strBuilder = new StringBuilder(indentation);

            var lines = str.Split(separators, options: StringSplitOptions.RemoveEmptyEntries);

            var lineSeparator = Environment.NewLine + indentation;

            strBuilder = strBuilder.Append(string.Join(lineSeparator, lines));

            return strBuilder.ToString(); 
        }

        private static string WriteAsObject(string head, string body)
        {
            return $"{head}\n{{\n{AddIndentation(body, 1)}\n}}";
        }

        private static string WriteAsIEnumerable(string head, string body)
        {
            return $"{head}\n[\n{AddIndentation(body, 1)}\n]";
        }
    }

}
