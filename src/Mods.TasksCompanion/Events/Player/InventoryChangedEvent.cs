using System.Linq;
using StardewCompanion.Mods.TasksCompanion.Models.Inventory;
using StardewModdingAPI.Events;

namespace StardewCompanion.Mods.TasksCompanion.Events.Player;

internal sealed class InventoryChangedEvent
{
    private InventoryChangedEvent() { }

    internal static void Handle(ModEntry m, InventoryChangedEventArgs e)
    {
        var inventoryItems = InventoryItemChange.From(e.Added, e.QuantityChanged);

        if (!m.PlayerTasks.HasValidItems(inventoryItems))
        {
            m.Trace($"No valid items were found.");

            return;
        }

        var tasks = m.PlayerTasks.FindValidTasks(inventoryItems);

        if (!tasks.Any())
        {
            m.Trace($"No tasks were found for the items, removing from index.");

            m.PlayerTasks.SearchIndex.RemoveWhere(x => inventoryItems.Select(x => x.Id).Contains(x));

            return;
        }

        foreach (var inventory in inventoryItems)
        {
            foreach (var task in tasks)
            {
                if (task.Done)
                    continue;

                foreach (var item in task.Items)
                {
                    if (item.IsDifferent(inventory.Id))
                    {
                        m.Trace("Items are different. Skipping.");

                        continue;
                    }
                    m.Trace($"Item {item.Id} current quantity {item.Current}.");

                    item.Current = inventory.Stack;

                    if (item.Current >= item.Target)
                        item.Current = item.Target;

                    m.Trace($"Item {item.Id} increased to {item.Current}.");
                }

                if (task.Items.TrueForAll(x => x.IsFulfilled()))
                {
                    task.Done = true;

                    m.Trace($"Task {task.Name} marked as done.");
                }
            }
        }
    }
}
