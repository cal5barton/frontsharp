using FrontSharp.Serializers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontSharp.Models
{
    public class Source
    {
        public SourceTargetMetadata _meta { get; set; }

        [JsonConverter(typeof(SingleOrArrayConverter<Data>))]
        public List<Data> data { get; set; }
    }
}