# CombatBlock Plugin

CombatBlock is a comprehensive plugin for managing combat-related restrictions on your Rust server.
This plugin automatically blocks certain commands and actions when players are in combat, featuring a sleek UI display and integration with RaidBlock.

## List of features:

### Main functions:
- Automatic combat detection system
- Customizable command blocking during combat
- Modern UI with progress bar
- Seamless integration with RaidBlock plugin
- Multiple UI design variations
- Configurable combat duration
- Death handling options
- Support for both chat and console commands

### Additional Triggers:
- NPC attack detection
- NPC damage received
- Sleeping player damage
- Combat block deactivation on death

### Blocked Actions During Combat:
- Teleportation commands
- Trade system usage
- Kit commands
- Custom configurable commands

### UI Features:
- Multiple design variants
- Automatic positioning with RaidBlock
- Smooth animations
- Progress bar indication
- Customizable colors and transparency
- Real-time duration updates

### Integration:
- Full RaidBlock plugin support
- Automatic UI positioning when both plugins are present
- Shared combat state management

### Technical Features:
- Optimized performance
- Minimal server impact
- Configurable debug mode
- Error handling and logging
- Multi-language support
- Safe command processing

### Languages Supported:
- English (default)
- Russian

### JSON configuration:
```json
{
  "Block Duration": 10.0,
  "Block On Player Hit": true,
  "Block On Receive Damage": true,
  "Remove Block On Death": true,
  "Blocked Commands": [
    "/tpr",
    "/tpa",
    "/home"
  ],
  "UI Settings": {
    "Background Color": "0.1921569 0.1921569 0.1921569 1",
    "Icon Color": "0 0.7764706 1 1",
    "Main Text Color": "1 1 1 1",
    "Secondary Text Color": "1 1 1 0.5019608",
    "Progress Bar Color": "0.3411765 0.5490196 0.9607843 1",
    "Progress Bar Background": "1 1 1 0.1019608",
    "UI Animation Delay": "0.222"
  }
}
```