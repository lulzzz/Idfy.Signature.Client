using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Idfy.Signature.Client.Test
{
    public static class Config
    {
        private static Dictionary<string, string> _dict = null;
        public static Dictionary<string, string> ConfigDictionary
        {
            get
            {
                try
                {
                    if (_dict == null)
                    {
                        _dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("testcfg.json"));
                    }
                    return _dict;
                } catch(Exception e)
                {
                    throw new Exception("Failed to load config. Create a \"testcfg.json\" file in working directory", e);
                }
            }
        }

        public static string Get(string key)
        {
#if DEBUG
            return ConfigDictionary[key];
#else
            return Environment.GetEnvironmentVariable("TESTCFG_" + key);
#endif
        }
    }
}
