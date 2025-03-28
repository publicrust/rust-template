namespace Oxide.Plugins
{
    [Info("MineralEconomy", "Rust Plugin Developer", "1.0.0")]
    [Description("A dynamic marketplace plugin for Rust that creates an automated mineral trading system")]
    public class MineralEconomy : RustPlugin
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
