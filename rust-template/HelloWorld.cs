using Oxide.Core.Plugins;
using Oxide.Core.Libraries.Covalence;
using System;

namespace Oxide.Plugins
{
    [Info("HelloWorld", "PublicRust", "1.0.0")]
    [Description("Simple Hello World plugin for Rust")]

    public class HelloWorld : CovalencePlugin
    {
        private void Init()
        {
            Puts("Hello, Rust World! Plugin successfully loaded.");
        }

        [ChatCommand("hello")]
        private void HelloCommand(IPlayer player, string command, string[] args)
        {
            player.Reply("Hello, " + player.Name + "! Welcome to this Rust server.");
        }
    }
}
