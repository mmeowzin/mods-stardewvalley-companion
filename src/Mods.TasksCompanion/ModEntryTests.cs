#pragma warning disable S1075 // URIs should not be hardcoded
#pragma warning disable S1481 // Unused local variables should be removedg
#pragma warning disable IDE0059 // Unnecessary assignment of a value
#pragma warning disable S125 // Sections of code should not be commented out

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using StardewCompanion.Mods.TasksCompanion.Models.Inventory;
using StardewCompanion.Mods.TasksCompanion.Models.Tasks;

namespace StardewCompanion.Mods.TasksCompanion;

// m.Monitor.Log($"Player name: {Game1.player.Name}");
// m.Monitor.Log($"Player's farm name: {Game1.getFarm().Name}");

public static class ModEntryTests
#pragma warning restore S125 // Sections of code should not be commented out
{
    public static void Test()
    {
        var file = @"D:\Downloads\data-example.json";

        var playerTasks = JsonSerializer.Deserialize<PlayerTasks>(File.ReadAllText(file));

        TestInventoryChange(new() { PlayerTasks = playerTasks });
    }

    private static void TestInventoryChange(ModEntryStub m)
    {
        var inventoryItems = new List<InventoryItemChange>()
        {
            new() { Id = "472", Name = "Parsnip", Stack = 15 }
        };

        if (!m.PlayerTasks.HasValidItems(inventoryItems))
            return;

        var playerTasks = m.PlayerTasks.FindValidTasks(inventoryItems);

        foreach (var inventoryItem in inventoryItems)
        {
            foreach (var playerTask in playerTasks)
            {
                if (playerTask.Done)
                    continue;

                foreach (var playerItem in playerTask.Items)
                {
                    if (playerItem.IsDifferent(inventoryItem.Id))
                    {
                        continue;
                    }

                    playerItem.Current = inventoryItem.Stack;

                    if (playerItem.Current >= playerItem.Target)
                        playerItem.Current = playerItem.Target;
                }

                if (playerTask.Items.TrueForAll(x => x.IsFulfilled()))
                {
                    playerTask.Done = true;
                }
            }
        }

        var serialized = JsonSerializer.Serialize(m.PlayerTasks, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    class ModEntryStub
    {
        public PlayerTasks PlayerTasks { get; set; }
    }
}