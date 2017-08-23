using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrontSharp.Converters
{
    public class MultipartRequestConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return !objectType.IsPrimitive;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            var properties = value.GetType().GetProperties();
            if (serializer.NullValueHandling == NullValueHandling.Ignore) properties = properties.Where(x => x.GetValue(value) != null).ToArray();
            foreach (var property in properties)
            {
                var jsonIgnore = property.GetCustomAttribute<JsonIgnoreAttribute>() != null ? true : false;

                if(!jsonIgnore)
                {
                    var jsonProperty = property.GetCustomAttribute<JsonPropertyAttribute>();
                    var propertyName = jsonProperty?.PropertyName ?? property.Name;
                    if (IsNormal(property))
                    {
                        writer.WritePropertyName(propertyName);
                        serializer.Serialize(writer, property.GetValue(value));
                    }
                    else
                    {
                        if (property.PropertyType.GetInterfaces().Contains(typeof(IEnumerable)))
                        {
                            var listOfItems = (IEnumerable)property.GetValue(value);
                            if (listOfItems != null)
                            {
                                int index = 0;
                                foreach (var item in listOfItems)
                                {
                                    writer.WritePropertyName($"{propertyName}[{index}]");
                                    serializer.Serialize(writer, item);
                                    index++;
                                }
                            }
                        }
                        else
                        {
                            foreach (var child in property.PropertyType.GetProperties())
                            {
                                var childValue = child.GetValue(property.GetValue(value));
                                if (childValue != null || serializer.NullValueHandling == NullValueHandling.Include)
                                {
                                    var childJsonProperty = child.GetCustomAttribute<JsonPropertyAttribute>();
                                    var indexValue = childJsonProperty?.PropertyName ?? child.Name;
                                    writer.WritePropertyName($"{propertyName}[{indexValue}]");
                                    serializer.Serialize(writer, childValue);
                                }
                            }
                        }
                    }
                }
                
            }
            writer.WriteEndObject();   
        }

        private bool IsNormal(PropertyInfo propertyInfo)
        {
            return (propertyInfo.PropertyType.IsPrimitive || propertyInfo.PropertyType.Name.ToLower() == "string");
        }
        
    }
}
