using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace StardewCompanion.Mods.TasksCompanion.Events.Input;

internal sealed class ButtonPressedEvent
{
    private ButtonPressedEvent() { }

    internal static void Handle(ModEntry m, ButtonPressedEventArgs e)
    {
        if (!Context.IsPlayerFree ||
            e.Button != m.Configuration.Hotkey ||
            Game1.activeClickableMenu is TasksMenu)
            return;

        Game1.activeClickableMenu = new TasksMenu(m.Monitor, m.Helper);
    }
}

internal sealed class TasksMenu : IClickableMenu, IDisposable
{
    private readonly IMonitor _monitor;
    private readonly IModHelper _helper;

    public TasksMenu(
        IMonitor monitor,
        IModHelper helper,
        bool showUpperRightCloseButton = false)
        : base(
            Math2.Center(Game1.uiViewport.Width, 800),
            Math2.Center(Game1.uiViewport.Height, 600),
            Math2.Bordered(800),
            Math2.Bordered(600),
            showUpperRightCloseButton)
    {
        _monitor = monitor;
        _helper = helper;

        InitializeComponents();
    }

    public void Dispose()
    {
        _monitor.Log("menu has been disposed");
    }

    private void InitializeComponents()
    {

    }

    public override void draw(SpriteBatch b)
    {
        base.draw(b);

        b.Draw(Game1.mouseCursors, new(Game1.getOldMouseX(), Game1.getOldMouseY()), new(0, 0, 16, 16), Color.White, 0f, Vector2.Zero, 4f, SpriteEffects.None, 0f);
    }

    // public override void receiveLeftClick(int x, int y, bool playSound = true)
    // {
    //     base.receiveLeftClick(x, y, playSound);
    // }
}

internal static class Math2
{
    internal static int Center(int viewport, int value) =>
        (viewport / 2) - ((value + IClickableMenu.borderWidth * 2) / 2);

    internal static int Bordered(int value) =>
        value + IClickableMenu.borderWidth * 2;
}
