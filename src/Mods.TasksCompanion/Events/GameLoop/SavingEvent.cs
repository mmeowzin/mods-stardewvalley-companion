using StardewCompanion.Mods.TasksCompanion.Configuration;

namespace StardewCompanion.Mods.TasksCompanion.Events.GameLoop;

internal sealed class SavingEvent
{
    private SavingEvent() { }

    internal static void Handle(ModEntry m)
    {
        var data = m.PlayerTasks.Sanitize();

        m.Helper.Data.WriteSaveData(ModKeys.DATA_IDENTIFIER, data);

        m.Trace("Current player tasks saved.", data);
    }
}
