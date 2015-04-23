using System;

namespace NaGreenWebApi.Constants
{
    /// <summary>
    /// Date Constants
    /// </summary>
    public static class Date
    {
        /// <summary>
        /// Current date
        /// </summary>
        public static readonly DateTime Today = DateTime.Now;
        /// <summary>
        /// Current date in Utc format
        /// </summary>
        public static readonly string Utc = DateTime.Now.ToString("o");
    }
}