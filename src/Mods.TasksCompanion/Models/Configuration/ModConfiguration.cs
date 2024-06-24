using StardewModdingAPI;

namespace StardewCompanion.Mods.TasksCompanion.Models.Configuration;

internal sealed class ModConfiguration
{
    public SButton Hotkey { get; set; } = SButton.P;
    public bool Minimal { get; set; } = false;
    public bool AutoScale { get; set; } = true;
    public InGameDisplayConfig InGameDisplay { get; set; } = new();
    public bool Trace { get; set; } = false;
}
