using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace StardewCompanion.Mods.TasksCompanion.Events.Input;

internal sealed class ButtonPressedEvent
{
    private ButtonPressedEvent() { }

    internal static void Handle(ModEntry mod, ButtonPressedEventArgs e)
    {
        if (!Context.IsWorldReady || e.Button != mod.Configuration.Hotkey)
            return;

        mod.Monitor.Log("");
    }
}
