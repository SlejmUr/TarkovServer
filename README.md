# Tarkov Server
Tarkov Server on C#

This is my attempt to port existing JavaScript(nodejs) code to C#.\
Because I am not want and familiar with JS and his funny stuffs.

And possibly easier to make a nice Server UI with this (Xaml, or just Winform).\
Still in early phase, in development!

## References
bsg.componentace.compression.libs.zlib.dll\
bsg.console.core\
bsg.microsoft.extensions.objectpool.dll\
bsg.system.buffers.dll\
Newtonsoft.Json\
UnityEngine.dll\
UnityEngine.CoreModule.dll

(Just put all in there you didn't miss much)

## Credits
- TheMaoci for official Research and Dump Tutorials
- JET Team for making Tarkov Server
- Paulov for editing Existed Tarkov Server code & soon-to-be Multi Server
- Apofis for soon-to-be MultiPlayer code
- Altered Escape Team for MTGA and some of easier Server code
- NBJF, Panther for Testing & Debugging
- SlejmUr for the Original Idea

## Build
Make a Ref folder next to Tarkov_Server_Csharp.sln and paste the References.\
Open SLN in Visual Studio.\
Build=>(Re-)Build Solution

## Linux Support
I planning to add a linux support (If most of the stuff done) on this project, If you want to help me with this DM me on Discord!
(I'm on Altered Escape,JET, MTGA Discord)

## Mod/Plugin support
You can add your or anyone plugin, but be careful cus they can use any malicius code.\
Dont obfuscate plugin because it will not work! Need to get the Plugin.Plugin to load. More on Mod/Plugin Wiki! (In future)\
You can check TestPlugin for some of the changes.

## Contributors & Devs
You can add you own idea or anything, make a PR and I will check it. Feel free to import something you like.

## Releases
Because I used 2 project to make server work (Lib + Console), Probably its gonna be hard to make a proper "Build/Release" for it, I still looking for a solution
