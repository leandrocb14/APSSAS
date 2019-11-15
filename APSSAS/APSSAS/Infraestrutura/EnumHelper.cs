using System;
using System.ComponentModel;

namespace APSSAS.Infraestrutura
{
    public static class EnumHelper
    {
        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }

        public static string Description(this Enum enumVal)
        {
            var attribute = enumVal.GetAttribute<DescriptionAttribute>();
            return attribute == null ? enumVal.ToString() : attribute.Description;
        }

        public static string DefaultValue(this Enum enumVal)
        {
            var attribute = enumVal.GetAttribute<DefaultValueAttribute>();
            return attribute == null ? enumVal.GetHashCode().ToString() : attribute.Value.ToString();
        }
    }
}