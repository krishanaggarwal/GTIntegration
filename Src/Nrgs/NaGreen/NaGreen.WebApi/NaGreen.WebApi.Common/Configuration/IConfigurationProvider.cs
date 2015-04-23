using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Common.Configuration
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Fetch the value of configuration key from configuration store
        /// </summary>
        /// <param name="configurationKey">the key name of configuration setting</param>
        /// <returns>The value by the key name provided</returns>
        string GetConfigurationSettingValue(string configurationKey);

        /// <summary>
        /// Gets configuration settings.
        /// </summary>
        Dictionary<string, string> GetConfigurationSettings();

        /// <summary>
        /// Gets environment settings.
        /// </summary>
        Dictionary<string, string> GetEnvironmentSettings();
    }
}
