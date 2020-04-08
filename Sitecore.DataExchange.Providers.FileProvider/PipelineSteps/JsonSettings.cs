using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.DataExchange;

namespace FileProvider.PipelineSteps
{
    public class JsonSettings:IPlugin
    {
        public string JPath { get; set; }   
    }
}
