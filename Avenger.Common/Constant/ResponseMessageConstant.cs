namespace Avenger.Common.Constant
{
    public class ResponseMessageConstant
    {
        /// <summary>
        /// Error Type.
        /// </summary>
        public const string ERRORTYPE_EDIT_MODEL_FAIL = "Failed to update record!";
        public const string USERNAME_EXISTED = "Username already exsits!";
        public const string EMAIL_EXISTED = "Email already exsits!";
        public const string USER_NOT_FOUND = "User not found!";
        public const string RECORD_NOT_FOUND = "Record not found!";
        public const string SESSION_TIMEOUT = "Opps, Session timeout!";
        public const string TOKEN_NOT_FOUND = "Token not found!";
        public const string ROLE_NOT_FOUND = "Sorry, role not found!";
        public const string ROLE_EXISTED = "Role already existed.";
        public const string ROLE_STILL_IN_USED = "Sorry, unable to delete this role. Because this role still using in other user.";
        public const string MERCHANT_EXISTED = "This merchant name is being used";
        public const string ATLEAST_TWO_CONDITION = "Rule must be create with at least 2 conditions and above.";
        public const string NOT_AUTHORIZE = "Sorry, You do not have permission to {0}.";
        public const string RULE_EXISTED = "Rule already existed.";


        /// <summary>
        /// Error Detail.
        /// </summary>
        public const string ERROR_MESSAGE_MODEL_VALIDATION = "Model validation failed. Message received has incorrect format. Please double check 'message' format.";
        public const string ERROR_MESSAGE_EVENTTYPE_VALIDATION = "EventType validation failed. Message received has mismatch eventType. Please double check 'eventType' property.";
        public const string ERROR_NULL_ENTITY_PASSED = "Entity mismatch. Please double check if request format is correct.";
        public const string ERROR_UPDATE_NOT_EXISTS = "Record not found. Please double check if record exists.";
        public const string ERROR_UPDATE_EXCEPTION = "Exception caught while updating record.";
        public const string ERROR_SEND_MESSAGE = "Message with Correlation Id {0} sent failed.";
        public const string ERROR_UPDATE_WITH_MESSAGE_CREATION = "Model update successful, response message : {0} | Message creating failed.";
        public const string ERROR_UPDATE_WITH_MESSAGE_SEND = "Model update successful, response message : {0} | Messaging failed, response message : {1}";
        public const string ERROR_MESSAGE = "Opps, Unable to {0}. Kindly contact Administrator";

        /// <summary>
        /// Success Detail.
        /// </summary>
        public const string SUCCESS_ENTITY_INSERT = "Record was successfully inserted";
        public const string SUCCESS_ENTITY_UPDATE = "Record was successfully updated";
        public const string SUCCESS_ENTITY_DELETE = "Record was successfully deleted";
        public const string SUCCESS_ENTITY_UPDATED = "Record has being updated.";
        public const string SUCCESS_LOGOUT = "User was logout successful.";
        public const string VALID_TOKEN = "Token still under vaild period.";
        public const string SUCCESS_PASSWORD_UPDATED = "Password has being updated.";
        public const string SUCCESS_SEND_MESSAGE = "Message with Correlation Id {0} sent successfully.";
        public const string SUCCESS_UPDATE_WITH_MESSAGE_SEND = "Model update successful, response message : {0} | Messaging success, response message : {1}";
            

        /// <summary>
        /// Fail Detail.
        /// </summary>
        public const string FAILED_ENTITY_INSERT = "Sorry, Failed insert the record";
        public const string FAILED_ENTITY_UPDATE = "Sorry, Failed update the record";
        public const string FAILED_ENTITY_DELETE = "Sorry, Failed delete the record";
        public const string FAILED_ENTITY_GETALL_RECORD = "Sorry, Failed to get all records";
        public const string FAILED_ENTITY_GET_RECORD = "Sorry, Failed to get the record";
        public const string FAILED_TO_LOGIN = "Username or password incorrect";
        public const string FAILED_LOGOUT = "Sorry, Failed to logout.";
        public const string FAILED_CHANGE_PASSWORD = "Sorry, Failed to change password.";
        public const string FAILED_CHANGE_ROLE = "Sorry, You do not have permission to change this role.";
        public const string FAILED_GET_DB_RECORD = "Sorry, Failed to get the record from database";
        public const string FAILED_MODEL_EMPTY = "Opps, Request model is empty.";
        public const string FAILED_NO_RECORD_TO_SAVE = "No records to save";
    }
}
