using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FrontSharp.Models
{
    // NOTE: Replaces previous Handle class, rename required to allow for C# naming conventions
    public class ContactHandle : BaseResponseBody
    {
        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("source")]
        public ContactHandleSource Source { get; set; }
    }

    public enum ContactHandleSource
    {
        twitter,
        email,
        phone,
        custom
    }
}