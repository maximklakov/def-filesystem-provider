using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.Endpoints;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace FileProvider.Endpoints
{
    [SupportedIds("{84F7A6ED-8A9A-4A7E-AA04-A0D81E3AB2F9}")]
    public class FileEnpointConverter:BaseEndpointConverter
    {
        private const string FileNameFieldName = "File";
        public FileEnpointConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override void AddPlugins(ItemModel source, Endpoint endpoint)
        {
            var settings = new FileSettings(){ FilePath = GetStringValue(source, FileNameFieldName) };
            endpoint.AddPlugin(settings);
        }
    }
}
