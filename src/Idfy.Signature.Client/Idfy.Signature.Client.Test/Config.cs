using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                        var file = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("testcfg.json"));
                        var selected = file.Value<string>("selected");
                        _dict = file.GetValue(selected).ToObject<Dictionary<string, string>>();
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
