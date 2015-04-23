using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaGreen.WebApi.Common.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
         /// <summary>
        /// Holds the settings as key value pair collection
        /// </summary>
        private readonly Dictionary<string, string> configurationStore;

        /// <summary>
        /// Holds the settings as key value pair collection for app settings.
        /// </summary>
        private readonly Dictionary<string, string> configurationStoreForEnvironment;

        /// <summary>
        /// Holds the settings as key value pair collection for environment variables.
        /// </summary>
        private readonly Dictionary<string, string> configurationStoreForConfiguration;


        /// <summary>
        /// Initializes a new instance of the <see cref="NrgsConfigurations"/> class. 
        /// </summary>
        public ConfigurationProvider()
        {
            this.configurationStore = new Dictionary<string, string>();
            this.configurationStoreForEnvironment = new Dictionary<string, string>();
            this.configurationStoreForConfiguration = new Dictionary<string, string>();
            this.LoadConfigurations();
        }

        /// <summary>
        /// Fetch the value of configuration key from configuration store
        /// </summary>
        /// <param name="configurationKey">the key name of configuration setting</param>
        /// <returns>The value by the key name provided</returns>
        public string GetConfigurationSettingValue(string configurationKey)
        {
            string value = string.Empty;
            if (this.configurationStore.Keys.Contains(configurationKey))
            {
                value = this.configurationStore[configurationKey] as string;
            }
            return value;
        }

        /// <summary>
        /// Gets configuration settings for logging.
        /// </summary>
        public Dictionary<string, string> GetConfigurationSettings()
        {
            return new Dictionary<string, string>(configurationStoreForConfiguration);
        }

        /// <summary>
        /// Gets environment settings for logging.
        /// </summary>
        public Dictionary<string, string> GetEnvironmentSettings()
        {
            return new Dictionary<string, string>(configurationStoreForEnvironment);
        }

        /// <summary>
        /// load all application wide configurations
        /// </summary>
        public void LoadConfigurations()
        {
            if (this.configurationStore.Count != 0)
            {
                return;
            }

            this.LoadEnviromentVariables();
            this.LoadAppSettings();
        }

        /// <summary>
        /// Loads the required environment variables
        /// </summary>
        private void LoadEnviromentVariables()
        {
            Hashtable systemEnvironmentVariables = (Hashtable)Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Machine);
            Hashtable userEnvironmentVariables = (Hashtable)Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
            Hashtable processEnvironmentVariables = (Hashtable)Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);

            foreach (string item in processEnvironmentVariables.Keys)
            {
                this.configurationStore.Add(item, processEnvironmentVariables[item].ToString());
                this.configurationStoreForEnvironment.Add(item, processEnvironmentVariables[item].ToString());
               
            }

            foreach (string item in userEnvironmentVariables.Keys)
            {
                if (!this.configurationStore.ContainsKey(item))
                {
                    this.configurationStore.Add(item, userEnvironmentVariables[item].ToString());
                    this.configurationStoreForEnvironment.Add(item, userEnvironmentVariables[item].ToString());
                }
            }

            foreach (string item in systemEnvironmentVariables.Keys)
            {
                if (!this.configurationStore.ContainsKey(item))
                {
                    this.configurationStore.Add(item, systemEnvironmentVariables[item].ToString());
                    this.configurationStoreForEnvironment.Add(item, systemEnvironmentVariables[item].ToString());
                }
            }
        }

        /// <summary>
        /// Loads the applicatoin settings
        /// </summary>
        private void LoadAppSettings()
        {
            var iterator = ConfigurationManager.AppSettings;
            foreach (var item in iterator.AllKeys)
            {
                if (!this.configurationStore.ContainsKey(item))
                {
                    this.configurationStore.Add(item, iterator[item]);
                    this.configurationStoreForConfiguration.Add(item, iterator[item]);
                }
            }
        }

    }
}
