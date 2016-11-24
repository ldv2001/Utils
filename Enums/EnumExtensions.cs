using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Enums
{
    /// <summary>
    /// Static class containing extensions methods to use with enums
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Method used to get a User-Friendly description for an enum member
        /// </summary>
        /// <returns>The content of the <see cref="DescriptionAttribute"/> if one is found on the num member, if not, returns <see cref="Enum.ToString()"/></returns>
        /// <remarks>
        /// From : http://stackoverflow.com/a/1415187/2245256
        /// </remarks>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                        Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }

        /// <summary>
        /// Method used to get a User-Friendly description for an enum member
        /// </summary>
        /// <typeparam name="T">The Enum Type</typeparam>
        /// <param name="enumerationValue">The enum value to get the description for</param>
        /// <returns>The content of the <see cref="DescriptionAttribute"/> if one is found on the num member, if not, returns <see cref="Enum.ToString()"/></returns>
        /// <remarks>
        /// From : http://stackoverflow.com/a/479417/2245256
        /// </remarks>
        public static string GetDescription<T>(this T enumerationValue) where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
    }
}
