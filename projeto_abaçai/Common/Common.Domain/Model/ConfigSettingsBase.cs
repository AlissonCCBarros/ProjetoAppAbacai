using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Domain.Model
{
    public class ConfigSettingsBase
    {
        public bool DisabledCache { get; set; }
        public string AuthorityEndPoint { get; set; }
        public string FrontApplicationUrl { get; set; }
        public string Secret { get; set; }
    }
}
