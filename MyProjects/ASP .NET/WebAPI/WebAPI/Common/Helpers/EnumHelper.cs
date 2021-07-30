using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Common.ExceptionHandling;

namespace WebAPI.Common.Helpers
{
    public static class EnumHelper
    {
        public static void ThrowCustomErrorException<T>(this T value, HttpStatusCode code, string description = null)
            where T : Enum
        {
            var errorDescription = string.IsNullOrEmpty(description) ? value.GetDescription() : description;
            throw new CustomErrorException((int)Convert.ChangeType(value, typeof(int)), code);
        }

        public static string GetDescription(this Enum enumValue)
        {
            var description = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            if (fieldInfo != null)
            {
                var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attrs != null && attrs.Length > 0)
                {
                    description = ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return description;
        }
    }
}
