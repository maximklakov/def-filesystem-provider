using System;
using Newtonsoft.Json.Linq;
using Sitecore.DataExchange.DataAccess;

namespace Sitecore.DataExchange.Providers.File.DataAccess.ValueReaders
{
    public class JsonNodeValueReader : IValueReader
    {
        public string JPath { get; set; }
        public ReadResult Read(object source, DataAccessContext context)
        {
            if (!(source is JToken))
            {
                return new ReadResult(DateTime.Now){WasValueRead = false};
            }

            return new ReadResult(DateTime.Now){ReadValue = ((JToken)source).SelectToken(JPath), WasValueRead = true};
            
        }
    }
}
