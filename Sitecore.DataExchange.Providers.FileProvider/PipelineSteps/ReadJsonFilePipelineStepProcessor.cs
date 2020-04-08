using System.Collections;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sitecore.DataExchange.Contexts;
using Sitecore.DataExchange.Models;
using Sitecore.DataExchange.Plugins;
using Sitecore.DataExchange.Processors.PipelineSteps;
using Sitecore.DataExchange.Providers.File.Endpoints;
using Sitecore.Services.Core.Diagnostics;

namespace Sitecore.DataExchange.Providers.File.PipelineSteps
{
    public class ReadJsonFilePipelineStepProcessor : BaseReadDataStepProcessor
    {
        protected override void ReadData(Endpoint endpoint, PipelineStep pipelineStep, PipelineContext pipelineContext,
            ILogger logger)
        {
            var endpointSettings = endpoint.GetPlugin<FileSettings>();

            if (string.IsNullOrWhiteSpace(endpointSettings.FilePath))
            {
                logger.Error("File name should not be empty");
                return;
            }
            
            var jsonSettings = pipelineStep.GetPlugin<JsonSettings>();
            if ((jsonSettings == null)||(string.IsNullOrWhiteSpace(jsonSettings.JPath)))
            {
                logger.Error("Cannot read JToken settings");
                return;
            }

            IEnumerable jarray;
            using (StreamReader file = System.IO.File.OpenText(endpointSettings.FilePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JToken o2 = JToken.ReadFrom(reader);
                logger.Info("File was read");
                JToken token = o2.SelectToken(jsonSettings.JPath);
                if (!(token is JArray))
                {
                    logger.Error("Element specified is not a JSon Array");
                    return;
                }

                jarray = (JArray)token;
            }

            if (!(jarray is IEnumerable))
            {
                logger.Error("Trying to read object, that is not an IEnumerable");
                return;
            }

            logger.Info("Data were read from file");
            var dataSettings = new IterableDataSettings() {Data = jarray};
            pipelineContext.AddPlugin(dataSettings);
        }
    }
}