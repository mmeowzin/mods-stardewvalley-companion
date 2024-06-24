namespace StardewCompanion.Mods.TasksCompanion.Events.GameLoop;

internal sealed class SavingEvent
{
    private SavingEvent() { }

    internal static void Handle(ModEntry m) => m.SaveTasks();
}
