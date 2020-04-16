using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Diagnostics;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Providers.File.DataAccess.ValueReaders
{
    [SupportedIds("{1EC8DE13-7FB2-4F13-BEEA-F72C06BA1BFA}")]
    public class JsonNodeValueReaderConverter : BaseItemModelConverter<IValueReader>
    {
        public const string JPathFieldName = "JPath";

      
        protected override ConvertResult<IValueReader> ConvertSupportedItem(ItemModel source)
        {
            var reader = new JsonNodeValueReader() {JPath = GetStringValue(source, JPathFieldName)};
            return PositiveResult(reader);
        }

        public JsonNodeValueReaderConverter(IItemModelRepository repository, ILogger logger) : base(repository, logger)
        {
        }

        public JsonNodeValueReaderConverter(IItemModelRepository repository) : base(repository)
        {
        }
    }
}
