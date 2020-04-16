using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters.PipelineSteps;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Providers.File.PipelineSteps
{
    [SupportedIds("{4C018FFF-5DD8-4013-B756-6D626D9D8B1A}")]
    public class ReadJsonFilePipelineStepConverter: BaseReadObjectsFromEndpointStepConverter
    {
        public const string JPathFieldName = "JPath";
        public ReadJsonFilePipelineStepConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override void AddPlugins(ItemModel source, PipelineStep pipelineStep)
        {
            base.AddPlugins(source,pipelineStep);
            var settings = new JsonSettings(){JPath = GetStringValue(source, JPathFieldName) };
            pipelineStep.AddPlugin(settings);
        }
    }
}
