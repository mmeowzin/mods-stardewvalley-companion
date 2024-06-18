using StardewCompanion.Mods.ToDoCompanion.Configuration;
using StardewCompanion.Mods.ToDoCompanion.Models;

namespace StardewCompanion.Mods.ToDoCompanion.Events.GameLoop;

internal sealed class SaveLoadedEvent
{
    private SaveLoadedEvent() { }

    internal static ToDoInstance Handle(ModEntry mod)
    {
        return mod.Helper.Data.ReadSaveData<ToDoInstance>(ModKeys.DATA_IDENTIFIER) ?? new();
    }
}
