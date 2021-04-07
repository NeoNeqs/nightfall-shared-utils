using System;
using System.Reflection;

namespace SharedUtils.Common
{
    public static class EnumHelper
    {
        public static T GetFirstAttributeOrNullOfType<T>(this Enum enumVal) where T : Attribute
        {
            Type type = enumVal.GetType();
            MemberInfo[] memInfo = type.GetMember(enumVal.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? attributes[0] as T : null;
        }

    }
}