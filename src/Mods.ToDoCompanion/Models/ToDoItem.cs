using StardewValley;
using System;

namespace StardewCompanions.Mods.ToDoCompanion.Models;

internal sealed class ToDoItem
{
    public string ItemId { get; set; }
    public string Name { get; set; }
    public int Stack { get; set; }
    public bool Completed { get; set; }

    internal static object From(Item x)
    {
        throw new NotImplementedException();
    }
}
