using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using System;

namespace StardewCompanion.Mods.ToDoCompanion.Menus;

internal sealed class MainMenu : IClickableMenu, IDisposable
{
    private readonly IMonitor _monitor;

    private const int MINIMUM_WIDTH = 800;
    private const int MINIMUM_HEIGHT = 400;

    public MainMenu(
        IMonitor monitor)
        : base(
            (Game1.viewport.Width - MINIMUM_WIDTH) / 2,
            (Game1.viewport.Height - MINIMUM_HEIGHT) / 2,
            MINIMUM_WIDTH,
            MINIMUM_HEIGHT,
            true)
    {
        _monitor = monitor;

        _monitor.Log("menu is open 2");
    }

    public override void draw(SpriteBatch b)
    {
        base.draw(b);

        _monitor.Log("drawing");
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
        base.receiveLeftClick(x, y, playSound);

        _monitor.Log("receiving left click");
    }

    public void Dispose()
    {
        _monitor.Log("menu has been disposed");
    }

}