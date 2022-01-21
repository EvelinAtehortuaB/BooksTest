using DataAccess.Enums;

namespace DataAccess.Common
{
    public static class Messages
    {

        #region [ Generales ]

        public const string Ok = "Correct";
        public const string NotFound = "Resource not found";
        public const string Error = "Unknown error";
        public const string TimeOut = "Timeout";
        public const string NotNetwork = "There is no internet conection";
        public const string ErrorLogin = "User or password incorrect";
        public const string CampoVacio = "The field {0} is require";
        #endregion [ Generales ]

        public static string GetMessage(ResultCodes code)
        {
            switch (code)
            {
                case ResultCodes.Ok: return "¡All is ok!";
                case ResultCodes.Created: return "¡The register was created successfully!";
                case ResultCodes.ValidationError: return "There is an error in the data";
                case ResultCodes.NoContent: return "No results";
                default: return "Error";
            }

        }
    }
}
