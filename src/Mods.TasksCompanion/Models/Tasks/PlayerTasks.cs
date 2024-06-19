using System.Collections.Generic;
using System.Linq;
using StardewCompanion.Mods.TasksCompanion.Models.Enums;
using StardewCompanion.Mods.TasksCompanion.Models.Inventory;

namespace StardewCompanion.Mods.TasksCompanion.Models.Tasks;

internal sealed class PlayerTasks
{
    public HashSet<string> SearchIndex { get; set; } = new();
    public List<TaskUnit> Tasks { get; set; } = new();

    public PlayerTasks Sanitize()
    {
        var ids = Tasks
            .Where(x => x.Done && x.Items != null && x.Items.Any())
            .SelectMany(x => x.Items)
            .Select(x => x.Id);

        SearchIndex.RemoveWhere(ids.Contains);

        _ = Tasks.SelectMany(x => x.Subtasks).ToList().RemoveAll(x => x.Done);

        _ = Tasks.RemoveAll(x => x.Done);

        return this;
    }

    public List<TaskUnit> FindValidTasks(List<InventoryItemChange> items)
    {
        var ids = items.Select(x => x.Id).ToList();

        return Tasks
            .Where(x =>
                x.Category == TaskCategory.ItemTracker &&
                !x.Done &&
                x.Items != null &&
                x.Items.Exists(i => ids.Contains(i.Id)))
            .ToList();
    }

    public bool HasValidItems(List<InventoryItemChange> items) =>
        SearchIndex.Any(key => items.Select(item => item.Id).Contains(key));
}
