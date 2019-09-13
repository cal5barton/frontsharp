using FrontSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace FrontSharp.Requests
{
    public class CreateContactRequest : UpdateContactRequest
    {
        [JsonProperty("handles")]
        public List<ContactHandle> Handles { get; set; }        
    }

    public class UpdateContactRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("is_spammer")]
        public bool IsSpammer { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }

        [JsonProperty("group_names")]
        public List<Group> GroupNames { get; set; }

        [JsonProperty("custom_fields")]
        public List<CustomFields> CustomFields { get; set; }
    }

    public class AddHandleRequest
    {
        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("source")]
        public ContactHandleSource Source { get; set; }
    }

    public class DeleteHandleRequest : AddHandleRequest
    {
        [JsonProperty("force")]
        public bool Force { get; set; }
    }

    public class CustomFields
    {
        [JsonProperty("job title")]
        public string JobTitle { get; set; }

        [JsonProperty("custom field name")]
        public string CustomFieldName { get; set; }
    }
}