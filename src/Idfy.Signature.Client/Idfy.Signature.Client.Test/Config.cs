using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Idfy.Signature.Client.Test
{
    public static class Config
    {
        public static Dictionary<string, string> debugConfig = new Dictionary<string, string>()
        {
            { "AccountId", "INSERT_VALUE" },
            { "ClientId", "INSERT_VALUE" },
            { "ClientSecret", "INSERT_VALUE" },
            { "Scope", "INSERT_VALUE" },
            { "IsProd", "INSERT_VALUE" },
        };

        public static string Get(string key)
        {
#if DEBUG
            return debugConfig[key];
#else
            return Environment.GetEnvironmentVariable("TESTCFG_" + key);
#endif
        }
    }
}
