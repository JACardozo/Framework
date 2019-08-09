using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utils.Settings
{
    public class SettingsManager
    {
        public static TestContext context { get; set; }
        private SettingsManager()
        {
            data = LoadSettings();
        }
        private SettingsData data;

        public SettingsData Data
        {
            get { return data; }
        }

        private static SettingsManager instance = null;

        /// <summary>
        /// Singleton implementation that Initializes an SettingsManager object
        /// </summary>
        /// <returns></returns>
        public static SettingsManager Instance()
        {
            if (instance == null)
                instance = new SettingsManager();

            return instance;
        }

        /// <summary>
        /// Read the test run settings file.
        /// </summary>
        /// <returns></returns>
        private SettingsData LoadSettings()
        {

            SettingsData settings = new SettingsData();
            settings.Env = context.Properties["env"].ToString().ToUpper();
            if (settings.Env.Equals("SQLSERVER"))
            {
                settings.StringConnection = context.Properties["SQL"].ToString();
            }

            settings.UrlBase = context.Properties["urlBase"].ToString();
            settings.UserName = context.Properties["userName"].ToString();
            settings.Password = context.Properties["password"].ToString();

            settings.UserEndPoint = context.Properties["usersEndPoint"].ToString();
            settings.ProjectEndPoint = context.Properties["projectsEndPoint"].ToString();
            settings.ProjectByIdEndPoint = context.Properties["projectById"].ToString();

            return settings;

        }
    }
}
