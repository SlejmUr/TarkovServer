# Tarkov Server
Tarkov Server on C# (.NET 6)

This is my attempt to port existing JavaScript code to C#.\
Because I am not want and familiar with JS and his funny stuffs.

And possibly easier to make a nice Server UI with this (Xaml, or just Winform).\
Still in early phase, in development!

## References
Assembly-CSharp.dll\
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
- Paulov for editing Existed Tarkov Server code
- Altered Escape Team for MTGA and some of easier Server code
- SPT-AKI Team for some of the newest Jsons
- NBJF, Panther for Testing & Debugging
- SlejmUr for the Original Idea

## Build
Make a Ref folder next to TarkovServer.sln and paste the References.\
Open SLN in Visual Studio.\
Build=>(Re-)Build Solution

## Linux Support
I planning to add a linux support (If most of the stuff done) on this project, If you want to help me with this DM me on Discord!
(I'm on many Tarkov related Discord servers)

## Mod/Plugin support
You can add your or anyone plugin, but be careful cus they can use any malicius code.\
Dont obfuscate plugin because it will not work! Need to get the Plugin.Plugin to load. More on Mod/Plugin Wiki! (In future)\
You can check TestPlugin for some of the changes.

## Contributors & Devs
You can add you own idea or anything, make a PR and I will check it. Feel free to import something you like.

## Releases
Release will come if everything works as intended it should work.\
It need most of the Managed dll's and the two dll you find in the _Ref folder!\
When using the ConsoleApp it will create a path.txt\
Edit that to a directory where the managed dlls are + the two dll from _Ref folder\
I suggest copy all dll's from the Managed folder and paste into a folder that says in the path.txt [Ref folder]
