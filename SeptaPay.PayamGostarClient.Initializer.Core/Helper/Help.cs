using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeptaPay.PayamGostarClient.Initializer.Core.Helper
{
    public class Help
    {
        private const int MAX_GET_STRINGS_FROM_PROPERTIES_DEPTH = 2;

        public static string GetStringsFromProperties(Type type, object obj, int depth = MAX_GET_STRINGS_FROM_PROPERTIES_DEPTH)
        {
            if (obj == null)
            {
                return "null";
            }
            else if (IsSimpleTypeOrNullableSimpleType(type))
            {
                return $"{obj}";
            }
            else if (IsEnumerable(type, out Type genericArgument))
            {
                if (depth <= 0)
                {
                    return $"[{type.FullName}]";
                }
                else
                {
                    var messages = new List<string>();

                    foreach (var item in (IEnumerable)obj)
                    {
                        var subType = GetStringsFromProperties(item.GetType(), item, depth - 1);

                        messages.Add(subType);
                    }

                    var message = string.Join(",\n", messages);

                    return WriteAsIEnumerable($"[{genericArgument.FullName}]:", message);
                }
            }
            else
            {
                if (depth <= 0)
                {
                    return $"<{type.FullName}>";
                }
                else
                {
                    var properties = type.GetProperties();

                    var messages = new List<string>();

                    foreach (var property in properties)
                    {
                        try
                        {
                            if (!type.GetProperty(property.Name).GetIndexParameters().Any())
                            {
                                var value = property.GetValue(obj);

                                var subType = GetStringsFromProperties(property.PropertyType, value, depth - 1);

                                messages.Add($"{property.Name}: " + subType);
                            }
                        }
                        catch
                        {
                            messages.Add($"{property.Name}: <exception during reading>");
                        }
                    }

                    var message = string.Join(",\n", messages);

                    return WriteAsObject($"<{type.FullName}>:", message);
                }
            }
        }

        public static string GetStringsFromProperties<T>(T obj, int depth = MAX_GET_STRINGS_FROM_PROPERTIES_DEPTH) where T : class
        {
            var type = typeof(T);

            return GetStringsFromProperties(type, obj, depth);
        }


        /// <summary>
        /// Simple types : [ Primitive types ..., decimal, string, DateTime, DateTimeOffset, TimeSpan, Guid ] and Their Nullable<>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSimpleTypeOrNullableSimpleType(Type type)
        {
            if (type.IsGenericType && !type.IsGenericTypeDefinition && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var genericArgument = type.GetGenericArguments().FirstOrDefault() ?? typeof(object);

                return IsSimpleType(genericArgument);
            }

            return IsSimpleType(type);
        }

        public static bool IsEnumerable(Type type, out Type genericArgument)
        {
            if (type.IsGenericType && !type.IsGenericTypeDefinition && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
            {
                genericArgument = type.GetGenericArguments().FirstOrDefault() ?? typeof(object);

                return true;
            }

            genericArgument = null;

            return false;
        }

        /// <summary>
        /// Simple base types : [ Primitive types ..., Enums..., decimal, string, DateTime, DateTimeOffset, TimeSpan, Guid ].
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsSimpleType(Type type)
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

        public static string AddIndentation(string str, int count)
        {
            var separators = new char[] { '\r', '\n' };

            var indentation = new string('\t', count);

            var strBuilder = new StringBuilder(indentation);

            var lines = str.Split(separators, options: StringSplitOptions.RemoveEmptyEntries);

            var lineSeparator = Environment.NewLine + indentation;

            strBuilder = strBuilder.Append(string.Join(lineSeparator, lines));

            return strBuilder.ToString();
        }

        public static string WriteAsObject(string head, string body)
        {
            return $"{head}\n{{\n{AddIndentation(body, 1)}\n}}";
        }

        public static string WriteAsIEnumerable(string head, string body)
        {
            return $"{head}\n[\n{AddIndentation(body, 1)}\n]";
        }
    }

}
