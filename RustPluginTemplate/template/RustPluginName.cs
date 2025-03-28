namespace Oxide.Plugins
{
    [Info("RustPluginName", "PluginAuthor", "1.0.0")]
    [Description("PluginDescription")]
    public class RustPluginName : RustPlugin
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
