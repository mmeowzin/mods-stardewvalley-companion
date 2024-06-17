using StardewCompanions.Mods.ToDoCompanion.Menus;
using StardewCompanions.Mods.ToDoCompanion.Models;
using StardewModdingAPI;
using StardewValley;
using System.Linq;

namespace StardewCompanions.Mods.ToDoCompanion;

internal sealed class ModEntry : Mod
{
    private readonly ToDoList ToDoList = new();

    public override void Entry(IModHelper helper)
    {
        helper.Events.Input.ButtonPressed += Input_ButtonPressed;
        helper.Events.Player.InventoryChanged += Player_InventoryChanged;
    }

    private void Player_InventoryChanged(object sender, StardewModdingAPI.Events.InventoryChangedEventArgs e)
    {
        ToDoList.Items.AddRange(e.Added.Select(x => new ToDoItem
        {
            ItemId = x.ItemId,
            Name = x.Name,
            Stack = x.Stack
        }));

        ToDoItem current = default;
        foreach (var item in e.QuantityChanged)
        {
            current = ToDoList.Items.Find(x => x.ItemId == item.Item.ItemId);

            if (current != default)
            {
                current.Stack = item.NewSize;
            }
        }
    }

    private void Input_ButtonPressed(object sender, StardewModdingAPI.Events.ButtonPressedEventArgs e)
    {
        if (!Context.IsWorldReady)
            return;

        if (e.Button == SButton.P && Game1.activeClickableMenu == null)
            Game1.activeClickableMenu = new ToDoListMenu(Monitor);
    }
}
