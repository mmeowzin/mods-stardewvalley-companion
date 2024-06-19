namespace StardewCompanion.Mods.TasksCompanion.Models.Tasks;

internal sealed class TaskGameItem
{
    public string Id { get; set; } = string.Empty;
    public int Current { get; set; } = 0;
    public int Target { get; set; } = 0;

    public bool IsDifferent(string id) => Id != id;
    public bool IsFulfilled() => Current == Target;
}
