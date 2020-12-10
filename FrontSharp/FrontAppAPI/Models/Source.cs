using FrontAppAPI.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontAppAPI.Models
{
    public class Source
    {
        public SourceTargetMetadata _meta { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Data>))]
        public List<Data> data { get; set; }
    }
}