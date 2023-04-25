# Plugin!
Plugins usually override or create HTTP calls.

For example the `/test` response will not be `test`\
It will be saying `testing with MyCoolPlugin`

## Name & Author
You can use any names you want. Can be file name, can be project name.\
I suggest use something like AthorName_Project

SlejmUr_MoreTrader for example

## Version
Version is can be anything.\
Can start with V or without. You can use commitId. or just simple 0.1, alpha, etc.

## Dependencies
When making a Plugin You can add Dependencies from other Plugins

For Example:\
`public List<string> Dependencies => new() { "3X4MPL3_Core" };`\
Make sure the dependecy name is same as the dependent Plugin name

## Publishing / Disctibution
When building the server you must send your Dll and any other file that you dont see the ConsoleApp/ServerApp and in the Ref folder.\
For example I made a ExtCommands Plugin, I need to send the JWT.dll and the System.Text.Json.dll too.\
I dont need to send System.Composition.AttributedModel.dll, Newtonsoft.Json.dll, because that exist in reference,\
and same for NetCoreServer, WatsonWebsocket files, because they exist in ConsoleApp/ServerApp.\
If you depend on another Plugin, you dont need to send that file.