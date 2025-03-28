# Rust Plugin Template (uMod/Oxide)

This template is designed for rapid creation of new Rust (uMod/Oxide) plugins with a unified structure and standard configuration.

## Template Installation

The template is installed through standard .NET CLI tools, which work the same way on both Windows and Linux.

Open a command prompt/terminal in the root directory of the project and run:

```
dotnet new install ./RustPluginTemplate/template/
```

If the template is already installed and you want to reinstall it, use the `--force` option:

```
dotnet new install ./RustPluginTemplate/template/ --force
```

## Using the Template

After installation, you can create a new plugin using the following command:

```
dotnet new rustplugin -n PluginName --PluginAuthor "Your Name" --PluginDescription "Plugin description"
```

Where:
- `-n PluginName` - the name of your plugin (will also be used as the directory name)
- `--PluginAuthor "Your Name"` - the name of the plugin author
- `--PluginDescription "Plugin description"` - the plugin description

If you want to specify a different output directory, you can additionally use the `-o` parameter:

```
dotnet new rustplugin -n PluginName -o OutputDirectory --PluginAuthor "Your Name" --PluginDescription "Plugin description"
```

## Adding a New Plugin to a Solution

If you are working with a solution containing multiple plugins, add the created project to the solution:

```
dotnet sln solution-name.sln add PluginName/PluginName.csproj
```

## Structure of the Created Plugin

The created plugin will contain the following files:
- `PluginName.csproj` - C# project file
- `PluginName.cs` - main plugin file with basic structure
- `README.md` - plugin documentation

## Compiling the Plugin

To compile the plugin, run in its directory:

```
dotnet build
```

The compiled file will be located in the `bin/Debug/net48/` directory.

## Removing the Template (if needed)

If you need to remove the template:

```
dotnet new uninstall RustPlugin.Template
``` 