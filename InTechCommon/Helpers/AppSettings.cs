using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTechCommon.Helpers
{
    public static class AppSettings
    {
        private static IConfiguration? config;

        public static void Initialize(IConfiguration Configuration)
        {
            config = Configuration;
        }

        public static string?  GetKeyValue(string key)
        {
            return  config[key];
        }
    }
}
