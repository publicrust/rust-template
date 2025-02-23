Mineral Economy Plugin for Rust
Overview
A dynamic marketplace plugin for Rust that creates an automated mineral trading system with real-time price adjustments based on market supply and demand.
Features
Dynamic Pricing System: Prices automatically adjust based on the current market balance
User-Friendly Interface: Clean and intuitive UI for buying and selling minerals
Recycler Integration: Trade minerals at any recycler in the game
Permission System: Configurable access control for different features
Multi-Language Support: Built-in localization system
Core Functionality
Trading System:
Sell minerals to the server for scrap
Buy minerals from the server using scrap
Dynamic pricing based on current market supply
Price Ranges:
Sell prices: 10-50 scrap per mineral
Buy prices: 20-100 scrap per mineral
Prices adjust automatically based on market volume
Market Balance:
Tracks total minerals sold and bought
Adjusts prices based on current market balance
Prevents market manipulation
Technical Features
Proximity Check: Players must be near a recycler to trade
Safe Trading: Automatic inventory management
Error Handling: Robust error checking for all transactions
Data Persistence: Saves all market data between server restarts
Permissions
mineraleconomy.use - Basic access to the market
mineraleconomy.admin - Administrative commands
mineraleconomy.command - Access to market commands
mineraleconomy.button - Access to market UI button
Commands
/mineral or /minerals - Opens the trading interface
/givemineral - Admin command for mineral management
Installation
Place the plugin in your server's oxide/plugins directory
Configure permissions for your users
Customize prices in the configuration file (optional)
Restart the server or reload the plugin
Configuration
Fully configurable through JSON:
Customizable price ranges
Adjustable UI settings
Flexible menu positioning
Custom price tiers based on market volume
