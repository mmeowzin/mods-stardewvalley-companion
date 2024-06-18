using StardewCompanion.Mods.ToDoCompanion.Configuration;

namespace StardewCompanion.Mods.ToDoCompanion.Events.GameLoop;

internal sealed class SavingEvent
{
    private SavingEvent() { }

    internal static void Handle(ModEntry mod)
    {
        mod.Helper.Data.WriteSaveData(ModKeys.DATA_IDENTIFIER, mod.Instance.Sanitize());
    }
}
