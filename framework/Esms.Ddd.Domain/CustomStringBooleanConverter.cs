using Newtonsoft.Json;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Ddd.Domain
{
    /// <summary>
    /// JSON自定义转换规则
    /// </summary>
    public class CustomStringBooleanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value.ObjToString().ToLower() == "true")
            {
                return "8";
            }
            else if (reader.Value.ObjToString().ToLower() == "false")
            {
                return "9";
            }
            return reader.Value;
        }


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((string)value == "8");
        }
    }
}
