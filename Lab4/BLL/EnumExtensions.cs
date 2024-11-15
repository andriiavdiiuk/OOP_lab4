using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL
{
    public static class EnumExtensions
    {
        public static Type GetAttributeType<T>(this T enumValue) where T : Enum
        {
            var type = enumValue.GetType();
            var memberInfo = type.GetMember(enumValue.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(TypeAttribute<>), false);

            if (attributes.Length > 0)
            {
                var attributeType = attributes[0].GetType();
                var genericType = attributeType.GetGenericArguments()[0];
                return genericType;
            }
            throw new InvalidOperationException($"No Type attribute found for {enumValue}");
        }
    }
}
