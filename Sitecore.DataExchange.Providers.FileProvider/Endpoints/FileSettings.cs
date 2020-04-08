using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.DataExchange;

namespace FileProvider.Endpoints
{
    public class FileSettings:IPlugin
    {
        public string FilePath { get; set; }
    }
}
