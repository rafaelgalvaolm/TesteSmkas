using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Smkas.Core.Settings
{
    public class AppSettings
    {
        public bool HttpsRedirection { get; set; }
        public ConnectionString ConnectionString { get; set; }
        public string ApplicationName => Assembly.GetEntryAssembly().GetName().Name;
        public BaseUrlSettings BaseUrlSettings { get; set; }
    }
}