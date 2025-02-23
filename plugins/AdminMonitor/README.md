AdminMonitor Plugin for Rust
Overview
AdminMonitor is a comprehensive admin activity tracking plugin for Rust servers that monitors and records administrator actions, time spent in-game, and provides detailed statistics through an intuitive UI.
Features
Real-time Monitoring
Tracks admin online/offline status
Monitors active and AFK time
Records admin commands and actions
Detects player movement and interactions
Activity Tracking
Command usage statistics
Building/destruction actions
Player interactions
Anti-hack violations
Location tracking
AFK Detection
Intelligent AFK detection system
Movement tracking
Rotation monitoring
Inventory/crafting activity checks
Customizable AFK thresholds
User Interface
Modern, responsive UI design
Real-time statistics updates
Activity graphs and charts
Filterable admin list
Detailed individual admin views
Statistics and Reports
Daily/Weekly/Monthly reports
Wipe history tracking
Command usage analytics
Activity trends
Performance metrics
Discord Integration
Login/Logout notifications
AFK status changes
Activity summaries
Detailed session statistics
Rich embed messages
Permissions
adminmonitor.admin - Access to admin features
adminmonitor.view - Permission to view statistics
adminmonitor.tracked - Allows non-admins to be tracked
adminmonitor.reports - Access to report generation
Commands
/amonitor - Shows admin list and statistics
/amonitor check <name/id> - View detailed admin statistics
/amonitor reset - Reset statistics (admin only)
amonitor.report - Generate activity reports
Data Storage
Persistent statistics storage
Individual admin data files
Wipe history records
Activity reports
Session tracking
Technical Features
Efficient data caching
Optimized UI updates
Customizable refresh rates
Configurable thresholds
Error handling and logging
Configuration
Integration
The plugin integrates with:
ImageLibrary for avatar display
Discord for notifications
Oxide/uMod framework
Rust game events
Performance
Minimal server impact
Optimized data structures
Efficient UI updates
Smart caching system
Controlled memory usage
