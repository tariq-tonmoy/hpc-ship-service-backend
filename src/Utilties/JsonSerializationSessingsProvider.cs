using Newtonsoft.Json;

namespace ShipService.Infrastructure.Utilities
{
    internal class JsonSerializationSessingsProvider
    {
        public JsonSerializerSettings GetJsonSerializerSettingsForPrivateProperties()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ContractResolver = new IncludePrivateStateContractResolver();
            return jsonSerializerSettings;
        }
    }
}
