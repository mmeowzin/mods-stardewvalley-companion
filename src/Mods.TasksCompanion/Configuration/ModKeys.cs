using System.Text.Json;
using System.Text.Json.Serialization;

namespace StardewCompanion.Mods.TasksCompanion.Configuration;

internal static class ModKeys
{
    private static JsonSerializerOptions _jsonSerializerOptions;

    public const string DATA_IDENTIFIER = "SWC_TASKS_COMPANION";

    public static JsonSerializerOptions JSON_SERIALIZER_OPTIONS
    {
        get
        {
            _jsonSerializerOptions ??= new()
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return _jsonSerializerOptions;
        }
    }
}
