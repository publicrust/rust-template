namespace Oxide.Plugins
{
    [Info("RaidBlock", "Rust Plugin Developer", "1.0.0")]
    [Description("A plugin that blocks certain commands during raids")]
    public class RaidBlock : RustPlugin
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
