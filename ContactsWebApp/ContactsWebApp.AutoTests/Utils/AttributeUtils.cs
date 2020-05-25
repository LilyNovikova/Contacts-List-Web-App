using ContactsWebApp.Framework.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace ContactsWebApp.AutoTests.Utils
{
    public static class AttributeUtils
    {
        public static string GetLinkText(this Enum item)
        {
            var type = item.GetType();
            var name = Enum.GetName(type, item);
            return type.GetField(name).GetCustomAttribute<LinkTextAttribute>()?.LinkText ?? item.ToString();
        }

        public static object GetEnumOrNegativeByLinkText(string text, Type enumType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().Where(t => t.IsEnum).Where(t => t.Equals(enumType)).First();
            foreach (var field in type.GetFields())
            {
                var attribute = field.GetCustomAttribute<LinkTextAttribute>();
                if (attribute == null)
                {
                    continue;
                }
                if (attribute.LinkText == text)
                {
                    return field.GetValue(null);
                }
            }
            return default;
        }

        public static string GetHtmlID<T>(string field)
        {
            var attr = typeof(T).GetProperty(field).GetCustomAttribute<HtmlIdAttribute>();
            return attr.Id;
        }
    }
}
