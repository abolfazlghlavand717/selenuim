using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class ChromeDriverPath
    {
        public static string GetChromeDriverPath()
        {
            var statup = Assembly.GetExecutingAssembly().Location;
            var path = Directory.GetParent(statup).Parent.Parent.Parent;
            return path + "\\" + "chromedriver.exe";
        }
    }
}
