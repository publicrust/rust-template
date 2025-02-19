namespace Oxide.Plugins
{
    [Info("HelloWorld", "PublicRust", "1.0.0")]
    [Description("Simple Hello World plugin for Rust")]
    public class HelloWorld : RustPlugin
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
