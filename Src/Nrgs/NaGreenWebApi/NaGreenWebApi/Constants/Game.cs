
namespace NaGreenWebApi.Constants
{
    /// <summary>
    /// Game constants
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// Url to get list of all games
        /// </summary>
        public const string GamesUrlWithUserId = "Games?LanguageCode={0}&UserId={1}";

        /// <summary>
        /// Url to get list of all games
        /// </summary>
        public const string GamesUrlWithOutUserId = "Games?LanguageCode={0}";
    }
}