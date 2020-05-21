using Avenger.Common.Attributes;
using System;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Avenger.Common.Extensions
{
    public static class EnumExtension
    {
        //public static string GetStringValue<T>(this T e) where T : IConvertible
        //{
        //    if (e != null && e is System.Enum)
        //    {
        //        Type type = e.GetType();
        //        Array values = System.Enum.GetValues(type);

        //        foreach (int val in values)
        //        {
        //            if (val == e.ToInt32(CultureInfo.InvariantCulture))
        //            {
        //                var memInfo = type.GetMember(type.GetEnumName(val));
        //                var enumValueAttribute = memInfo[0]
        //                    .GetCustomAttributes(typeof(EnumStringValue), false)
        //                    .FirstOrDefault() as EnumStringValue;

        //                if (enumValueAttribute != null)
        //                    return enumValueAttribute.Value;
        //            }
        //        }
        //    }
        //    return null;
        //}

        public static string GetResponseMessage<T>(this T e) where T : IConvertible
        {
            if (e != null && e is System.Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var enumResponseAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(EnumResponseValue), false)
                            .FirstOrDefault() as EnumResponseValue;

                        if (enumResponseAttribute != null)
                            return enumResponseAttribute.Message;
                    }
                }
            }
            return null;
        }

        public static HttpStatusCode GetResponseCode<T>(this T e) where T : IConvertible
        {
            if (e != null && e is System.Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var enumResponseAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(EnumResponseValue), false)
                            .FirstOrDefault() as EnumResponseValue;

                        if (enumResponseAttribute != null)
                            return enumResponseAttribute.StatusCode;
                    }
                }
            }
            return HttpStatusCode.BadRequest;
        }
    }
}
