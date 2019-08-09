using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Settings
{
    public class SettingsData
    {
        public string Env { get; set; }
        public string StringConnection { get; set; }
        public string UrlBase { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProjectEndPoint { get; set; }
        public string UserEndPoint { get; set; }
        public string ProjectByIdEndPoint { get; set; }
    }
}
