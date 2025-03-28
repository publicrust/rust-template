namespace Oxide.Plugins
{
    [Info("HelloWorld", "Rust Plugin Developer", "1.0.0")]
    [Description("A simple demonstration plugin that shows basic Rust plugin functionality")]
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
