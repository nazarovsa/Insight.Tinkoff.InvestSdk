using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Insight.Tinkoff.InvestSdk.Infrastructure.Json
{
    internal static class JSerializer
    {
        private static readonly JsonSerializerSettings _settings;

        static JSerializer()
        {
            _settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public static void RegisterConverter(JsonConverter converter)
        {
            if (converter == null)
                throw new ArgumentNullException(nameof(converter));

            _settings.Converters.Add(converter);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }

        public static TObject Deserialize<TObject>(string json)
        {
            return JsonConvert.DeserializeObject<TObject>(json, _settings);
        }

        public static object Deserialize(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type, _settings);
        }
    }
}