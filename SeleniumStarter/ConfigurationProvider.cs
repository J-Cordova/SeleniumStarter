using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumStarter
{
    public class ConfigurationProvider
    {
        public static Dictionary<string, string> GetConfiguration()
        {
            var appConfigFile = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent + "\\applicationconfig.json";
            var appConfigText = File.ReadAllText(appConfigFile);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(appConfigText);
        }
    }
}
