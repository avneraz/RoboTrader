using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infra.Configuration
{
    public class ConfigHandler
    {
        private readonly string _path;

        public ConfigHandler(string path = null)
        {
            _path = path ?? "RobotConfig.json";
        }

        public AllConfigurations ReadConfig()
        {
            using (StreamReader r = new StreamReader(_path))
            {
                string json = r.ReadToEnd();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<AllConfigurations>(json);
            }
        }

        public void SaveConfig(AllConfigurations config)
        {
            using (var r = new StreamWriter(_path))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(config, Formatting.Indented);
                r.Write(json);
            }
        }
    }
}
