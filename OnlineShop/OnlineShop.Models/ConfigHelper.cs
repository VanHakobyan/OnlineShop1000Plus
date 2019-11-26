using System.Configuration;
using Microsoft.Extensions.Configuration;

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
            return ConfigurationManager.AppSettings["DefaultConnection"];
        }
    }
}
