using System.Collections.Generic;

namespace StardewCompanion.Mods.ToDoCompanion.Models;

public sealed class ToDoInstance
{
    public List<ToDoItem> Items { get; set; } = new();

    internal ToDoInstance Sanitize()
    {
        _ = Items.RemoveAll(x => x.Completed);

        return this;
    }
}
