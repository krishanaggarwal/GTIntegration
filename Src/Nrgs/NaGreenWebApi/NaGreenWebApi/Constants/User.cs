
namespace NaGreenWebApi.Constants
{
    /// <summary>
    /// Contains user specific constants
    /// </summary>
    public static class User
    {
        /// <summary>
        /// Default balance of new user
        /// </summary>
        public const long DefaultBalance = 1000;

        /// <summary>
        /// User token url
        /// </summary>
        public const string UserTokenUrl = "Users/{0}/Tokens";
    }
}