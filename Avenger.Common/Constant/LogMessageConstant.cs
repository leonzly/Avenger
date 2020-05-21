namespace Avenger.Common.Constant
{
    public class LogMessageConstant
    {
        /// <summary>
        /// Info message.
        /// </summary>
        public const string LOG_INFO_PUBLISH_MSG = "Begin publishing message from {messageType}.";
        public const string LOG_INFO_CREATED_MSG = "Message created. | MemberCode : {0} | Currency : {1}";

        /// <summary>
        /// Error message.
        /// </summary>
        public const string LOG_ERROR_PUBLISH_MSG = "Error publishing message from {messageType}.";
        public const string LOG_ERROR_UPDATE_MODEL = "Model update service failed.";
        public const string LOG_ERROR_CREATE_MSG = "Error creating message from model : {model} and eventType : {eventType}.";
        public const string LOG_ERROR_CONVERT_DAILYDEALMODEL = "Validation failed when converting daily deal model.";
    }
}
