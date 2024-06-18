using StardewCompanion.Mods.ToDoCompanion.Configuration;
using StardewCompanion.Mods.ToDoCompanion.Events.GameLoop;
using StardewCompanion.Mods.ToDoCompanion.Events.Input;
using StardewCompanion.Mods.ToDoCompanion.Events.Player;
using StardewCompanion.Mods.ToDoCompanion.Models;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace StardewCompanion.Mods.ToDoCompanion;

internal sealed class ModEntry : Mod
{
    public ModConfiguration Configuration { get; private set; }
    public ToDoInstance Instance { get; private set; }

    public override void Entry(IModHelper helper)
    {
        LoadEntryConfiguration();

        ConfigureEventHandlers();

        void LoadEntryConfiguration()
        {
            Configuration = helper.ReadConfig<ModConfiguration>();
        }

        void ConfigureEventHandlers()
        {
            helper.Events.GameLoop.Saving += GameLoop_Saving;
            helper.Events.GameLoop.SaveLoaded += GameLoop_SaveLoaded;
            helper.Events.Player.InventoryChanged += Player_InventoryChanged;
            helper.Events.Input.ButtonPressed += Input_ButtonPressed;
        }
    }

    private void GameLoop_Saving(object sender, SavingEventArgs e) => SavingEvent.Handle(this);
    private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e) => Instance = SaveLoadedEvent.Handle(this);
    private void Player_InventoryChanged(object sender, InventoryChangedEventArgs e) => InventoryChangedEvent.Handle(this);
    private void Input_ButtonPressed(object sender, ButtonPressedEventArgs e) => ButtonPressedEvent.Handle(this, e);
}
