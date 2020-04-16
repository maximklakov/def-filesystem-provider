using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.DataExchange.Attributes;
using Sitecore.DataExchange.Converters;
using Sitecore.DataExchange.Converters.DataAccess.ValueAccessors;
using Sitecore.DataExchange.DataAccess;
using Sitecore.DataExchange.DataAccess.Readers;
using Sitecore.DataExchange.DataAccess.Writers;
using Sitecore.DataExchange.Providers.File.DataAccess.ValueReaders;
using Sitecore.DataExchange.Repositories;
using Sitecore.Services.Core.Diagnostics;
using Sitecore.Services.Core.Model;

namespace Sitecore.DataExchange.Providers.File.DataAccess.ValueAccessors
{
    [SupportedIds("{AC61B7C3-0EBD-4275-A099-2254CDCBA541}")]
    public class JsonNodeValueAccessorConverter: BaseItemModelConverter<IValueAccessor>
    {
        public const string JPathFieldName = "JPath";
        public const string FieldNameValueReader = "ValueReader";
        public const string FieldNameValueWriter = "ValueWriter";



        public JsonNodeValueAccessorConverter(IItemModelRepository repository, ILogger logger) : base(repository, logger)
        {
        }

        public JsonNodeValueAccessorConverter(IItemModelRepository repository) : base(repository)
        {
        }

        protected override ConvertResult<IValueAccessor> ConvertSupportedItem(ItemModel source)
        {
            var accessor = new ValueAccessor();

            // First - get overriden Value Reader / Writer
            accessor.ValueReader = GetValueReader(source);
            accessor.ValueWriter = GetValueWriter(source);

            // Than if no custom Value Reader is set - use JsonNode Reader
            if (accessor.ValueReader == null)
            {
                accessor.ValueReader = new JsonNodeValueReader() { JPath = GetStringValue(source, JPathFieldName) };
            }
            
            return new ConvertResult<IValueAccessor>(){ConvertedValue = accessor, WasConverted = true};
        }

        public virtual IValueReader GetValueReader(ItemModel source)
        {
            return this.ConvertReferenceToModel<IValueReader>(source, FieldNameValueReader);
        }
        public virtual IValueWriter GetValueWriter(ItemModel source)
        {
            return this.ConvertReferenceToModel<IValueWriter>(source, FieldNameValueWriter);
        }


    }
}
