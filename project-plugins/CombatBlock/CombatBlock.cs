namespace Oxide.Plugins
{
    [Info("CombatBlock", "Rust Plugin Developer", "1.0.0")]
    [Description("A comprehensive plugin for managing combat-related restrictions")]
    public class CombatBlock : RustPlugin
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
