using System.Collections.Generic;
using System.Linq;
using StardewModdingAPI.Events;
using StardewValley;

namespace StardewCompanion.Mods.TasksCompanion.Models.Inventory;

internal sealed class InventoryItemChange
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Stack { get; set; }

    internal static List<InventoryItemChange> From(IEnumerable<Item> added, IEnumerable<ItemStackSizeChange> quantityChanged)
    {
        var result = new List<InventoryItemChange>();

        result.AddRange(added.Select(x => new InventoryItemChange { Id = x.ItemId, Name = x.Name, Stack = x.Stack }));

        result.AddRange(quantityChanged.Select(x => new InventoryItemChange { Id = x.Item.ItemId, Name = x.Item.Name, Stack = x.NewSize }));

        return result;
    }
}
