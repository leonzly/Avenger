using System;
using System.Net;

namespace Avenger.Common.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class EnumResponseValue : Attribute
    {
        public HttpStatusCode StatusCode;
        public string Message { get; }
        public EnumResponseValue(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public EnumResponseValue(HttpStatusCode statusCode, string message) : this(statusCode)
        {
            Message = message;
        }
        public EnumResponseValue(string message) : this(HttpStatusCode.BadRequest, message) { }
        public EnumResponseValue(HttpStatusCode statusCode, string messageFormat, params string[] values) : this(statusCode, string.Format(messageFormat, values)) { }
        public EnumResponseValue(string messageFormat, params string[] values) : this(HttpStatusCode.BadRequest, string.Format(messageFormat, values)) { }
    }
}