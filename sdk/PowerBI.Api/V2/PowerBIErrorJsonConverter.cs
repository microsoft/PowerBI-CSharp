using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.PowerBI.Api.V2
{
    /// <summary>
    /// JsonConverter that provides custom deserialization for PowerBIError objects.
    /// </summary>
    public class PowerBIErrorJsonConverter : JsonConverter
    {
        private const string ErrorNode = "error";

        /// <summary>
        /// Returns true if the object being serialized is a PBIError.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized is a PBIError. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(PowerBIError) == objectType;
        }

        /// <summary>
        /// Deserializes an object from a JSON string and flattens out Error property.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jobject = JObject.Load(reader);
            var jproperty = jobject.Properties().FirstOrDefault(p => ErrorNode.Equals(p.Name, StringComparison.OrdinalIgnoreCase));
            if (jproperty != null)
                jobject = jproperty.Value as JObject;
            return jobject.ToObject<PowerBIError>(serializer.WithoutConverter(this));
        }

        /// <summary>
        /// Serializes an object into a JSON string adding Properties.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    public static class JsonSerializerExtensions
    {
        /// <summary>Gets a JsonSerializer without specified converter.</summary>
        /// <param name="serializer">JsonSerializer</param>
        /// <param name="converterToExclude">Converter to exclude from serializer.</param>
        /// <returns></returns>
        public static JsonSerializer WithoutConverter(this JsonSerializer serializer, JsonConverter converterToExclude)
        {
            if (serializer == null)
                throw new ArgumentNullException(nameof(serializer));
            JsonSerializer jsonSerializer = new JsonSerializer();
            foreach (PropertyInfo propertyInfo in typeof(JsonSerializer).GetTypeInfo().DeclaredProperties.Where(p =>
            {
                if (p.SetMethod != null && !p.SetMethod.IsPrivate)
                    return p.GetCustomAttribute(typeof(ObsoleteAttribute)) == null;
                return false;
            }))
                propertyInfo.SetValue(jsonSerializer, propertyInfo.GetValue(serializer, null), null);
            foreach (JsonConverter converter in serializer.Converters)
            {
                if (converter != converterToExclude)
                    jsonSerializer.Converters.Add(converter);
            }
            return jsonSerializer;
        }
    }
}