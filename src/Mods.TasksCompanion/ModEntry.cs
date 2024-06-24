using StardewCompanion.Mods.TasksCompanion.Configuration;
using StardewCompanion.Mods.TasksCompanion.Events.GameLoop;
using StardewCompanion.Mods.TasksCompanion.Events.Input;
using StardewCompanion.Mods.TasksCompanion.Events.Player;
using StardewCompanion.Mods.TasksCompanion.Models.Configuration;
using StardewCompanion.Mods.TasksCompanion.Models.Tasks;
using StardewModdingAPI;
using StardewModdingAPI.Events;

namespace StardewCompanion.Mods.TasksCompanion;

internal sealed class ModEntry : Mod
{
    public ModConfiguration Configuration { get; private set; }
    public PlayerTasks PlayerTasks { get; set; }

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
    private void GameLoop_SaveLoaded(object sender, SaveLoadedEventArgs e) => SaveLoadedEvent.Handle(this);
    private void Player_InventoryChanged(object sender, InventoryChangedEventArgs e) => InventoryChangedEvent.Handle(this, e);
    private void Input_ButtonPressed(object sender, ButtonPressedEventArgs e) => ButtonPressedEvent.Handle(this, e);

    public void Trace(string message, object data = null)
    {
        if (!Configuration.Trace)
            return;

        Monitor.Log(
            data == null ? message : new LogMessage(message, data).ToString(),
            LogLevel.Trace);
    }
    public void SaveTasks()
    {
        var data = PlayerTasks.Sanitize();

        Helper.Data.WriteSaveData(ModKeys.DATA_IDENTIFIER, data);

        Trace("Current player tasks saved.", data);
    }
}
