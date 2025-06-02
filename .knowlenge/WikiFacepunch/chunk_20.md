url: https://wiki.facepunch.com/rust/server-custom-emojis
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Server Custom Emojis](/rust/server-custom-emojis)

  * [ __View](/rust/server-custom-emojis)
  * [ __Edit](/rust/server-custom-emojis~edit)
  * [ __History](/rust/server-custom-emojis~history)



# Server Custom Emojis

### Since the monthly Rust update of the 3rd of August 2023, it is possible for servers to implement custom emojis that players can use in chat.__

# How do I add custom emojis to my server?__

There are a few technical requirements for what images can be used for emojis :

  * No bigger than 256*256 pixels
  * Must be `.jpg` or `.png` file format (note: `.jpg` won't support transparency)
  * Must be less than `250kb` in file size
  * 8bit and 16bit Png do not work



## Where do I put my emoji files?__

Emojis should go into a folder named `serveremoji` in your Rust server's directory alongside the `cfg` folder and all player data. Emojis can be reloaded on the fly with the `server.resetserveremoji` command. It re-scans the serveremoji folder on the server, but clients will need to reconnect to get the latest emojis.

The emoji name when used in-game will be whatever the file is called in the `serveremoji` folder. ie; poop.png will be :poop: in game. 💩

# Offensive emojis __

Servers that use emojis containing offensive / NSFW / abusive or any other bad / illegal / immoral content will be blacklisted from the Rust Server Browser by Facepunch Staff. Please ensure only safe and fun emojis are used.

Alistair — Monday Aug 7, 2023 at 8:46 AM ET

• Emoji Skin tone removal due to increased derogatory and racial content in chat

# Players disabling emojis __

For any reason, a player may want to disable all emojis or emojis provided by the server they are playing on.

The User Interface tab of the in-game Options allows you to do this :

Page views: 15,828  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zZXJ2ZXItY3VzdG9tLWVtb2ppcw%3D%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zZXJ2ZXItY3VzdG9tLWVtb2ppcw%3D%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/server-gamemodes
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Server Gamemodes](/rust/server-gamemodes)

  * [ __View](/rust/server-gamemodes)
  * [ __Edit](/rust/server-gamemodes~edit)
  * [ __History](/rust/server-gamemodes~history)



# Server Gamemodes

Starting since February 4th 2021 all servers will be able to set various gamemodes. So far there are **9** modes that server owners can set. Everything is subject to change.

# Changing gamemodes __

Gamemode can be set using convar `+server.gamemode <name>`. Put it in your server startup config and changes will be applied on launch. There is also an other command that can be used at runtime, `gamemode.set <name>`. Check information below for the full list of currently available modes.

DO NOT switch between gamemodes mid-wipe. This will reset all players and their inventory with no possibility to revert this.

# Gamemodes List __

Do not use "vanilla" gamemode, it will cause a few issues. If you want to run a default gamemode, just leave `server.gamemode` variable empty.

Gamemode Name | Description  
---|---  
vanilla | Default Rust gameplay  
survival | Same as Vanilla, just a different label NOTE: You must set an empty string `""` for this to show  
softcore | Vanilla gameplay but with some changes to make the game easier. See below for details  
hardcore | Vanilla gameplay but with lots of features disabled or limited, providing a harder experience  
weapontest | For test purposes. Made for testing weapon changes  
primitive | Restricted items game mode focusing on primitive era  
deathmatch | Placeholder: not working currently.  
teamdm | Placeholder: not working currently.  
onedeath | Placeholder: not working currently.  
koth_solo | Placeholder: not working currently.  
koth_team | Placeholder: not working currently.  
  
# Hardcore __

Facepunch has shut down all of their official Hardcore servers in November 2023. This mode will probably not receive any further updates in foreseeable future. Last Hardcore mode update was released in September 2022.

Hardcore mode provides a "raw" experience of Rust, and in some way might remind you of earlier days. Many features were either removed or limited - for example, you are no longer able to see the map, or use Rust+. Max amount of sleeping bags is now limited, and there is no global chat - that's not all, though. Here's the full list of changes:

  * Tech Tree is more expensive: +50% cost to Tier 1 tree, 2x cost to Tier 2, and 4x cost to Tier 3
  * Team system is disabled
  * Disabled the map for both G key and on death screen. No way to see your last death location either
  * Removed safe zones
  * Removed peacekeeper NPCs and sentries from "safe zone" monuments
  * Global chat is now disabled
  * Added local chat instead. Displays messages from players that are near you in radius of 100 meters
  * Compass is now disabled
  * Contacts are now disabled. Game does not remember players you've seen, and you can't mark any of them as friendlies or enemies
  * Rust+ and it's features are now disabled
  * Disabled crawling when wounded
  * Map seed is no longer sent to Steam servers and won't show up in `F1` menu
  * Hardcore servers will wipe both map and blueprints each month
  * Max amount of sleeping bags for each player is now limited to 5



Also following commands were **disabled** to avoid players finding workarounds for removed/limited features:

  * `printpos`, `printrot`, `printhead`, `printeyes`, `printinput`
  * `monuments`, `rendermap`, `renderlabs`, `rendertunnels`
  * `debug.PrintDebugWorldInfo`, `debug.CopyDebugWorldInfo`, `debug.showWorldInfoInPerformanceReadout`



# Softcore __

Softcore is a "lightweight" version of vanilla Rust gameplay:

  * Max team size is **4** players
  * Auth limited to team size (**4**)
  * Players can respawn at Compound/Bandit Camp. (not available if they are marked as hostile)
  * Not all loot is lost on death: 50% of inventory and 50% of hotbar items can be reclaimed at safe zone. Armor isn't saved. Players have only 2 hours to retrieve it, after that it'll disappear.



# Softcore Settings __

Softcore comes with three convars that allows you to edit amount of random items players can reclaim at safezone terminals. **0** means 0%, **0.5** means 50%, **1** means 100%.

Convar | Description | Default Value  
---|---|---  
gamemodesoftcore.reclaim_fraction_belt | % of items that will be saved from hotbar | 0.5  
gamemodesoftcore.reclaim_fraction_main | % of items that will be saved from inventory | 0.5  
gamemodesoftcore.reclaim_fraction_wear | % of armor that will be saved | 0  
  
You can also change the maximum team and auth size using convar `relationshipmanager.maxteamsize <value>`.

# Primitive __

Primitive is the latest game mode and a spin off from the Eras game setting (WIP)

Page views: 73,267  
Updated: This Year 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zZXJ2ZXItZ2FtZW1vZGVz)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zZXJ2ZXItZ2FtZW1vZGVz)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/server-wipe-timer
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Server Wipe Timer](/rust/server-wipe-timer)

  * [ __View](/rust/server-wipe-timer)
  * [ __Edit](/rust/server-wipe-timer~edit)
  * [ __History](/rust/server-wipe-timer~history)



# Server Wipe Timer

On the lowest level of **Nuclear Missile Silo** monument, you might notice a nuclear warhead connected to a small laptop with timer on it. This is not a random countdown timer - in fact, this timer, labeled "REPOPULATION UNIT SURVIVAL TEST", is counting down until the next server wipe. This will also decide when server should start running **endgame** events, so it's important to keep this timer accurate with your server's wipe schedule.

# Endgame Events __

On the last day of (24 hours before) every wipe cycle, the server will start two endgame events. (Within a hour, and this can be changed with the `eventschedulewipeoffset.event_hours_before_wipe` variable. Set 0 to disable it.)

## F-15E Strike Eagle Inbound __

F-15E "Strike Eagle" jets will start observing the island. You will hear an aggressive sound of a jet flying by. This event has no direct impact on game play. Since this is a event, you can start it whenever you want using the `spawn f15e` command.

## Road Bradleys __

Scientists on island will be increased, and Bradley APCs will start roaming on random roads, attacking anything they spot. The amount of APCs is dictated by size of your map: WorldSize / 1000 * 2. You can manually spawn a road Bradley by looking at a road and using the `spawnroadbradley` command. It stays on the same road traversing back and forth.

# How does the timer work?__

The default configuration aligns with force wipes so it shouldn't need any changing for most people. Make sure the time is set correctly on your servers!

The timer is calculated using your server wipe tag (`monthly`/`biweekly`/`weekly`), `wipetimer.wipeTimezone`, `wipetimer.wipeDayofWeek` and `wipetimer.wipeHourofDay` convars, however you can override these with either `wipetimer.wipeUnixTimestampOverride` or `wipetimer.wipecronoverride` convars.

This means that you have three schedule "formats" – **monthly** , **bi-weekly** and **weekly** , and by default:

  * Monthly: First Thursday every month at 19:00 (London time)
  * Weekly: Every Thursday at 19:00 (London time)
  * Biweekly: First and third Thursday of each month at 19:00 (London time), but splits 3 week gaps into 2+1 weeks for months with 5 weeks



If you change settings to Wednesday at 1 PM, and your server is weekly, then timer will reach `00:00:00:00` every week, exactly on Wednesday, 1pm (London time). If your server is running shorter wipe cycles (for example, 3-day cycle) you will need to use either the wipeUnixTimestampOverride or wipeCronOverride convars.

# Changing the day of week - wipeDayofWeek <0-6>__

Value | Day of week | Notes  
---|---|---  
**0** | Sunday |   
**1** | Monday |   
**2** | Tuesday |   
**3** | Wednesday |   
**4** | Thursday | (default)  
**5** | Friday |   
**6** | Saturday |   
  
# Changing the wipe hour - wipeHourofDay <0-23>__

Default: _19_ \- You can change this to specify the hour your server wipes. Time is specified in 24-hour format. If you type `wipeHourofDay 14.5`, then it'll be interpreted as _2:30 PM_.

# Changing the timezone - wipeTimezone __

Default: _GMT (ID=Europe/London, IANA=Europe/London)_ \- You can change this to specify your server's timezone, see [Supported Time Zones](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones)

# Specifying an exact wipe date __

## Cronos __

Internally it is now using cron expressions using the Cronos library. If you'd like, you can use a custom cron expression for your wipe timer by setting the wipeCronOverride convar. [Cronos Parser](https://github.com/HangfireIO/Cronos/)

## UnixTimeStampOverride __

You can set an exact wipe date and time using a UNIX timestamp with this server convar: `wipeUnixTimestampOverride <timestamp>`. Keep in mind that this convar will override all other settings for the wipe timer. [Epoch Converter](https://www.unixtimestamp.com/)

Server will ignore the override if specified timestamp is in the past already. If that's the case, it will revert to using your wipe schedule convars.

# Examples __

Here are a few examples to see how it works:

Wipe Frequency tag | Config | Explanation  
---|---|---  
Monthly | `+wipeDayofWeek 4 +wipeHourofDay 14.5` | Server will wipe on every first Thursday of the month at 2:30 PM.  
Monthly | `+wipeDayofWeek 1 +wipeHourofDay 9` | Server will wipe on every first Monday of the month at 9 AM.  
Weekly | `+wipeDayofWeek 4 +wipeHourofDay 18` | Server will wipe every Thursday at 6 PM.  
Biweekly | `+wipeDayofWeek 0 +wipeHourofDay 23` | Server will wipe every other Sunday at 11 PM.  
Biweekly | `+wipeDayofWeek 4 +wipeHourofDay 19` | Server will wipe every other Thursday at 7 PM.  
| `+wipeUnixTimestampOverride 1683622506` | Server will wipe exactly on May 9th, 2023 at 08:55:06 (GMT+0)  
| `+wipeUnixTimestampOverride 1686766934` | Server will wipe exactly on June 14th, 2023 at 18:22:14 (GMT+0)  
| `+wipeCronOverride "0 14 1-7,15-21 * 4"` | Server will wipe first, and third Thursday 2PM  
  
# PrintWipe __

To check if you have set up the timer correctly, you can use the `PrintWipe` command.

## Example Output __

__Frequency: Monthly Timezone: GMT (ID=Europe/London, IANA=Europe/London) Wipe day of week: Thursday Wipe hour: 19 Test time: 2023-06-01T20:56:53.2858450+00:00 Wipe time: 2023-07-06T19:00:00.0000000+01:00 Time until wipe: 34:21:03:06.714155 Ticks until wipe: 30133867141550 Cron: 0 19 * * 4#1 Next 10 occurrences: 0. 2023-07-06T19:00:00.0000000+01:00 1. 2023-08-03T19:00:00.0000000+01:00 2. 2023-09-07T19:00:00.0000000+01:00 3. 2023-10-05T19:00:00.0000000+01:00 4. 2023-11-02T19:00:00.0000000+00:00 5. 2023-12-07T19:00:00.0000000+00:00 6. 2024-01-04T19:00:00.0000000+00:00 7. 2024-02-01T19:00:00.0000000+00:00 8. 2024-03-07T19:00:00.0000000+00:00 9. 2024-04-04T19:00:00.0000000+01:00

## Explained __

This shows how your timer is currently setup.

  * Frequency is the Wipe Schedule setup in your [server-browser-tags](https://wiki.facepunch.com/rust/server-browser-tags)
  * Test Time (current time + `daysToAddTest` \+ `hoursToAddTest` convars. By default both convars are 0, so if you didn't change them, this line will display your current local time.
  * Wipe time (this will output an exact date of calculated wipe time)
  * Time until wipe: _days:hours:minutes:seconds_.
  * Ticks until wipe: returns remaining [ticks](https://learn.microsoft.com/en-us/dotnet/api/system.timespan.ticks?view=net-7.0) until the wipe. Tick is the smallest unit of time that is equal to 100 nanoseconds.
  * Cron: The cron expression your server is using, and the next 10 dates that match it



# Misc Convars __

These convars do not seem to be relevant if you are not a developer. Might be removed/changed in the future. So far, they were used only for PrintWipe output info; _Test time_

## daysToAddTest <value>__

By default set to `0`.

## hoursToAddTest <value>__

By default set to `0`.

# Code __

Wipe timer code is available in **WipeTimer.cs**. You can access it through Rust Dedicated Server's `Assembly-CSharp.dll`.

If you don't know your server's time and timezone, you can add this to one of your oxide plugins. Look for one with `OnServerInitialized()` and add the two lines at the top. When you reload the plugin it will print the information in console and be in your oxide logfile too.

__TimeZone curTimeZone = TimeZone.CurrentTimeZone; Puts($"time now: {DateTime.Now.ToString("h:mm:ss tt")} - timezone: {curTimeZone.StandardName}");

Page views: 97,152  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zZXJ2ZXItd2lwZS10aW1lcg%3D%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zZXJ2ZXItd2lwZS10aW1lcg%3D%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/standever
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [standever](/rust/standever)

  * [ __View](/rust/standever)
  * [ __Edit](/rust/standever~edit)
  * [ __History](/rust/standever~history)



# standever

Page views: 553  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zdGFuZGV2ZXI%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zdGFuZGV2ZXI%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/sunburn
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Sunburn](/rust/sunburn)

  * [ __View](/rust/sunburn)
  * [ __Edit](/rust/sunburn~edit)
  * [ __History](/rust/sunburn~history)



# Sunburn

Hit the beach in style with the Sunburn Pack for Rust - a collection of 15 new summer themed goodies!

Surf some waves with the new Boogie Board or float in your Above Ground Pool on your Inner Tube. Get into a water fight with your team with the Water Gun and Water Pistol, or just sit back and watch the chaos in your own Recliner. Document all of your summer shenanigans with the new Instant Camera - take some photos and then display them with pride in 3 different sized Photo Frames.

Add some tropical fun to your respawn experience with the Beach Towel and equip some Sunglasses to instantly be the coolest person in Bandit Town. Replace your default underwear with some new swimwear (no crafting required!). It’s summer - have some fun!

# Items Included __

  * Instant Camera
  * 3x Photo Frames
  * 4x Swimwear themed underwear skins (Male and Female)
  * Water Gun (+4 skins)
  * Water Pistol
  * Boogie Board (+6 skins)
  * Inner Tube (+7 skins)
  * Above Ground Pool
  * Paddling Pool (+4 skins)
  * Beach Recliner (+8 skins)
  * Beach Parasol (+8 skins)
  * Beach Table
  * Beach Towel (+7 skins)
  * Sunglasses (+8 skins)



Page views: 9,009  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zdW5idXJu)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9zdW5idXJu)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Teams
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Teams](/rust/Teams)

  * [ __View](/rust/Teams)
  * [ __Edit](/rust/Teams~edit)
  * [ __History](/rust/Teams~history)



# Teams

Teams allow you to see other members of your team on the map, share markers and chat within your team in the text chat.

# Creating a Team __

At the bottom left of your inventory screen is a button saying "create team". If you click it - a team is created!

# Adding people to your Team __

Stand near someone and the prompt "invite to team" will appear. Press e and they will be able to click "join team" in their inventory.

# Team Talk __

Team chat is in the same place as the [global text chat](/rust/global_text_chat). Press tab to switch between global and team chat.

Page views: 37,203  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9UZWFtcw%3D%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9UZWFtcw%3D%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Terrain
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Terrain](/rust/Terrain)

  * [ __View](/rust/Terrain)
  * [ __Edit](/rust/Terrain~edit)
  * [ __History](/rust/Terrain~history)



# Terrain

Terrain is the ground you walk on, the barrier stopping you from falling into the void. It is a single piece that flows throughout the entire map and combines multiple layers to complete what the terrain looks like, as well as what effects it has on the player.

# Alpha __

The "Alpha Layer" is the transparency layer that determines if the cosmetics of the terrain layer are switched On or Off. Meaning the texture on the terrain layer is made transparent to allow for entry/exits through this layer for circumstances such as Caves and Monuments. This does not impact the physical properties of the terrain layer.

Example: Gas Station has an underground ditch inside the monument with an underground cave. Instead of modelling the terrain layer to fit around this ditch you apply the Alpha layer to just erase the terrain within the area that the intrusion covers.

If you do not apply the Alpha layer you will end up falling through the terrain into the ditch and be under the terrain.

Monuments/Prefabs handle the physical collision for the terrain layer. So adding Alpha to an area without one of these prefabs will result in a see-through hole that you can stand on and not fall through.

There is a "[Terrain Trigger](/rust/Volume_Prefabs#terraintrigger "More details on Terrain Trigger")" volume prefab that will replicate this circumstance and remove the collider for the terrain layer, allowing players to pass through. **Ensure you use terrain triggers everywhere underground or players will be killed by anti cheat.**

# Ground Splat __

Ground Splat is what you see most of the time while exploring the map. Besides of making the terrain look prettier, it is important to make some objects, food and other stuff spawn on a map properly. Most of the time ground splat affects something only when it's mixed with a certain topology. To know which ones should be used to get something spawning, visit the [Topology](/rust/Topology) page.

Some splat textures have their own details (clutter), such as tufts of grass or small rocks. This depends on topologies as well.

# Biome __

Biomes handle a variety of attributes including:

  * Character Temperature
  * Tree type/model
  * Foliage type/model
  * Ore Spawning
  * Collectable Resource Spawning
  * Collectable Food Spawning ​



Although some changes are purely cosmetic, biomes have influence on the gameplay of your map. Having your whole map "Arctic" biome will result in no food/hemp spawns on your map and no place for a valid spawn area. Keep this in mind when working with your Biome layer. You should try and include all types of Biomes in your map.

Biomes:

  * Arid
  * Temperate
  * Tundra
  * Arctic
  * Jungle



All Biomes are painted onto the same layer and therefore cannot be combined/stacked.

# Topology __

Topology is a very important part of every map. They define where trees, bushes, junk piles and other content will spawn on your map. There is a large list of all topologies, what they do and how to get some basic stuff working – it will be much easier to cover everything on its own page rather than making this article awfully long and complex, so visit this article for more details: [Topology](/rust/Topology)

Information gathered provided by the [Rust Map Making](https://discord.com/invite/HPmTWVa) community.

Page views: 15,889  
Updated: This Week 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9UZXJyYWlu)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9UZXJyYWlu)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/the_tool_cupboard
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Tool Cupboard, decay and building privilege](/rust/the_tool_cupboard)

  * [ __View](/rust/the_tool_cupboard)
  * [ __Edit](/rust/the_tool_cupboard~edit)
  * [ __History](/rust/the_tool_cupboard~history)



# Tool Cupboard, decay and building privilege

# What's a Tool Cupboard?__

A tool cupboard, commonly referred to as a 'TC', is a very important building item in Rust that will prevent your base from decaying (getting damaged over time) as well as prevent other players from building on your base and close to it.  
  
A tool cupboard is crafted for 1000 wood and every base needs one.  
You want to keep it secure as raiders will be looking for it. Put a lock on your TC to keep it extra safe!

# Authorization __

When you place down your TC you will automatically become authorized to it. This means that you are able to build within its radius, pickup deployables within its radius and be authorized to traps that require TC privilege - flame and shotgun traps.   
  
Your teammates (or anyone else) will not be authorized to the tool cupboard until they approach it and press E to authorize:

Anyone authorized to the tool cupboard can also deauthorize themselves by holding E and choosing to deauthorize:

Anyone that has access to your tool cupboard can hold E and choose to clear all people that are currently authorized to it:

You will know if you are authorized to the tool cupboard as within its radius it will display "BUILDING PRIVILEGE" in the bottom right above your health bar.

# How big is my Tool Cupboard's radius?__

The foundations of the building that your tool cupboard is connected to will project the TC's radius and your building privilege.  
  
Here is the rough visualization of the TC radius of a square 2x2 base:

And for a different base design:

**Note how the radius is projected by the foundations and not from the point of the tool cupboard!**  
**The radii shown may not be to scale but it is important to note the shape that the privilege makes around the foundations**

  
You can work out where your building privilege lies by running around your base and noting where the green "building privilege" indicator in the bottom right appears and disappears:

# Why can people still build on my base when I have a tool cupboard?__

Other players that are not authorized on your base can still place twig floors (using a building plan) and wooden ladders onto your base. When players do not have authorization, the building outline will display orange and it will display "BUILDING BLOCKED" in red in the bottom right as shown here:

If another player tries to place anything besides a floor or a ladder then the building outline will display red and they will be notified privately in chat:

  


* * *

# Decay and upkeep __

Your tool cupboard is also used to prevent your base from decaying by using it to 'pay for' your base with a fraction of the resources it cost to build it - this is known as 'upkeep'  
  
**Without a tool cupboard with resources inside your base will start decaying straight away**  
  


You can press E on the tool cupboard to bring up its inventory and see the cost per 24 hours of keeping it from decaying:

## What adds to my upkeep cost?__

The materials used to build the walls, foundations, ceilings, and roofs of your base will all add to the cost of its upkeep as well as the materials used for doors and window pieces. Items placed within your base, however, such as sleeping bags, will not add to the upkeep cost.  
  
This means that a base that is fully stone and has sheet metal doors will only cost stone and metal fragments to upkeep.

# How do I know how long is left before my base starts decaying?__

Your tool cupboard inventory will display how long your base is protected for:

As well as in the bottom right when you are within building privilege of your base:

# Are all buildings within my building privilege protected from decaying?__

**No!**  
  
All separate buildings require a tool cupboard to prevent them from decaying.  
Either connect the 2 buildings via foundations or give them separate tool cupboards.

# High external walls and decay __

High external walls will not decay as long as they are within the radius of a building with a tool cupboard.  
  
**High external walls will not add to the upkeep cost for the TC preventing them from decaying**

You can prevent walls decaying by creating 'external tool cupboards' which are small structures that just have a tool cupboard inside

**It is also a good idea to build external tool cupboards to prevent people from building structures just outside of your TC radius to be able to jump over your high external walls**

# What happens if I run out of upkeep and my base starts decaying?__

Bases are like onions, they have layers. When your base starts to decay the outer-most parts exposed to the environment will begin to decay first until they break until the decay reaches the core and the whole base disappears.  
  


Different building materials will decay at different rates once there is no upkeep for them due to their higher health.  
Here's how long each building material takes to fully decay and be destroyed after no upkeep is left for it in the tool cupboard and it begins to decay:

  * Twig will decay in 1 hour after there is no wood left in the TC
  * Wood will decay in 3 hours after there is no wood left in the TC
  * Stone will decay in 5 hours after there is no stone left in the TC<
  * Metal will decay in 8 hours after there are no metal fragments left in the TC
  * Armoured will decay in 12 hours after there is no high quality metal left in the TC



## What if I only run out of 1 material that makes up my upkeep?__

If your base is made out of metal and stone and then your upkeep runs out of stone, then only the stone parts of your base will lose health and decay.

# Grief protection __

If your tool cupboard is broken whilst there are still resources inside of it, then it will eat up to 24 hours worth of upkeep on being destroyed to prevent the base from decaying until 24 hours later from this point.   
This is designed to help you not lose your base when it gets raided (provided that the raiders don't take it over with their own doors!)   
  
**Your tool cupboard is more likely to be broken and consume upkeep if it is locked!**

Note how the tool cupboard has fewer resources after being broken due to 24 hours of upkeep being consumed.

**Your tool cupboard consuming upkeep is also another good way to prevent raiders from getting all your loot!**

Page views: 108,192  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC90aGVfdG9vbF9jdXBib2FyZA%3D%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC90aGVfdG9vbF9jdXBib2FyZA%3D%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Topology
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Topology](/rust/Topology)

  * [ __View](/rust/Topology)
  * [ __Edit](/rust/Topology~edit)
  * [ __History](/rust/Topology~history)



# Topology

# What is Topology?__

Topology is the group of layers that make up the characteristics of the ground we walk on in-game.

This includes things such as:

  * If water is fresh or salty.
  * Where nodes can spawn.
  * Where animals can roam.



# Topology List __

Topology | Description  
---|---  
Field | Spawns resource pickups, bushes, and some trees  
Cliff | Blocks everything from spawning  
Summit | Reduces Tree Spawns (Unconfirmed)  
Beachside | Spawns some bushes  
*Beach | Spawns driftwood and boats  
Forest | Spawns Trees, Mushrooms, Berries, Logs,  
Forestside | Spawns small trees and bushes  
Ocean | Defines the ocean area, spawns sea grass  
*Oceanside | Spawns driftwood (Unconfirmed)  
Decor | Spawns harvestable ores and decorative rocks (Unconfirmed)  
Monument | Spawns barrels and food crates  
Road | Prevents any player buildings and blocks everything from spawning  
Roadside | Spawns junk piles and bushes  
Swamp | Spawns swamp trees and sulfur pickups  
River | Makes water drinkable and adds reeds  
Riverside | Spawns Pumpkins/Corn and some decor  
Lake | Makes lake water drinkable  
Lakeside | Spawns Pumpkins/Corn and some decor  
Offshore | Spawns underwater clutter, rock formations and sunken ships with loot  
Rail | Prevents any player buildings and blocks everything from spawning  
Railside | Spawns dense bushes  
Building | Blocks everything from spawning  
Cliffside | Spawns ore nodes and blocks junkpiles from spawning  
Mountain | Prevents animals, ores and decor from spawning in this area, adds loot barrels (Unconfirmed)  
Clutter | Spawns harvestable ores and decorative rocks (Unconfirmed)  
Alt | Spawns Birch/American Beech trees  
*Tier 0 | Defines the tier 0 area on a map  
Tier 1 | Defines the tier 1 area on a map, vanilla monuments will spawn better crates  
Tier 2 | Defines the tier 1 area on a map, vanilla monuments will spawn even better crates  
*Mainland | Defines where animals can roam and where airdrops can land  
Hilltop | Unknown/No Use  
  
*Required to make a player spawn point

# Notes & Tips:__

  * Field Topology defines scrap heli spawns when using the scraptransporthelicopter.population convar

  * Road Topology defines minicopter spawns when using the minicopter.population convar

  * Remove mainland from lakes to prevent animals from walking through!

  * Use Building topology to prevent grass/decor from spawning on underground entrances!

  * Forest topology requires Forest splat in Temperate, Arid, and Tundra biomes, and requires Snow splat in the Arctic biome




# Topology Summary (WIP?)__

## Unconfirmed __

# Making a valid spawn area __

A spawn area is a random location on the map where a "new" character will "spawn" into the game. To make it working you'll need to make an area that has following topologies: **Tier0, Oceanside, Beach, and Mainland**.

• If the map doesn't have any valid spawn areas then players will spawn at (0,0,0), and probably kicked for InsideTerrain Violation.

# Adding road junkpiles to your map __

Road junkpiles appear only on a "Roadside" topology. To make a valid spawn area for junkpiles you'll need to paint this topology on any part of the map. It can be done near your roads or somewhere far away from everything – choosing the area is up to you.

Do not make the painted topology too thin – without enough space junkpiles won't spawn there. Keeping the same width as on procedural maps will be enough to get everything working as intended.

Topology Information provided by: [Rust Map Making](https://discord.com/invite/HPmTWVa)

Page views: 35,181  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9Ub3BvbG9neQ%3D%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9Ub3BvbG9neQ%3D%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Transparent_Pngs
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Creating Transparent PNGs](/rust/Transparent_Pngs)

  * [ __View](/rust/Transparent_Pngs)
  * [ __Edit](/rust/Transparent_Pngs~edit)
  * [ __History](/rust/Transparent_Pngs~history)



# Creating Transparent PNGs

If you're using photoshop you might run into issues when exporting transparent PNGs.

## Problem __

When saving a PNG with full transparency, photoshop changes the pixels behind the transparency to white. This can be an issue with textures because of things like mipmaps and bilinear filtering cause those white pixels to bleed, leading to ugly white lines down the side of your textures.

## Solution __

There's a PNG plugin called [SuperPNG](http://www.fnordware.com/superpng/). This will save your PNGs without messing with them.

When opening a PNG in photoshop hold down shift to see the SuperPNG an import menu

Page views: 22,195  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9UcmFuc3BhcmVudF9Qbmdz)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9UcmFuc3BhcmVudF9Qbmdz)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/tutorial_island
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Tutorial Island](/rust/tutorial_island)

  * [ __View](/rust/tutorial_island)
  * [ __Edit](/rust/tutorial_island~edit)
  * [ __History](/rust/tutorial_island~history)



# Tutorial Island

# What is Tutorial Island?__

New players will be prompted to start the tutorial when they connect to a compatible server, veteran players (>50 deaths) won't be asked and will need to manually start the tutorial via the Options menu. Once the player starts the Tutorial, they will be respawned on a dedicated island where an NPC will guide them through the first half hour of gameplay. This island is tightly controlled and cannot be reached by other players. Throughout this process players will learn some key concepts:

  * Basic movement
  * Crafting
  * Building bases
  * Upgrading bases
  * Respawning
  * Basic combat
  * Resources
  * Looting containers
  * Cooking
  * Using Furnaces
  * Workbenches
  * Using a vehicle



This obviously isn’t an exhaustive list of everything there is to learn in Rust, but we feel like this is a good starting point for a new player. Our guiding principle when designing this sequence has been - if a player emulates exactly what they did on the Tutorial Island once they get into the main game, will they have a fighting chance?

# Enabling / Disabling Tutorial Island on your server __

For server owners running mods that change core gameplay features, you may find that parts of the tutorial don’t work or maybe showing the tutorial isn’t appropriate for your server (minigame servers for instance). You can control whether the tutorial is active via the `server.tutorialEnabled` convar - it's false by default. While false players won't be prompted to start the tutorial on your server and they will not be able to manually start the tutorial. We’ve added a server tag to help players find and filter servers by their tutorial compatibility, add “tut” to your server tags to advertise your tutorial compatibility. Brand new players will have this filter on when they first use the server browser.

## Convars __

  * `server.tutorialEnabled true` \- Will enable Tutorial Island
  * `server.tutorialEnabled false` \- Will dsiableTutorial Island



# Links __

[Facepunch Blog Post](https://rust.facepunch.com/news/lighting-the-way#TutorialIsland)

Page views: 2,576  
Updated: This Year 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC90dXRvcmlhbF9pc2xhbmQ%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC90dXRvcmlhbF9pc2xhbmQ%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/twitch-drops
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Twitch Drops](/rust/twitch-drops)

  * [ __View](/rust/twitch-drops)
  * [ __Edit](/rust/twitch-drops~edit)
  * [ __History](/rust/twitch-drops~history)



# Twitch Drops

# What are Twitch Drops?__

Twitch Drops open up a new way to receive free of charge skins by watching streams of your favorite Rust streamers on [Twitch](https://www.twitch.tv/). Skins earned on Twitch are account bound and can not be traded or sold. You will need to own [Rust on Steam](https://store.steampowered.com/app/252490/Rust/) in order to receive the items.

# What do you have to do?__

All you need to do to be eligible for Rust Twitch Drops is to log into your Twitch account, pair it with your Steam account, set your profile to Online and fulfill the Drop criterias.

To make this step as easy as possible for you, we've setup a dedicated website at [twitch.facepunch.com](https://twitch.facepunch.com/) to guide you through this process.

  1. You first want to make sure you connect your accounts. To do so click on "CONNECT ACCOUNTS".



  2. Once you've logged into your Twitch/Steam account and successfully connected them, you should be rewarded with a "SUCCESFULLY PAIRED" message.



Thats all you have to do to before you can start earning progress towards your favorite Rust skin .

# Which streams you need to watch to receive Rust Twitch Drops?__

All [Rust streams with the Drops enabled tag](https://www.twitch.tv/directory/game/Rust?tl=c2542d6d-cd10-4532-919b-3d19f30a768b) will count towards earning drops. However, streamer-specific drops will require you to watch a specific streamer in order to get their drop. All participating streamers are listed on [twitch.facepunch.com](https://twitch.facepunch.com/) and all active campaigns and their conditions can always be seen on this Twitch page.

# Is there any way to check my progress towards the next drop? What if I missed the drop?__

You can track your progress on the [Twitch Drops Inventory page](https://www.twitch.tv/drops/inventory). If you've missed the Twitch Drop Round or did not make it to the finish line in time, there is no other way to aquire said drops.

# Can I earn drops faster or more often by watching more than one channel at a time?__

No, you will only be eligible to receive a drop for one active channel at a time. Watching more than one channel simultaneously will not result in more drops.

# How long does it take for drops to show up in my Steam inventory?__

It can take up to 10 minutes after pressing the Claim button for items to show up in your Steam inventory. If the item does not show up after 30 minutes then your Steam account may not have been linked to your Twitch account when you claimed the drop. You can link your accounts on the top of this page and then click the button to check for missing drops to attempt the reward again.

If you have already linked your accounts but still do not receive any Drops, please un-link your accounts and link them again as described above.

Page views: 34,913  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC90d2l0Y2gtZHJvcHM%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC90d2l0Y2gtZHJvcHM%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/useful_commands
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Useful Console Commands](/rust/useful_commands)

  * [ __View](/rust/useful_commands)
  * [ __Edit](/rust/useful_commands~edit)
  * [ __History](/rust/useful_commands~history)



# Useful Console Commands

This page is not complete and is still a work-in-progress!  
Feel free to contribute but I must ask that you follow the styling format that has already been used :)

# Finding commands __

If you need a command but don't remember its full name, you can use `find [text]` command. It will show a full list of available commands, variables and descriptions that matches your request. You can search for any kind of collection of symbols, words and etc.

# Server commands __

Some commands are only designed to be used through the server console but can be used via a client with admin if prefixed with "sv", eg, the `say` command that broadcasts a message in chat from the server can be only be used by the client by doing `sv say`

Some commands have different functionalities if they are prefixed with "sv", eg, the `quit` command that normally closes the client can be prefixed with "sv" to save and close the server by doing `sv quit`

# Deleting assets/prefabs from the server __

You may find that some entities you cannot regularly use `ent kill` on to remove them after they've spawned.  
You can, however, use the `del` command followed by the entity's/asset's path. For instance, if you want to delete the banditcamp airwolf vendor (for some reason?) you can use `del assets/prefabs/npc/bandit/shopkeepers/bandit_conversationalist.prefab`  
  
You can also do similar if you want to remove all bears from the server `del assets/prefabs/npc/bear/bear_full.prefab`

## Finding asset/prefab paths __

If you look at the entity you want to find the path of and use the console command `debug.lookingat` you will get the path returned to you in F1 console.  
First use `console.clear`, then use `debug.lookingat` on the entity you want the path of, lastly use `console.copy` to copy the path.  
Pasting your clipboard elsewhere will make it easier to extract the path from what you copied from console

You can also take a look at [Corrosionhour's prefab list](https://www.corrosionhour.com/rust-prefab-list/)

# Most useful command list __

Command | Functionality | Parameter info | Requires admin?  
---|---|---|---  
admintime 1-24 | Sets the time of day to this hour for your player only | Input -1 to reset to the server's regular time | Yes  
ban steam64ID <username> <reason> <duration> | Bans a player from the server. Set username as a nickname you will remember this player by, reason to why you're banning them and an optional duration of when the ban will expire | Input duration using a value followed by a time indicator. Eg, 1M7d5m will keep them banned for 1 month, 7 days and 5 minutes from when you banned them | Yes  
banid Steam64ID <name> <reason> <duration> | Bans a player from the server with a reason using Steam64ID. Does not require the player to be on the server |  | Yes  
banlistex | Returns a list of banned users with reasons and names |  | Yes  
bans | Lists banned users |  | Yes  
benchmark | Runs a benchmark simulation of many parts of the game to see how well you can run the game |  |   
bradley.quickrespawn | Respawns the bradley APC in launchsite, does not create a second APC |  | Yes  
combatlog <Steam64ID> | Displays recent damage information for what the player damaged and what the player was damaged by | Optional Steam64ID for admins to see other player's combatlog | Only with another player  
connect IP:Port | Allows you to connect to a server if you have its IP address and Port | If this is a locally hosted server you can replace the IP with "localhost" |   
connecthidden IP:Port | Allows you to connect to a server if you have its IP address and Port but the connecting info is not printed to console |  |   
console.clear | Clears the f1 console |  |   
console.copy | Copies the contents of the F1 console to the clipboard |  |   
debug.lookingat | Prints information about what the player is currently looking at |  | Yes  
debug.lookingat_debug | Toggles debug stats to hover over what the player is currently looking at |  | Yes  
debugcamera | Go into free camera mode |  | Yes  
debugcamera_unfreeze | Freezes the debugcamera camera position allowing you to move your player around from a fixed viewing angle |  | Yes  
decay.scale | Takes a float value that controls the multiplier for decay on the server | default is 1 | Yes  
decay.upkeep_grief_protection | Max minutes of upkeep the tool cupboard can consume after being destroyed to keep the base from decaying for that period of time | default is 1440 (24 hours) | Yes  
decay.upkeep_period_minutes | How many minutes does the upkeep cost last. Increase this value for upkeep to cost less | default is 1440 (24 hours) | Yes  
del | Takes the asset path of an asset/prefab and deletes all that are found on the server | Asset path can be found by looking at the desired asset/prefab, using debug.lookingat and then console.copy | Yes  
drink | Increases your thirst by the inputted amount | 250 | Yes  
eat | Increases your hunger by the inputted amount | 500 | Yes  
ent kill | Destroys the entity you're looking at |  | Yes  
ent lock | Locks the entity you're looking at (codelocks, keylocks) |  | Yes  
ent unlock | Unlocks the entity you're looking at (codelocks, keylocks) |  | Yes  
ent who | Returns the Steam64ID of who placed this entity |  | Yes  
env.progesstime true/false | Dictates whether time will continue or stay at the current hour forever |  | Yes  
env.time 1-24 | Sets the time of day for the whole server |  | Yes  
fillwater | Fills all water containers with freshwater in the player's inventory |  | Yes  
find | Returns information on commands that match the inputted word |  |   
fps | Returns current Frames Per Second. Can be used on client and server |  |   
fps.limit | Used to set the limit of what FPS can become. Can set server fps limit when prefixed with "sv" |  |   
gesture gestureName | Makes your player perform a gesture | wave/victory/shrug/thumbsup/chicken/hurry/whoa |   
god true/false | Puts you in god mode so you cannot receive any type of damage from the world and you do not lose hunger or thirst |  | Yes  
gotosleep ID | Makes the player npc sleep | Input their ID (name above their head) | Yes  
hackablelockedcrate.requiredhackseconds | How many seconds should it take for locked crates (like at oilrig) to open once they've started to be hacked | default is 900 (15 minutes) | Yes  
headlerp_inertia true/false | Controls whether there is a delay for 'alt look' to snap back to the front facing position after no longer being pressed |  |   
heal | Heals the player by the amount inputted |  | Yes  
heli.call | Starts the patrol helicopter server event |  | Yes  
heli.calltome | Starts the patrol helicopter server event and summons the helicopter to the player |  | Yes  
hurt | Hurts your player by the inputted amount |  | Yes  
injure | wounds the player |  | Yes  
kick Steam64ID/playerName <reason> | Kicks the player from the server with an optional reason, they can join back straight away |  | Yes  
kill | Kills your player taking you to the respawn menu (same functionality as hitting "suicide" in the esc menu) |  |   
killplayer Steam64ID/playerName | Kills the inputted player sending them back to the respawn screen | Use steam64ID for more accurate usage | Yes  
playerhelicopter.insidedecayminutes | How many minutes does a minicopter/attack/transport heli take to decay from full health when under a roof | default is 2880 (48 hours) |   
playerhelicopter.outsidedecayminutes | How many minutes does a minicopter/attack/transport heli take to decay from full health when outdoors | default is 480 (8 hours) |   
moderatorid Steam64ID | Makes the player the second highest admin auth level (1) |  | Yes  
mute Steam64ID/playerName | Mutes the player locally if used without admin so you don't see their messages in chat. Mutes the player globally for the server if used as admin |  | Depending on local or global mute functionality  
mutelist | Returns a list of players with an index that you have locally muted |  |   
netgraph.enabled true/false | Toggles netgraph debug overlay that gives network information on entities - looks like white bars across the top of the screen. State is only updated whilst in a server |  |   
noclip | Toggle noclip flight for the player |  | Yes  
ownerid Steam64ID | Makes the player the highest admin auth level (2) |  | Yes  
perf 0/1/2/3/4/5/6 | Sets performance data to show at the bottom left of your screen | 0 - Removes stats  
1 - FPS  
2 - + Frame latency  
3 - + RAM usage  
4 - + Ping  
5 - + Invokes  
6 - + Tasks |   
ping | Returns your latency to the server |  |   
playerlist | Returns connected player information in a JSON format |  | Yes  
players | Returns players on the server with their Steam64ID, name, ping |  | Yes  
printpos <Steam64ID> | Print your current coordinate position. Can be prefixed with "sv" to be able to input a player's Steam64ID and get their position |  | Getting another player's position requires admin  
quit | Close the game to desktop. Can be prefixed with "sv" to save and close the server |  | Closing the server requires admin  
refillvitals | Fills health, hunger and thirst to full |  | Yes  
removemoderator Steam64ID | Removes the second highest admin auth level (1) from the player |  | Yes  
removeowner Steam64ID | Removes the highest admin auth level (2) from the player |  | Yes  
resetstate Steam64ID | Resets the given player's state, eg, if they are hostile to safezones |  | Yes  
server.writecfg | Writes server convars/settings to the cfg files |  | Yes  
sleep | Makes your player sleep |  | Yes  
sleepingusers | Lists all players that are asleep on the server |  | Yes  
spawn entity | Spawns an entity where the player is looking, if the entity name inputted is not found you are given choices |  | Yes  
spawnitem item | Spawns an item where the player is looking, if the item name inputted is not found you are given choices |  | Yes  
status | Returns players on the server with their Steam64ID, name, ping, time played, IP address |  | Yes  
sv say message | Broadcasts a message to chat from the server |  | Yes  
sv stats | Returns stats for the connected players alongside their Steam64ID and name. Time connected, kills, deaths, suicides |  | Yes  
teleport playerName/Steam64ID <playerName/Steam64ID> | Teleport to the given player. If 2 players are inputted then this teleports the first player to the second | Use steam64ID for more accurate usage | Yes  
teleport2marker | Teleport to the marker you've set on the map |  | Yes  
teleport2me playerName/Steam64ID | Teleport the given player to your position | Use steam64ID for more accurate usage | Yes  
teleport2owneditem playerName/Steam64ID | Teleport to an item the inputted player has placed | Use steam64ID for more accurate usage | Yes  
teleportany entity | Teleport to any entity type on the server |  | Yes  
teleportlos | Teleports to the closest thing in the player's Line Of Sight (LOS) |  | Yes  
teleportpos "x, y, z" | Teleport to this coordinate |  | Yes  
unban Steam64ID | Unbans the banned player |  | Yes  
unmute Steam64ID/index | Unmutes the player locally if used without admin, index of the muted player from the "mutelist" command can be used instead of steam64ID. Unmutes the player globally for the server if used as admin |  | Depending on local or global mute functionality  
users | Returns players on the server with Steam64ID and names |  | Yes  
version | Prints version and build info, shows server version when used for the server |  |   
wakeupall | Wakes up all sleeping NPC players |  | Yes  
weather.load | Loads a weather type, eg, weather.load clear |  | Yes  
weather.report | Prints the current weather stats for the server |  | Yes  
world.rendermap | Saves a high resolution png file of the map |  |   
writecfg | Writes settings and keybinds to the cfg files |  |   
  
You can also check out [Corrosionhour's command list](https://www.corrosionhour.com/rust-admin-commands/)

Page views: 263,372  
Updated: This Year 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC91c2VmdWxfY29tbWFuZHM%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC91c2VmdWxfY29tbWFuZHM%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Utility_Prefabs
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Utility Prefabs](/rust/Utility_Prefabs)

  * [ __View](/rust/Utility_Prefabs)
  * [ __Edit](/rust/Utility_Prefabs~edit)
  * [ __History](/rust/Utility_Prefabs~history)



# Utility Prefabs

# Custom Monument Markers __

__assets/bundled/prefabs/modding/monument_marker.prefab

This prefab can be used to apply text onto the in-game "G" map to mark custom locations/monuments.

The displayed name is taken from the PrefabData "category" string. [Source](https://commits.facepunch.com/374508)

[Map Editors](/rust/Map_Editors) can implement this feature by allowing the user to input the text into the monument_marker.prefab's category section within the [PrefabData](/rust/Map_Data#dataformat).

# Customize the Markers __

Furthermore, by modifying the name of the map marker you can achieve customized effects such as text size, color, and more! Copy and Paste and modify as needed!

## Large text __

__< size=70>My Cool Monument</size>

## Medium Text __

__< size=50>My Cool Monument</size>

## Default Size __

__< size=20>My Cool Monument</size>

You can also use other formats such as the ones below

__< i>Italicized</i>

__< b>For bold text</b>

__< color=red>For Red Text</color>

# Softcore mode respawn points __

In softcore mode players can respawn at Compound or Bandit Camp. These two respawn points are exposed to prefabs list and allows you to make custom safe zones compatible with Softcore-exclusive features. However, there are two important things to note:

  * You can't edit names for these respawn points. If you set "bandit camp" point, it'll display as "bandit camp" in-game as well. Same about Compound.
  * Players can't use these respawn points if they are marked as hostile.



## Bandit Camp respawn point:__

__assets/prefabs/gamemodes/softcore/staticrespawnzonebandit.prefab

## Compound respawn point:__

__assets/prefabs/gamemodes/softcore/staticrespawnzonecompound.prefab

# Softcore Reclaim Point __

When dying on a softcore server, players lose only 50% of their inventory. They can reclaim other half of their items at Reclaim Terminal that are located in safe zones. (Compound/Bandit Camp by default)

You can set up your own reclaim points wherever you want using this:

`Reclaimterminal` \- interactable object. Opens an UI with a large loot container with your items.

`Reclaimcontainerstatic` \- decorative item. Just a 3x3m red-tinted shipping container with a sign saying "Reclaim".

`Reclaimsign` \- decorative prop with "RECLAIM" painted on it.

# Dropzone __

Invisible point that Chinook-47 will use as a location for dropping the locked crate. This prefab does NOT affect CH47 pathing, so it should be near a monument marker and roughly 30m off the ground to ensure it is recognized by the CH47. By default, the Chinook will always prioritize circling vanilla monuments and ignores custom monument markers IF vanilla monuments are present, so unless the Chinook flies over the dropzone by chance, the locked crate will always end up at a dropzone within a vanilla monument. This can be fixed with plugins, or by not having vanilla monuments on your map.

# Spawn Point __

Allows spawning players in the exact spot if your map doesn't have any appropriate spawn area or you want to make them spawn inside of a certain building or any other structure.

If you want the game to determine spawn points naturally based on topology (Same as procedural maps) check out [Making a valid spawn area](/rust/Topology#makingavalidspawnarea "More details on Topology and spawn areas").

Spawn Points are broken and working only on first spawn – once you die, you will respawn in the corner of the map or on zero coordinates (0,0,0). This can be fixed with third-party plugins.

# Community Prefab Toolkit __

[Community Prefab Toolkit](https://lone.design/product/rust-map-maker-toolkit/) provided by Lone.Design is a useful resource for anyone diving into the world of map making to easily have a canvas of prefabs to work with and choose from without having to sift through any lists!

Information gathered provided by the [Rust Map Making](https://discord.com/invite/HPmTWVa) & [Lone.Design](https://discord.gg/VEesZs9) community.

Page views: 16,637  
Updated: This Month 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9VdGlsaXR5X1ByZWZhYnM%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9VdGlsaXR5X1ByZWZhYnM%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/vehicle.1mod.cockpit.armored
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Armored Cockpit Vehicle Module](/rust/vehicle.1mod.cockpit.armored)

  * [ __View](/rust/vehicle.1mod.cockpit.armored)
  * [ __Edit](/rust/vehicle.1mod.cockpit.armored~edit)
  * [ __History](/rust/vehicle.1mod.cockpit.armored~history)



# Armored Cockpit Vehicle Module

# Description __

Single module armored cockpit for a driver and one passenger

Page views: 3,473  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC92ZWhpY2xlLjFtb2QuY29ja3BpdC5hcm1vcmVk)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC92ZWhpY2xlLjFtb2QuY29ja3BpdC5hcm1vcmVk)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Volume_Prefabs
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Volume Prefabs](/rust/Volume_Prefabs)

  * [ __View](/rust/Volume_Prefabs)
  * [ __Edit](/rust/Volume_Prefabs~edit)
  * [ __History](/rust/Volume_Prefabs~history)



# Volume Prefabs

Volume Prefabs are a collection of various triggers that have their unique effects once players enter the prefab. Almost all volumes have a 1x1x1 cube collider. Almost all are completely invisible in-game but apply specific effects to the player when interacted with.

# Terrain Trigger __

While a player is touching this trigger, collisions with the terrain will be ignored. If you want to make an entrance into a cave or other structure that needs the player to go through the terrain, this trigger is for you. To make the terrain clear, see “Alpha” in the Terrain tab.

Some triggers have other triggers or volumes built in, Terrain Trigger being one of them.

## Terrain Trigger has this volume built into it:__

  * Environmentalvolumeunderground



Keep in mind that all player-accessible underground areas must be inside of this trigger to prevent players from instantly dying and being kicked due to antihack. The alternative solution is disabling the antihack protection for terrain using this parameter: `+antihack.terrain_protection 0` (Not recommended)

# *Terrain Trigger Noenv __

This does the exact same thing as the Terrain Trigger, just without the Environmentvolumeunderground volume. This is great for surface caves and monuments where you don’t want the screen to darken in areas under terrain.

# Water Trigger __

While a player is touching this trigger, all water on the map is temporarily removed for them, allowing them to move as if the water was never there. This is typically used to have underground areas that go under the ocean level. To ensure a seamless transition and avoid the sudden disappearance of water, it is recommended to block sightlines between players and any existing water when they enter the water trigger.

## Water Trigger has this volume built into it:__

  * Environmentalvolumeunderground



# *Water Trigger Noenv __

This does the exact same thing as the Water Trigger, just without the Environmentvolumeunderground volume.

# Water Culling Volume __

This prefab culls (hides) the area of water within it. This area still acts as water, so players can still swim through it.

This is typically used in combination with the Water Trigger to have surface monuments that go under ocean level.

## Before __

## After __

# Invisible Collider __

Simply an invisible wall. Blocks projectiles and players.

# Prevent Movment Volume __

Invisible wall that only affects players. NPCs, grenades, bullets, etc. are unaffected. Typically used to prevent players from getting in spots you don’t want them in. (Yes it is spelled Movment in the game files)

# Ladder Trigger __

This trigger is used to make anything climbable. When a player is touching it, it allows them to climb. This will be helpful when you want to create a custom climbing prop or make static ladder prefabs usable.

# Environment Volumes __

These prefabs change the visuals for a player, allowing for better immersion depending on the location of where it is used.

## EnvironmentVolumeBuilding __

Slightly darkens the player’s view, and makes shadows more prominent. Muffles/Reduces wind and bird noises.

## *EnvironmentVolumeBuildingDark __

Darkens the player’s view more, and makes shadows much more prominent. Muffles/Reduces wind and bird noises.

## *EnvironmentVolumeBuildingVeryDark __

Darkens the player’s view to nearly pitch black. Muffles/Reduces wind and bird noises.

## EnvironmentVolumeUnderground __

Fully darkens the player’s view. Removes Wind/Bird sounds. Adds cave ambience sounds.

## EnvironmentVolumeTraintunnles __

Disables the sun and skybox, making the sky pitch black. Adds a black fog that reduces view distance to around 125 meters. Probably has no use in open area, but will be a great addition for any large underground structures – this will avoid any kind of situations when sun might glitch through geometry beyond the shadow draw distance.

## EnvironmentVolumeUnderwaterLab __

(Unconfirmed, will update once fully tested)

## EnvironmentVolumeNoSunlight __

(Unconfirmed, will update once fully tested)

# Damage Triggers __

Their name are self-explanatory. Deals a certain amount of damage to player when colliding with this volume, higher volume type means more damage and lesser time to kill. Works and sounds the same as barbed wire. There are four types of hurt triggers:

  * `Damage Trigger Low`
  * `Damage Trigger Med`
  * `Damage Trigger High`
  * `Damage Trigger Death` 💀



# Bandit Swamp Fog FX __

This is a volumetric fog from the Bandit Camp monument. No description needed.

# Safezonesphere __

Safe Zone is a volume trigger a sphere collider (2 meter radius by default). Safe zone on custom maps works the same way as on outpost/bandit camp. You shoot – you die and receive a 5 minute long ban.

If you combine custom safe zones with vanilla safe zones, you will have a hostility marker visible whenever you attack or just shoot, even if there is no safe zone near you. Unfortunately the only solution is removing all default Rust safezone monuments.

# Radiation Spheres __

There are three types of radiation sources:

  * `Radiation High`
  * `Radiation Med`
  * `Radiation Low`



They have a corresponding radiation level and will do slower or faster damage on player, depending on source type. When it comes to vanilla approach for radiation levels, it's usually preferred to cover tier 3 monuments and best loot points with highest radiation level, especially if players are not meant to stay there for long, just like on top of launch site. `Med` and `Low` variants will fit the best for majority of your custom monuments.

# Comfort Volume __

A sphere shaped volume that provides you comfort when staying inside of it. Perhaps a good thing to implement at safe zones for players to heal themselves slowly.

# Heat Volume __

Currently it's purpose remains unknown. Need to be clarified.

It seems like volume does nothing in-game - needs more checks and, most likely, a fix if it's a confirmed broken prefab.

# Chair Invisible Static __

An invisible variant of a handmade chair. Doesn't decay but can be destroyed with an `ent kill` command. Avoid using it on invisible chairs because there will be no way to add it back.

# List of Prefabs with Built-in Triggers & Volumes __

Coming very soon!

Information gathered provided by the [Rust Map Making](https://discord.com/invite/HPmTWVa) community.

Page views: 16,940  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9Wb2x1bWVfUHJlZmFicw%3D%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9Wb2x1bWVfUHJlZmFicw%3D%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Weather
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Weather](/rust/Weather)

  * [ __View](/rust/Weather)
  * [ __Edit](/rust/Weather~edit)
  * [ __History](/rust/Weather~history)



# Weather

Blustery and chillier today and tomorrow with showers or longer spells of rain. Drier by midweek.

It's no secret that our old weather system was a huge mess of programmer art and performance issues, which is why it had to be removed from the game a long time ago. We were able to resolve the performance issues by doing more optimizations ourselves and relying less on Unity's particle system optimizations. We sort of rolled our own super primitive voxel collision to handle the coarse, large-scale collisions. Unity then only has to sort out the detailed collision on the last couple of meters above ground.

As for visuals, I think we did it right this time by having a system that is almost entirely artist-driven. The code then simply blends between various weather presets. This also has the advantage that everything can be adjusted by server mods, allowing for endless customization in the future.

# Admin Convars __

Here's a short explanation of the main weather convars for server owners:

`weather.load` \- loads a specific weather type

`weather.reset` resets to dynamic weather

`weather.report` prints the current dynamic weather

There are currently the following weather types that can be loaded this way:

  * Clear
  * Dust
  * Fog
  * Overcast
  * RainHeavy
  * RainMild
  * Storm



An example is `weather.load Fog`

In terms of affecting gameplay, server owners can also adjust how wet players get from rain and snow:

  * `weather.wetness_rain`
  * `weather.wetness_snow`



Setting weather commands from the client will only affect the local weather for administrators. You will to prefix these commands with "sv" in order to change the weather server-wide. For example: "sv weather.load Clear"

## Probability Parameters __

When using the default dynamic weather, server owners can adjust the probability of every weather type individually:

  * `weather.clear_chance`
  * `weather.dust_chance`
  * `weather.fog_chance`
  * `weather.overcast_chance`
  * `weather.storm_chance`
  * `weather.rain_chance`



## Detailed Convars __

If all of that still isn't enough customization for your particular server, then you can also adjust every individual parameter of the weather system. Note that negative values (-1) indicate that the value isn't overwritten and is using whatever the dynamic weather system is currently outputting. These commands must be run from server console - otherwise use `sv` for server commands replicated on client.

  * `weather.rain` \- How much it should rain
  * `weather.wind` \- How much wind there is (mostly visual, affects certain vegetation)
  * `weather.thunder` \- How much thunder / lightning there is
  * `weather.rainbow` \- Can be set to forcefully trigger a rainbow
  * `weather.fog` \- How much fog there is
  * `weather.atmosphere_rayleigh` \- Rayleigh scattering intensity (determines the color of the sky - play around with it)
  * `weather.atmosphere_mie` \- Mie scattering intensity (determines the color of the sky - play around with it)
  * `weather.atmosphere_brightness` \- Overall brightness of the sky
  * `weather.atmosphere_contrast` \- Overall contrast of the sky
  * `weather.atmosphere_directionality` \- Directionality factor that determines the size of the glow around the sun
  * `weather.cloud_size` \- Scale of the cloud layers (does not affect the cloud billboards)
  * `weather.cloud_opacity` \- Opacity of the cloud layers and billboards
  * `weather.cloud_coverage` \- How much sky is covered by the cloud layers
  * `weather.cloud_sharpness` \- How sharp the clouds formed by the cloud layers are
  * `weather.cloud_coloring` \- Determines the blending of indirect light from the sky and direct light from the sun
  * `weather.cloud_attenuation` \- How dark the clouds should be are when they get thicker
  * `weather.cloud_scattering` \- How much sunlight the clouds should scatter (makes them bloom)
  * `weather.cloud_brightness` \- Overall brightness of the clouds



Page views: 29,569  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9XZWF0aGVy)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9XZWF0aGVy)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




url: https://wiki.facepunch.com/rust/Workshop_FAQ
content:
__

#  [Rust Wiki](/rust/)

[Home](/rust/) / [Workshop FAQ](/rust/Workshop_FAQ)

  * [ __View](/rust/Workshop_FAQ)
  * [ __Edit](/rust/Workshop_FAQ~edit)
  * [ __History](/rust/Workshop_FAQ~history)



# Workshop FAQ

## My skin isn't visible in any of the lists __

You need to accept the Contributor Agreement before your items will be publicly visible, or can be added to the game.

## Do the artist see any money from the crates or marketplace?__

No. Crates are crafted for free by breaking down other items in your inventory, or by buying them from the marketplace, we don't sell them.

Steam doesn't have a way to split fees from market transfers. This is why a lot of games use the keys system.. in which users purchase keys to unlock crates - and a fraction of the price is split between every skin possible that this key could unlock. Keys don't sit right with us.

## Some of the items from last week were removed from the store and added to the crates?__

All skins have limited runs. Skins are removed when they've been around for a long time or have made too much money.

This is particularly true with bright skins that we don't want to see everywhere. We want them to be rare and expose a limited amount of them to the world.

## If two artists reach the same idea ( which is likely ) and they have similar rates, how would you decide which one to add to the game?__

Like everything, whichever is obviously the best, whichever has the most votes, whichever is presented nicer. If one artist hasn't had an item approved before, we'd lean towards approving that artists work. If one of the artists is a general arsehole in the community, we're less likely to approve theirs first.

## There seems to be a lot of issues with copyrighted material, what is technically legal in these sense?__

It's a matter of opinion a lot of the time. We can't really tell you where the line is without seeing it, things have to be judged on a case by case basis.

Page views: 16,221  
Updated: A Long Time Ago 

# Account Management

  * [ __Log In](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9Xb3Jrc2hvcF9GQVE%3D)
  * [ __Create Account](https://auth.facepunch.com/login/?r=aHR0cHM6Ly93aWtpLmZhY2VwdW5jaC5jb20vcnVzdC9Xb3Jrc2hvcF9GQVE%3D)



# Special Pages

  * [ __Recent Changes](/rust/~recentchanges "A list of recent changes")
  * [ __Unlisted Pages](/rust/~unlisted "Pages that are not in the sidebar")
  * [ __Errored Pages](/rust/~errors "A list of pages with errors")
  * [ __List of Pages](/rust/~pagelist "A list of all pages")



# Wiki List

  * [ Garry's Mod ](/gmod/ "Tutorials, reference and other resources for gmod's players, developers and server hosts")
  * [ Rust ](/rust/ "Description text goes here. It should be about this long, it shows under your site title.")
  * [ Steamworks ](/steamworks/ "Help and tutorials for using Facepunch's C# Steamworks Library")
  * [ Wiki Help ](/wiki/ "How to edit the wiki with documentation of all the markdown and custom tags")
  * [ S&box ](/sbox/)



[ ](/rust/)

#  [Rust Wiki](/rust/)

Playing

__Getting Started 0




__General 5

  * [ Chat ](/rust/global_text_chat)
  * [ Keybinds ](/rust/Keybinds)
  * [ Teams ](/rust/Teams)
  * [ Tool Cupboard, decay and building privilege ](/rust/the_tool_cupboard)
  * [ Useful Console Commands ](/rust/useful_commands)



__The World 7

  * [ Animals ](/rust/Animals)
  * [ Building-terminology ](/rust/Building-terminology)
  * [ Farming Basics ](/rust/Farming_Basics)
  * [ Fishing ](/rust/Fishing)
  * [ Ore Nodes ](/rust/Ore_nodes)
  * [ Outpost ](/rust/Outpost)
  * [ The Map ](/rust/map)



__Server Hosting 16

  * [ Adding custom radios to Boombox ](/rust/adding-custom-radios-to-boombox)
  * [ Centralized Banning ](/rust/centralized-banning)
  * [ Creating a hidden, whitelisted server ](/rust/Creating_a_hidden_whitelisted_server)
  * [ Creating a server ](/rust/Creating-a-server)
  * [ Custom Server Icon ](/rust/custom-server-icon)
  * [ Getting started with your rust server ](/rust/Getting-Started_w-Server)
  * [ Hosting Custom Maps ](/rust/Hosting_a_custom_map)
  * [ Procedural Generation Customization ](/rust/procedural_generation_customization)
  * [ Receiving player reports ](/rust/receiving-reports)
  * [ Rust+ Server ](/rust/rust-companion-server)
  * [ Server Browser Tags ](/rust/server-browser-tags)
  * [ Server Custom Emojis ](/rust/server-custom-emojis)
  * [ Server DNS Records ](/rust/dns-records)
  * [ Server Gamemodes ](/rust/server-gamemodes)
  * [ Server Wipe Timer ](/rust/server-wipe-timer)
  * [ Tutorial Island ](/rust/tutorial_island)



__Other Topics 5

  * [ Graffiti Pack ](/rust/graffiti-pack)
  * [ Instruments ](/rust/Instruments)
  * [ Sunburn ](/rust/sunburn)
  * [ Twitch Drops ](/rust/twitch-drops)
  * [ Weather ](/rust/Weather)



Developers

__Getting Started 0




__World Design 8

  * [ Custom Maps ](/rust/Custom_Maps)
  * [ FAQ and Troubleshooting ](/rust/FAQ_and_Troubleshooting)
  * [ Map Data ](/rust/Map_Data)
  * [ Map Editors ](/rust/Map_Editors)
  * [ Terrain ](/rust/Terrain)
  * [ Topology ](/rust/Topology)
  * [ Utility Prefabs ](/rust/Utility_Prefabs)
  * [ Volume Prefabs ](/rust/Volume_Prefabs)



__Skinning 2

  * [ Creating Skins ](/rust/Creating_Skins)
  * [ Creating Transparent PNGs ](/rust/Transparent_Pngs)



__Game Modes 0




__Workshop 2

  * [ Getting Your Skin Accepted ](/rust/Getting_Skin_Accepted)
  * [ Workshop FAQ ](/rust/Workshop_FAQ)



__Cinematic Tools 9

  * [ Cinematic Animations ](/rust/Cinematic_Animations)
  * [ CopyPaste ](/rust/CopyPaste)
  * [ Debug Camera ](/rust/Debug_Camera)
  * [ Demos ](/rust/Demos)
  * [ Depth Of Field ](/rust/Depth_Of_Field)
  * [ MIDI Binding ](/rust/MIDI_Binding)
  * [ Other Commands ](/rust/Other_Cinematic_Commands)
  * [ Overview ](/rust/Cinematic_Tools)
  * [ Prefabs & Entities ](/rust/Cinematic_Prefabs)



__Modding 11

  * [ Carbon Modding Framework ](/rust/Carbon)
  * [ Coroutines ](/rust/Coroutines)
  * [ CSharp Basics ](/rust/CSharp_Basics)
  * [ CSharp Formatting ](/rust/CSharp_Formatting)
  * [ Entities ](/rust/Entities)
  * [ Hooks ](/rust/Hooks)
  * [ Item Mods ](/rust/Item_Mods)
  * [ Items Overview ](/rust/Items_Overview)
  * [ Modding ](/rust/modding)
  * [ Modding Overview ](/rust/Modding_Overview)
  * [ Modding Tools ](/rust/Modding_Tools)



__Other Topics 0




Items

__Weapons 52

  * [ 16x Zoom Scope ](/rust/item/weapon.mod.8x.scope)
  * [ 8x Zoom Scope ](/rust/item/weapon.mod.small.scope)
  * [ Assault Rifle ](/rust/item/rifle.ak)
  * [ Beancan Grenade ](/rust/item/grenade.beancan)
  * [ Bolt Action Rifle ](/rust/item/rifle.bolt)
  * [ Bone Club ](/rust/item/bone.club)
  * [ Bone Knife ](/rust/item/knife.bone)
  * [ Butcher Knife ](/rust/item/knife.butcher)
  * [ Candy Cane Club ](/rust/item/candycaneclub)
  * [ Combat Knife ](/rust/item/knife.combat)
  * [ Compound Bow ](/rust/item/bow.compound)
  * [ Crossbow ](/rust/item/crossbow)
  * [ Custom SMG ](/rust/item/smg.2)
  * [ Double Barrel Shotgun ](/rust/item/shotgun.double)
  * [ Eoka Pistol ](/rust/item/pistol.eoka)
  * [ F1 Grenade ](/rust/item/grenade.f1)
  * [ Flame Thrower ](/rust/item/flamethrower)
  * [ Holosight ](/rust/item/weapon.mod.holosight)
  * [ Hunting Bow ](/rust/item/bow.hunting)
  * [ L96 Rifle ](/rust/item/rifle.l96)
  * [ Longsword ](/rust/item/longsword)
  * [ LR-300 Assault Rifle ](/rust/item/rifle.lr300)
  * [ M249 ](/rust/item/lmg.m249)
  * [ M39 Rifle ](/rust/item/rifle.m39)
  * [ M92 Pistol ](/rust/item/pistol.m92)
  * [ Mace ](/rust/item/mace)
  * [ Machete ](/rust/item/machete)
  * [ MP5A4 ](/rust/item/smg.mp5)
  * [ Multiple Grenade Launcher ](/rust/item/multiplegrenadelauncher)
  * [ Muzzle Boost ](/rust/item/weapon.mod.muzzleboost)
  * [ Muzzle Brake ](/rust/item/weapon.mod.muzzlebrake)
  * [ Nailgun ](/rust/item/pistol.nailgun)
  * [ Paddle ](/rust/paddle)
  * [ Pitchfork ](/rust/item/pitchfork)
  * [ Pump Shotgun ](/rust/item/shotgun.pump)
  * [ Python Revolver ](/rust/item/pistol.python)
  * [ Revolver ](/rust/item/pistol.revolver)
  * [ Rocket Launcher ](/rust/item/rocket.launcher)
  * [ Salvaged Cleaver ](/rust/item/salvaged.cleaver)
  * [ Salvaged Sword ](/rust/item/salvaged.sword)
  * [ Semi-Automatic Pistol ](/rust/item/pistol.semiauto)
  * [ Semi-Automatic Rifle ](/rust/item/rifle.semiauto)
  * [ Silencer ](/rust/item/weapon.mod.silencer)
  * [ Simple Handmade Sight ](/rust/item/weapon.mod.simplesight)
  * [ Snowball ](/rust/item/snowball)
  * [ Spas-12 Shotgun ](/rust/item/shotgun.spas12)
  * [ Stone Spear ](/rust/item/spear.stone)
  * [ Thompson ](/rust/item/smg.thompson)
  * [ Waterpipe Shotgun ](/rust/item/shotgun.waterpipe)
  * [ Weapon flashlight ](/rust/item/weapon.mod.flashlight)
  * [ Weapon Lasersight ](/rust/item/weapon.mod.lasersight)
  * [ Wooden Spear ](/rust/item/spear.wooden)



__Construction 45

  * [ Armored Door ](/rust/item/door.hinged.toptier)
  * [ Armored Double Door ](/rust/item/door.double.hinged.toptier)
  * [ Barbed Wooden Barricade ](/rust/item/barricade.woodwire)
  * [ Blueprint ](/rust/item/blueprintbase)
  * [ Building Plan ](/rust/item/building.planner)
  * [ Chainlink Fence ](/rust/item/wall.frame.fence)
  * [ Chainlink Fence Gate ](/rust/item/wall.frame.fence.gate)
  * [ Code Lock ](/rust/item/lock.code)
  * [ Concrete Barricade ](/rust/item/barricade.concrete)
  * [ Door Closer ](/rust/item/door.closer)
  * [ Floor grill ](/rust/item/floor.grill)
  * [ Garage Door ](/rust/item/wall.frame.garagedoor)
  * [ High External Stone Gate ](/rust/item/gates.external.high.stone)
  * [ High External Stone Wall ](/rust/item/wall.external.high.stone)
  * [ High External Wooden Gate ](/rust/item/gates.external.high.wood)
  * [ High External Wooden Wall ](/rust/item/wall.external.high)
  * [ Key Lock ](/rust/item/lock.key)
  * [ Ladder Hatch ](/rust/item/floor.ladder.hatch)
  * [ Large Water Catcher ](/rust/item/water.catcher.large)
  * [ Metal Barricade ](/rust/item/barricade.metal)
  * [ Metal horizontal embrasure ](/rust/item/shutter.metal.embrasure.a)
  * [ Metal Shop Front ](/rust/item/wall.frame.shopfront.metal)
  * [ Metal Vertical embrasure ](/rust/item/shutter.metal.embrasure.b)
  * [ Metal Window Bars ](/rust/item/wall.window.bars.metal)
  * [ Mining Quarry ](/rust/item/mining.quarry)
  * [ Netting ](/rust/item/wall.frame.netting)
  * [ Prison Cell Gate ](/rust/item/wall.frame.cell.gate)
  * [ Prison Cell Wall ](/rust/item/wall.frame.cell)
  * [ Pump Jack ](/rust/item/mining.pumpjack)
  * [ Reinforced Glass Window ](/rust/item/wall.window.glass.reinforced)
  * [ Reinforced Window Bars ](/rust/item/wall.window.bars.toptier)
  * [ Sandbag Barricade ](/rust/item/barricade.sandbags)
  * [ Sheet Metal Door ](/rust/item/door.hinged.metal)
  * [ Sheet Metal Double Door ](/rust/item/door.double.hinged.metal)
  * [ Shop Front ](/rust/item/wall.frame.shopfront)
  * [ Small Water Catcher ](/rust/item/water.catcher.small)
  * [ Stone Barricade ](/rust/item/barricade.stone)
  * [ Tool Cupboard ](/rust/item/cupboard.tool)
  * [ Watch Tower ](/rust/item/watchtower.wood)
  * [ Wood Double Door ](/rust/item/door.double.hinged.wood)
  * [ Wood Shutters ](/rust/item/shutter.wood.a)
  * [ Wooden Barricade ](/rust/item/barricade.wood)
  * [ Wooden Door ](/rust/item/door.hinged.wood)
  * [ Wooden Ladder ](/rust/item/ladder.wooden.wall)
  * [ Wooden Window Bars ](/rust/item/wall.window.bars.wood)



__Items 75

  * [ Barbeque ](/rust/item/bbq)
  * [ Bed ](/rust/item/bed)
  * [ Bota Bag ](/rust/item/botabag)
  * [ Camp Fire ](/rust/item/campfire)
  * [ Chair ](/rust/item/chair)
  * [ Chinese Lantern ](/rust/item/chineselantern)
  * [ Chippy Arcade Game ](/rust/item/arcade.machine.chippy)
  * [ Christmas Door Wreath ](/rust/item/xmasdoorwreath)
  * [ Christmas Lights ](/rust/item/xmas.lightstring)
  * [ Christmas Tree ](/rust/item/xmas.tree)
  * [ Composter ](/rust/item/composter)
  * [ Double Sign Post ](/rust/item/sign.post.double)
  * [ Dragon Door Knocker ](/rust/item/dragondoorknocker)
  * [ Drop Box ](/rust/item/dropbox)
  * [ Easter Door Wreath ](/rust/item/easterdoorwreath)
  * [ Festive Doorway Garland ](/rust/item/xmas.door.garland)
  * [ Festive Window Garland ](/rust/item/xmas.window.garland)
  * [ Fridge ](/rust/item/fridge)
  * [ Furnace ](/rust/item/furnace)
  * [ Hitch & Trough ](/rust/item/hitchtroughcombo)
  * [ Huge Wooden Sign ](/rust/item/sign.wooden.huge)
  * [ Jack O Lantern Angry ](/rust/item/jackolantern.angry)
  * [ Jack O Lantern Happy ](/rust/item/jackolantern.happy)
  * [ Kayak ](/rust/item/kayak)
  * [ Landscape Picture Frame ](/rust/item/sign.pictureframe.landscape)
  * [ Lantern ](/rust/item/lantern)
  * [ Large Banner Hanging ](/rust/item/sign.hanging.banner.large)
  * [ Large Banner on pole ](/rust/item/sign.pole.banner.large)
  * [ Large Furnace ](/rust/item/furnace.large)
  * [ Large Planter Box ](/rust/item/planter.large)
  * [ Large Wood Box ](/rust/item/box.wooden.large)
  * [ Large Wooden Sign ](/rust/item/sign.wooden.large)
  * [ Locker ](/rust/item/locker)
  * [ Mail Box ](/rust/item/mailbox)
  * [ Medium Wooden Sign ](/rust/item/sign.wooden.medium)
  * [ One Sided Town Sign Post ](/rust/item/sign.post.town)
  * [ Paper Map ](/rust/item/map)
  * [ Pookie Bear ](/rust/item/pookie.bear)
  * [ Portrait Picture Frame ](/rust/item/sign.pictureframe.portrait)
  * [ Reactive Target ](/rust/item/target.reactive)
  * [ Repair Bench ](/rust/item/box.repair.bench)
  * [ Research Table ](/rust/item/research.table)
  * [ Rug ](/rust/item/rug)
  * [ Rug Bear Skin ](/rust/item/rug.bear)
  * [ Salvaged Shelves ](/rust/item/shelves)
  * [ Scarecrow ](/rust/item/scarecrow)
  * [ Search Light ](/rust/item/searchlight)
  * [ Single Sign Post ](/rust/item/sign.post.single)
  * [ Skull Door Knocker ](/rust/item/skulldoorknocker)
  * [ Skull Fire Pit ](/rust/item/skull_fire_pit)
  * [ Sleeping Bag ](/rust/item/sleepingbag)
  * [ Small Oil Refinery ](/rust/item/small.oil.refinery)
  * [ Small Planter Box ](/rust/item/planter.small)
  * [ Small Stash ](/rust/item/stash.small)
  * [ Small Stocking ](/rust/item/stocking.small)
  * [ Small Wooden Sign ](/rust/item/sign.wooden.small)
  * [ Snowman ](/rust/item/snowman)
  * [ Spinning wheel ](/rust/item/spinner.wheel)
  * [ Stone Fireplace ](/rust/item/fireplace.stone)
  * [ SUPER Stocking ](/rust/item/stocking.large)
  * [ Survival Fish Trap ](/rust/item/fishtrap.small)
  * [ Table ](/rust/item/table)
  * [ Tall Picture Frame ](/rust/item/sign.pictureframe.tall)
  * [ Tuna Can Lamp ](/rust/item/tunalight)
  * [ Two Sided Hanging Sign ](/rust/item/sign.hanging)
  * [ Two Sided Town Sign Post ](/rust/item/sign.post.town.roof)
  * [ Vending Machine ](/rust/item/vending.machine)
  * [ Water Barrel ](/rust/item/water.barrel)
  * [ Water Purifier ](/rust/item/water.purifier)
  * [ Wood Storage Box ](/rust/item/box.wooden)
  * [ Work Bench Level 1 ](/rust/item/workbench1)
  * [ Work Bench Level 2 ](/rust/item/workbench2)
  * [ Work Bench Level 3 ](/rust/item/workbench3)
  * [ XL Picture Frame ](/rust/item/sign.pictureframe.xl)
  * [ XXL Picture Frame ](/rust/item/sign.pictureframe.xxl)



__Resources 31

  * [ Animal Fat ](/rust/item/fat.animal)
  * [ Battery - Small ](/rust/item/battery.small)
  * [ Bone Fragments ](/rust/item/bone.fragments)
  * [ CCTV Camera ](/rust/item/cctv.camera)
  * [ Charcoal ](/rust/item/charcoal)
  * [ Cloth ](/rust/item/cloth)
  * [ Coal :( ](/rust/item/coal)
  * [ Crude Oil ](/rust/item/crude.oil)
  * [ Diesel Fuel ](/rust/item/diesel_barrel)
  * [ Empty Can Of Beans ](/rust/item/can.beans.empty)
  * [ Empty Tuna Can ](/rust/item/can.tuna.empty)
  * [ Explosives ](/rust/item/explosives)
  * [ Gun Powder ](/rust/item/gunpowder)
  * [ High Quality Metal ](/rust/item/metal.refined)
  * [ High Quality Metal Ore ](/rust/item/hq.metal.ore)
  * [ Human Skull ](/rust/item/skull.human)
  * [ Leather ](/rust/item/leather)
  * [ Low Grade Fuel ](/rust/item/lowgradefuel)
  * [ Metal Fragments ](/rust/item/metal.fragments)
  * [ Metal Ore ](/rust/item/metal.ore)
  * [ Paper ](/rust/item/paper)
  * [ Research Paper ](/rust/item/researchpaper)
  * [ Salt Water ](/rust/item/water.salt)
  * [ Scrap ](/rust/item/scrap)
  * [ Stones ](/rust/item/stones)
  * [ Sulfur ](/rust/item/sulfur)
  * [ Sulfur Ore ](/rust/item/sulfur.ore)
  * [ Targeting Computer ](/rust/item/targeting.computer)
  * [ Water ](/rust/item/water)
  * [ Wolf Skull ](/rust/item/skull.wolf)
  * [ Wood ](/rust/item/wood)



__Attire 78

  * [ A Barrel Costume ](/rust/item/barrelcostume)
  * [ Arctic Scientist Suit ](/rust/item/hazmatsuit_scientist_arctic)
  * [ Bandana Mask ](/rust/item/mask.bandana)
  * [ Baseball Cap ](/rust/item/hat.cap)
  * [ Basic Horse Shoes ](/rust/item/horse.shoes.basic)
  * [ Bone Armor ](/rust/item/bone.armor.suit)
  * [ Bone Helmet ](/rust/item/deer.skull.mask)
  * [ Boonie Hat ](/rust/item/hat.boonie)
  * [ Boots ](/rust/item/shoes.boots)
  * [ Bucket Helmet ](/rust/item/bucket.helmet)
  * [ Bunny Ears ](/rust/item/attire.bunnyears)
  * [ Bunny Onesie ](/rust/item/attire.bunny.onesie)
  * [ Burlap Gloves ](/rust/item/burlap.gloves.new)
  * [ Burlap Headwrap ](/rust/item/burlap.headwrap)
  * [ Burlap Shirt ](/rust/item/burlap.shirt)
  * [ Burlap Shoes ](/rust/item/burlap.shoes)
  * [ Burlap Trousers ](/rust/item/burlap.trousers)
  * [ Candle Hat ](/rust/item/hat.candle)
  * [ Clatter Helmet ](/rust/item/clatter.helmet)
  * [ Coffee Can Helmet ](/rust/item/coffeecan.helmet)
  * [ Crate Costume ](/rust/item/cratecostume)
  * [ Diving Fins ](/rust/item/diving.fins)
  * [ Diving Mask ](/rust/item/diving.mask)
  * [ Diving Tank ](/rust/item/diving.tank)
  * [ Dragon Mask ](/rust/item/hat.dragonmask)
  * [ Frog Boots ](/rust/item/boots.frog)
  * [ Glowing Eyes ](/rust/item/gloweyes)
  * [ Hazmat Suit ](/rust/item/hazmatsuit)
  * [ Heavy Plate Helmet ](/rust/item/heavy.plate.helmet)
  * [ Heavy Plate Jacket ](/rust/item/heavy.plate.jacket)
  * [ Heavy Plate Pants ](/rust/item/heavy.plate.pants)
  * [ Heavy Scientist Suit ](/rust/item/scientistsuit_heavy)
  * [ Hide Boots ](/rust/item/attire.hide.boots)
  * [ Hide Halterneck ](/rust/item/attire.hide.helterneck)
  * [ Hide Pants ](/rust/item/attire.hide.pants)
  * [ Hide Poncho ](/rust/item/attire.hide.poncho)
  * [ Hide Skirt ](/rust/item/attire.hide.skirt)
  * [ Hide Vest ](/rust/item/attire.hide.vest)
  * [ High Quality Horse Shoes ](/rust/item/horse.shoes.advanced)
  * [ Hoodie ](/rust/item/hoodie)
  * [ Improvised Balaclava ](/rust/item/mask.balaclava)
  * [ Jacket ](/rust/item/jacket)
  * [ Leather Gloves ](/rust/item/burlap.gloves)
  * [ Longsleeve T-Shirt ](/rust/item/tshirt.long)
  * [ Metal Chest Plate ](/rust/item/metal.plate.torso)
  * [ Metal Facemask ](/rust/item/metal.facemask)
  * [ Miners Hat ](/rust/item/hat.miner)
  * [ Mummy Suit ](/rust/item/halloween.mummysuit)
  * [ Night Vision Goggles ](/rust/item/nightvisiongoggles)
  * [ Pants ](/rust/item/pants)
  * [ Party Hat ](/rust/item/partyhat)
  * [ Rat Mask ](/rust/item/hat.ratmask)
  * [ Reindeer Antlers ](/rust/item/attire.reindeer.headband)
  * [ Riot Helmet ](/rust/item/riot.helmet)
  * [ Road Sign Jacket ](/rust/item/roadsign.jacket)
  * [ Road Sign Kilt ](/rust/item/roadsign.kilt)
  * [ Roadsign Gloves ](/rust/item/roadsign.gloves)
  * [ Roadsign Horse Armor ](/rust/item/horse.armor.roadsign)
  * [ Saddle bag ](/rust/item/horse.saddlebag)
  * [ Santa Beard ](/rust/item/santabeard)
  * [ Santa Hat ](/rust/item/santahat)
  * [ Scarecrow Suit ](/rust/item/scarecrow.suit)
  * [ Scarecrow Wrap ](/rust/item/scarecrowhead)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist)
  * [ Scientist Suit ](/rust/item/hazmatsuit_scientist_peacekeeper)
  * [ Shirt ](/rust/item/shirt.collared)
  * [ Shorts ](/rust/item/pants.shorts)
  * [ Snow Jacket ](/rust/item/jacket.snow)
  * [ Surgeon Scrubs ](/rust/item/halloween.surgeonsuit)
  * [ T-Shirt ](/rust/item/tshirt)
  * [ Tactical Gloves ](/rust/item/tactical.gloves)
  * [ Tank Top ](/rust/item/shirt.tanktop)
  * [ Wetsuit ](/rust/item/diving.wetsuit)
  * [ Wolf Headdress ](/rust/item/hat.wolf)
  * [ Wood Armor Helmet ](/rust/item/wood.armor.helmet)
  * [ Wood Armor Pants ](/rust/item/wood.armor.pants)
  * [ Wood Chestplate ](/rust/item/wood.armor.jacket)
  * [ Wooden Horse Armor ](/rust/item/horse.armor.wood)



__Tools 26

  * [ Binoculars ](/rust/item/tool.binoculars)
  * [ Birthday Cake ](/rust/item/cakefiveyear)
  * [ bucket.water ](/rust/item/bucket.water)
  * [ Camera ](/rust/item/tool.camera)
  * [ Chainsaw ](/rust/item/chainsaw)
  * [ Flare ](/rust/item/flare)
  * [ Flashlight ](/rust/item/flashlight.held)
  * [ Garry's Mod Tool Gun ](/rust/item/toolgun)
  * [ Geiger Counter ](/rust/item/geiger.counter)
  * [ Hammer ](/rust/item/hammer)
  * [ Handmade Fishing Rod ](/rust/item/fishingrod.handmade)
  * [ Hatchet ](/rust/item/hatchet)
  * [ Jackhammer ](/rust/item/jackhammer)
  * [ Pickaxe ](/rust/item/pickaxe)
  * [ RF Transmitter ](/rust/item/rf.detonator)
  * [ Rock ](/rust/item/rock)
  * [ Salvaged Axe ](/rust/item/axe.salvaged)
  * [ Salvaged Hammer ](/rust/item/hammer.salvaged)
  * [ Salvaged Icepick ](/rust/item/icepick.salvaged)
  * [ Satchel Charge ](/rust/item/explosive.satchel)
  * [ Smoke Grenade ](/rust/item/grenade.smoke)
  * [ Stone Hatchet ](/rust/item/stonehatchet)
  * [ Stone Pickaxe ](/rust/item/stone.pickaxe)
  * [ Survey Charge ](/rust/item/surveycharge)
  * [ Timed Explosive Charge ](/rust/item/explosive.timed)
  * [ Torch ](/rust/item/torch)



__Medical 5

  * [ Anti-Radiation Pills ](/rust/item/antiradpills)
  * [ Bandage ](/rust/item/bandage)
  * [ Blood ](/rust/item/blood)
  * [ Large Medkit ](/rust/item/largemedkit)
  * [ Medical Syringe ](/rust/item/syringe.medical)



__Food 51

  * [ Apple ](/rust/item/apple)
  * [ Black Raspberries ](/rust/item/black.raspberries)
  * [ Blueberries ](/rust/item/blueberries)
  * [ Burnt Bear Meat ](/rust/item/bearmeat.burned)
  * [ Burnt Chicken ](/rust/item/chicken.burned)
  * [ Burnt Deer Meat ](/rust/item/deermeat.burned)
  * [ Burnt Horse Meat ](/rust/item/horsemeat.burned)
  * [ Burnt Human Meat ](/rust/item/humanmeat.burned)
  * [ Burnt Pork ](/rust/item/meat.pork.burned)
  * [ Burnt Wolf Meat ](/rust/item/wolfmeat.burned)
  * [ Cactus Flesh ](/rust/item/cactusflesh)
  * [ Can of Beans ](/rust/item/can.beans)
  * [ Can of Tuna ](/rust/item/can.tuna)
  * [ Candy Cane ](/rust/item/candycane)
  * [ Chocolate Bar ](/rust/item/chocholate)
  * [ Cooked Bear Meat ](/rust/item/bearmeat.cooked)
  * [ Cooked Chicken ](/rust/item/chicken.cooked)
  * [ Cooked Deer Meat ](/rust/item/deermeat.cooked)
  * [ Cooked Fish ](/rust/item/fish.cooked)
  * [ Cooked Horse Meat ](/rust/item/horsemeat.cooked)
  * [ Cooked Human Meat ](/rust/item/humanmeat.cooked)
  * [ Cooked Pork ](/rust/item/meat.pork.cooked)
  * [ Cooked Wolf Meat ](/rust/item/wolfmeat.cooked)
  * [ Corn ](/rust/item/corn)
  * [ Corn Clone ](/rust/item/clone.corn)
  * [ Corn Seed ](/rust/item/seed.corn)
  * [ Farming & Genetics ](/rust/Farming)
  * [ Granola Bar ](/rust/item/granolabar)
  * [ Hemp Clone ](/rust/item/clone.hemp)
  * [ Hemp Seed ](/rust/item/seed.hemp)
  * [ Minnows ](/rust/item/fish.minnows)
  * [ Mushroom ](/rust/item/mushroom)
  * [ Pickles ](/rust/item/jar.pickle)
  * [ Pumpkin ](/rust/item/pumpkin)
  * [ Pumpkin Plant Clone ](/rust/item/clone.pumpkin)
  * [ Pumpkin Seed ](/rust/item/seed.pumpkin)
  * [ Raw Bear Meat ](/rust/item/bearmeat)
  * [ Raw Chicken Breast ](/rust/item/chicken.raw)
  * [ Raw Deer Meat ](/rust/item/deermeat.raw)
  * [ Raw Fish ](/rust/item/fish.raw)
  * [ Raw Horse Meat ](/rust/item/horsemeat.raw)
  * [ Raw Human Meat ](/rust/item/humanmeat.raw)
  * [ Raw Pork ](/rust/item/meat.boar)
  * [ Raw Wolf Meat ](/rust/item/wolfmeat.raw)
  * [ Rotten Apple ](/rust/item/apple.spoiled)
  * [ Small Trout ](/rust/item/fish.troutsmall)
  * [ Small Water Bottle ](/rust/item/smallwaterbottle)
  * [ Spoiled Chicken ](/rust/item/chicken.spoiled)
  * [ Spoiled Human Meat ](/rust/item/humanmeat.spoiled)
  * [ Spoiled Wolf Meat ](/rust/item/wolfmeat.spoiled)
  * [ Water Jug ](/rust/item/waterjug)



__Ammo 24

  * [ 12 Gauge Buckshot ](/rust/item/ammo.shotgun)
  * [ 12 Gauge Incendiary Shell ](/rust/item/ammo.shotgun.fire)
  * [ 12 Gauge Slug ](/rust/item/ammo.shotgun.slug)
  * [ 40mm HE Grenade ](/rust/item/ammo.grenadelauncher.he)
  * [ 40mm Shotgun Round ](/rust/item/ammo.grenadelauncher.buckshot)
  * [ 40mm Smoke Grenade ](/rust/item/ammo.grenadelauncher.smoke)
  * [ 5.56 Rifle Ammo ](/rust/item/ammo.rifle)
  * [ Bone Arrow ](/rust/item/arrow.bone)
  * [ Explosive 5.56 Rifle Ammo ](/rust/item/ammo.rifle.explosive)
  * [ Fire Arrow ](/rust/item/arrow.fire)
  * [ Handmade Shell ](/rust/item/ammo.handmade.shell)
  * [ High Velocity Arrow ](/rust/item/arrow.hv)
  * [ High Velocity Rocket ](/rust/item/ammo.rocket.hv)
  * [ HV 5.56 Rifle Ammo ](/rust/item/ammo.rifle.hv)
  * [ HV Pistol Ammo ](/rust/item/ammo.pistol.hv)
  * [ Incendiary 5.56 Rifle Ammo ](/rust/item/ammo.rifle.incendiary)
  * [ Incendiary Pistol Bullet ](/rust/item/ammo.pistol.fire)
  * [ Incendiary Rocket ](/rust/item/ammo.rocket.fire)
  * [ Nailgun Nails ](/rust/item/ammo.nailgun.nails)
  * [ Pistol Bullet ](/rust/item/ammo.pistol)
  * [ Rocket ](/rust/item/ammo.rocket.basic)
  * [ SAM Ammo ](/rust/item/ammo.rocket.sam)
  * [ Smoke Rocket WIP!!!! ](/rust/item/ammo.rocket.smoke)
  * [ Wooden Arrow ](/rust/item/arrow.wooden)



__Traps 7

  * [ Flame Turret ](/rust/item/flameturret)
  * [ Homemade Landmine ](/rust/item/trap.landmine)
  * [ SAM Site ](/rust/item/samsite)
  * [ Shotgun Trap ](/rust/item/guntrap)
  * [ Snap Trap ](/rust/item/trap.bear)
  * [ Tesla Coil ](/rust/item/teslacoil)
  * [ Wooden Floor Spikes ](/rust/item/spikes.floor)



__Components 20

  * [ Armored Cockpit Vehicle Module ](/rust/vehicle.1mod.cockpit.armored)
  * [ Bleach ](/rust/item/bleach)
  * [ Duct Tape ](/rust/item/ducttape)
  * [ Electric Fuse ](/rust/item/fuse)
  * [ Empty Propane Tank ](/rust/item/propanetank)
  * [ Gears ](/rust/item/gears)
  * [ Glue ](/rust/item/glue)
  * [ Metal Blade ](/rust/item/metalblade)
  * [ Metal Pipe ](/rust/item/metalpipe)
  * [ Metal Spring ](/rust/item/metalspring)
  * [ Rifle Body ](/rust/item/riflebody)
  * [ Road Signs ](/rust/item/roadsigns)
  * [ Rope ](/rust/item/rope)
  * [ Semi Automatic Body ](/rust/item/semibody)
  * [ Sewing Kit ](/rust/item/sewingkit)
  * [ Sheet Metal ](/rust/item/sheetmetal)
  * [ SMG Body ](/rust/item/smgbody)
  * [ Sticks ](/rust/item/sticks)
  * [ Tarp ](/rust/item/tarp)
  * [ Tech Trash ](/rust/item/techparts)



__Electrical 39

  * [ AND Switch ](/rust/item/electric.andswitch)
  * [ Audio Alarm ](/rust/item/electric.audioalarm)
  * [ Auto Turret ](/rust/item/autoturret)
  * [ Blocker ](/rust/item/electric.blocker)
  * [ Cable Tunnel ](/rust/item/electric.cabletunnel)
  * [ Ceiling Light ](/rust/item/ceilinglight)
  * [ Counter ](/rust/item/electric.counter)
  * [ Deluxe Christmas Lights ](/rust/item/xmas.lightstring.advanced)
  * [ Door Controller ](/rust/item/electric.doorcontroller)
  * [ Electrical Branch ](/rust/item/electrical.branch)
  * [ Elevator ](/rust/item/elevator)
  * [ Flasher Light ](/rust/item/electric.flasherlight)
  * [ HBHF Sensor ](/rust/item/electric.hbhfsensor)
  * [ Igniter ](/rust/item/electric.igniter)
  * [ Large Rechargable Battery ](/rust/item/electric.battery.rechargable.large)
  * [ Large Solar Panel ](/rust/item/electric.solarpanel.large)
  * [ Laser Detector ](/rust/item/electric.laserdetector)
  * [ Medium Rechargable Battery ](/rust/item/electric.battery.rechargable.medium)
  * [ Memory Cell ](/rust/item/electrical.memorycell)
  * [ OR Switch ](/rust/item/electric.orswitch)
  * [ Pressure Pad ](/rust/item/electric.pressurepad)
  * [ RAND Switch ](/rust/item/electric.random.switch)
  * [ RF Broadcaster ](/rust/item/electric.rf.broadcaster)
  * [ RF Pager ](/rust/item/rf_pager)
  * [ RF Receiver ](/rust/item/electric.rf.receiver)
  * [ Root Combiner ](/rust/item/electrical.combiner)
  * [ Seismic Sensor ](/rust/item/electric.seismicsensor)
  * [ Simple Light ](/rust/item/electric.simplelight)
  * [ Siren Light ](/rust/item/electric.sirenlight)
  * [ Small Generator ](/rust/item/electric.fuelgenerator.small)
  * [ Small Rechargable Battery ](/rust/item/electric.battery.rechargable.small)
  * [ Splitter ](/rust/item/electric.splitter)
  * [ Switch ](/rust/item/electric.switch)
  * [ Tesla Coil ](/rust/item/electric.teslacoil)
  * [ Test Generator ](/rust/item/electric.generator.small)
  * [ Timer ](/rust/item/electric.timer)
  * [ Wind Turbine ](/rust/item/generator.wind.scrap)
  * [ Wire Tool ](/rust/item/wiretool)
  * [ XOR Switch ](/rust/item/electric.xorswitch)



__Fun 28

  * [ Acoustic Guitar ](/rust/item/fun.guitar)
  * [ Blue Boomer ](/rust/item/firework.boomer.blue)
  * [ Blue Roman Candle ](/rust/item/firework.romancandle.blue)
  * [ Canbourine ](/rust/item/fun.tambourine)
  * [ Champagne Boomer ](/rust/item/firework.boomer.champagne)
  * [ Cowbell ](/rust/item/fun.cowbell)
  * [ Firecracker String ](/rust/item/lunar.firecrackers)
  * [ Green Boomer ](/rust/item/firework.boomer.green)
  * [ Green Roman Candle ](/rust/item/firework.romancandle.green)
  * [ Jerry Can Guitar ](/rust/item/fun.jerrycanguitar)
  * [ Junkyard Drum Kit ](/rust/item/drumkit)
  * [ New Year Gong ](/rust/item/newyeargong)
  * [ Orange Boomer ](/rust/item/firework.boomer.orange)
  * [ Pan Flute ](/rust/item/fun.flute)
  * [ Plumber's Trumpet ](/rust/item/fun.trumpet)
  * [ Red Boomer ](/rust/item/firework.boomer.red)
  * [ Red Roman Candle ](/rust/item/firework.romancandle.red)
  * [ Red Volcano Firework ](/rust/item/firework.volcano.red)
  * [ Shovel Bass ](/rust/item/fun.bass)
  * [ Sousaphone ](/rust/item/fun.tuba)
  * [ Violet Boomer ](/rust/item/firework.boomer.violet)
  * [ Violet Roman Candle ](/rust/item/firework.romancandle.violet)
  * [ Violet Volcano Firework ](/rust/item/firework.volcano.violet)
  * [ Wheelbarrow Piano ](/rust/item/piano)
  * [ White Volcano Firework ](/rust/item/firework.volcano)
  * [ Wrapped Gift ](/rust/item/wrappedgift)
  * [ Wrapping Paper ](/rust/item/wrappingpaper)
  * [ Xylobone ](/rust/item/xylophone)



__Misc 45

  * [ Blue Keycard ](/rust/item/keycard_blue)
  * [ Bronze Egg ](/rust/item/easter.bronzeegg)
  * [ Coffin ](/rust/item/coffin.storage)
  * [ Cursed Cauldron ](/rust/item/cursedcauldron)
  * [ Decorative Baubels ](/rust/item/xmas.decoration.baubels)
  * [ Decorative Gingerbread Men ](/rust/item/xmas.decoration.gingerbreadmen)
  * [ Decorative Pinecones ](/rust/item/xmas.decoration.pinecone)
  * [ Decorative Plastic Candy Canes ](/rust/item/xmas.decoration.candycanes)
  * [ Decorative Tinsel ](/rust/item/xmas.decoration.tinsel)
  * [ Door Key ](/rust/item/door.key)
  * [ Egg Basket ](/rust/item/easterbasket)
  * [ Fogger-3000 ](/rust/item/fogmachine)
  * [ Giant Candy Decor ](/rust/item/giantcandycanedecor)
  * [ Giant Lollipop Decor ](/rust/item/giantlollipops)
  * [ Gold Egg ](/rust/item/easter.goldegg)
  * [ Gravestone ](/rust/item/gravestone)
  * [ Graveyard Fence ](/rust/item/wall.graveyard.fence)
  * [ Green Keycard ](/rust/item/keycard_green)
  * [ Hab Repair ](/rust/item/habrepair)
  * [ Halloween Candy ](/rust/item/halloween.candy)
  * [ Large Candle Set ](/rust/item/largecandles)
  * [ Large Loot Bag ](/rust/item/halloween.lootbag.large)
  * [ Large Present ](/rust/item/xmas.present.large)
  * [ MC repair ](/rust/item/minihelicopter.repair)
  * [ Medium Loot Bag ](/rust/item/halloween.lootbag.medium)
  * [ Medium Present ](/rust/item/xmas.present.medium)
  * [ Note ](/rust/item/note)
  * [ Painted Egg ](/rust/item/easter.paintedeggs)
  * [ Pumpkin Bucket ](/rust/item/pumpkinbasket)
  * [ Red Keycard ](/rust/item/keycard_red)
  * [ Rustige Egg - Blue ](/rust/item/rustige_egg_b)
  * [ Rustige Egg - Red ](/rust/item/rustige_egg_a)
  * [ ScrapTransportHeliRepair ](/rust/item/scraptransportheli.repair)
  * [ Sickle ](/rust/item/sickle)
  * [ Silver Egg ](/rust/item/easter.silveregg)
  * [ Small Candle Set ](/rust/item/smallcandles)
  * [ Small Loot Bag ](/rust/item/halloween.lootbag.small)
  * [ Small Present ](/rust/item/xmas.present.small)
  * [ Snow Machine ](/rust/item/snowmachine)
  * [ Spider Webs ](/rust/item/spiderweb)
  * [ Spooky Speaker ](/rust/item/spookyspeaker)
  * [ Star Tree Topper ](/rust/item/xmas.decoration.star)
  * [ Strobe Light ](/rust/item/strobelight)
  * [ Tree Lights ](/rust/item/xmas.decoration.lights)
  * [ Wooden Cross ](/rust/item/woodcross)




