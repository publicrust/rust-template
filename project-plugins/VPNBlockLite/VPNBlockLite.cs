namespace Oxide.Plugins
{
    [Info("VPNBlockLite", "Rust Plugin Developer", "1.0.0")]
    [Description("A simplified version of the VPNBlock plugin")]
    public class VPNBlockLite : RustPlugin
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
