using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using
using System.Reflection;

namespace TestProject2
{
    internal class ChromeDriverPath
    {
        public static string GetDriver()
        {
            var statup = Assembly.GetExecutingAssembly().Location;
            var path = Directory.GetParent(statup).Parent.Parent.Parent;
            return path + "\\" + "chromedriver.exe";
        }
    }
}
