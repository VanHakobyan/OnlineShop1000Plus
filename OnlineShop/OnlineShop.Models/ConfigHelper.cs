using System.Configuration;
using Serilog;

namespace OnlineShop
{
    public static class ConfigHelper
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
        public static string GetDefaultConnectionString()
        {
            var appSetting = ConfigurationManager.AppSettings["DefaultConnection"];
            Log.Logger.Information($"app config:{appSetting}");
            return appSetting;
        }
    }
}
