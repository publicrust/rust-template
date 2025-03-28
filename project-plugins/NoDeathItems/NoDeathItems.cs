namespace Oxide.Plugins
{
    [Info("NoDeathItems", "Rust Plugin Developer", "1.0.0")]
    [Description("A plugin that prevents item loss on death")]
    public class NoDeathItems : RustPlugin
    {
        private void Init()
        {
            Puts("Hello, Rust World! Plugin successfully loaded.");
        }

        [ChatCommand("hello")]
        private void HelloCommand(BasePlayer player, string command, string[] args)
        {
            player.ChatMessage("Hello, " + player.displayName + "! Welcome to this Rust server.");
        }
    }
}
