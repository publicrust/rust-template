# RaidBlock Plugin

RaidBlock is a comprehensive plugin that creates dynamic raid zones and manages player restrictions during raids.
This plugin automatically detects raid activity, creates visual domes, and prevents specific actions within raid zones, featuring seamless integration with CombatBlock.

## List of features:

### Main functions:
- Automatic raid zone detection and creation
- Visual dome display for raid areas
- Command blocking during raids
- Building restriction in raid zones
- Real-time UI with countdown timer
- Smart positioning with CombatBlock
- Automatic cleanup of expired zones

### Visual Features:
- Customizable raid zone dome
- Multiple sphere types available
- Adjustable transparency levels
- Dynamic size scaling
- Real-time zone visualization

### Raid Detection:
- Explosion damage monitoring
- Structure damage tracking
- Player combat tracking
- Smart zone creation
- Automatic zone extension on continued raiding

### Zone Restrictions:
- Teleportation blocking
- Building prevention
- Command usage restriction
- Customizable blocked actions
- Automatic restriction removal

### UI System:
- Modern design
- Real-time countdown
- Progress bar indication
- Smart positioning with CombatBlock
- Smooth animations
- Multi-language support

### Integration:
- Full CombatBlock support
- Automatic UI coordination
- Shared restriction management
- Event synchronization

### Technical Features:
- Optimized performance
- Minimal server impact
- Advanced error handling
- Debug logging system
- Safe zone management
- Memory efficient

### JSON configuration:
```json
{
  "Block Duration": 300.0,
  "Block On Receive Raid Damage": true,
  "Remove Block On Death": true,
  "Blocked Commands": [
    "/tpr",
    "/tpa",
    "/home"
  ],
  "Raid Zone Settings": {
    "Radius": 50.0,
    "Sphere Enabled": true,
    "Sphere Type": 0,
    "Dome Transparency": 7,
    "Visual Multiplier": 1.0
  },
  "Debug Mode": false
}
```

