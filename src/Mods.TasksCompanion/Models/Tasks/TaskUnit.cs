using System.Collections.Generic;
using StardewCompanion.Mods.TasksCompanion.Models.Common;

namespace StardewCompanion.Mods.TasksCompanion.Models.Tasks;

internal sealed class TaskUnit : TaskBase
{
    public List<SubtaskUnit> Subtasks { get; set; } = null;
    public List<TaskGameItem> Items { get; set; } = null;
}
