using System;

namespace SharedUtils.Common
{
    public static class EnumHelper
    {
        public static T GetAttributeOrNullOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? attributes[0] as T : null;
        }
    }
}