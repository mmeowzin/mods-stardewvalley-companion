using System.Text.Json;
using StardewCompanion.Mods.TasksCompanion.Configuration;

namespace StardewCompanion.Mods.TasksCompanion.Models.Configuration;

internal sealed record LogMessage(string Message, object Data)
{
    public override string ToString() => JsonSerializer.Serialize(this, ModKeys.JSON_SERIALIZER_OPTIONS);
};
