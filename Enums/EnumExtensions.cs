using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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
    }
}
