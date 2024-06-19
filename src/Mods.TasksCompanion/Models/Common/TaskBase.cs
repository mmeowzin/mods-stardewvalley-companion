using StardewCompanion.Mods.TasksCompanion.Models.Enums;
using StardewCompanion.Mods.TasksCompanion.Models.Tasks;

namespace StardewCompanion.Mods.TasksCompanion.Models.Common;

internal abstract class TaskBase
{
    public string Name { get; set; } = string.Empty;
    public TaskCategory Category { get; set; } = TaskCategory.None;
    public TaskOptions Options { get; set; } = new();
    public bool Done { get; set; } = false;
}
