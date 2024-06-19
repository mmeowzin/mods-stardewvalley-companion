using StardewCompanion.Mods.TasksCompanion.Configuration;
using StardewCompanion.Mods.TasksCompanion.Models.Tasks;

namespace StardewCompanion.Mods.TasksCompanion.Events.GameLoop;

internal sealed class SaveLoadedEvent
{
    private SaveLoadedEvent() { }

    internal static void Handle(ModEntry m)
    {
        m.PlayerTasks = m.Helper.Data.ReadSaveData<PlayerTasks>(ModKeys.DATA_IDENTIFIER) ?? new();

        m.Trace($"Current player tasks.", m.PlayerTasks);
    }
}
