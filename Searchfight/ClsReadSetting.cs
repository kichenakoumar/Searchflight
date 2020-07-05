using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searchfight
{
    class ClsReadSetting : ClsSearchCount
    {
        public static void ReadAllSettings()
        {
            try
            {
                var appSettings = System.Configuration.ConfigurationSettings.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.WriteLine("AppSettings is empty.");
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {

                        string[] mykey = ConfigurationSettings.AppSettings[key].Split(',');
                        newConfig.Add(new ClsConfig { sSrchEngine = key, sUrl = mykey[0], sXpath = mykey[1] });

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading app settings");
            }
        }

    }
}
