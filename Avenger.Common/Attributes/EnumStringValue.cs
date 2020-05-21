using System;

namespace Avenger.Common.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnumStringValue : Attribute
    {
        public string Value { get; }
        public EnumStringValue(string value)
        {
            Value = value;
        }
        public EnumStringValue(string valueFormat, params string?[] values)
        {
            Value = string.Format(valueFormat, values);
        }
    }
}