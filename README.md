# Deprecated. Feel free to use any code from it.
Deprecated the flavour of making a better game (that has moddability, better support) than EFT will EVER do.

# Tarkov Server
Tarkov Server on C# (.NET 8)

This is my attempt to port existing JavaScript/Go/Typescript code to C#.\
Because I am not want and familiar with JS and his funny stuffs.

And possibly easier to make a nice Server UI with this (Xaml, or just Winform).\

## Credits
- BattleStateGames for making Escape From Tarkov
- chronoxor for making NetCoreServer
- TheMaoci for official Research and Dump Tutorials
- JET Team for making Tarkov Server
- Paulov for editing Existed Tarkov Server code
- Altered Escape Team for MTGA and some of easier Server code
- SPT-AKI Team for some of the newest Jsons
- NBJF, Panther for Testing & Debugging
- Nexus4880 for helping me understand the udp dumps
- SlejmUr for the Original Idea

## Build
Open TarkovServer.sln\
Build=>(Re-)Build Solution

## Linux Support
I planning to add a linux support (If most of the stuff done) on this project, If you want to help me with this DM me on Discord!
(I'm on many Tarkov related Discord servers)

## Plugin support
You can add your or anyone plugin, but be careful because they can use any malicius code.\
Dont obfuscate plugin because it will not work! Need to get the Plugin.Plugin to load. More on Mod/Plugin Wiki! (In future)\
You can check TestPlugin for some of the changes.

## Contributors & Devs
You can add you own idea or anything, make a PR and I will check it. Feel free to import something you like.

## Running
You can either use ConsoleApp or ServerApp. \
ConsoleApp is for people who want to run it headlessly, ServerApp is currently a WinForm GUI. (Still working on it.) \
Either one it probably gonna crash first start, its normal! \
Download the latest Ref.7z from github Release section. \
Extract next to the .exe and rename the folder to _References. \
Or you can make a "path.txt" file and enter the full path for your extracted Ref folder \
Run your designed Application and your server is running!

# Multiplayer
Currently working on Unity 2019.4.39 version of server. \
https://github.com/SlejmUr/U19_TarkovServer \
Check LTS which version currently is in development!

# LTS
Current LTS:
- 0.14.1.0.28744\
Reason:\
New tarkov (0.14) released currently this is the version AKI, and other people using.\
Currently it's a live version.\
Supported until: 0.14.2+

Older LTS:
- 0.14.0.1.28476\
Reason:\
Live version got updated. It does not bring major changes. only some part of json change.\

- 0.13.5.3.x\
Reason:\
Was pretty stable, long time was good, viable.\
No longer support, because too much changed.
