using FrontSharp.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Models
{
    public class Target
    {
        public SourceTargetMetadata _meta { get; set; }
        [JsonConverter(typeof(SingleOrArrayConverter<Data>))]
        public List<Data> data { get; set; }
    }
}
