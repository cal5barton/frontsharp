# FrontSharp [![Build Status](https://cal5barton.visualstudio.com/frontsharp/_apis/build/status/cal5barton.frontsharp?branchName=master)](https://cal5barton.visualstudio.com/frontsharp/_build/latest?definitionId=1&branchName=master) [![Deployement Status](https://cal5barton.vsrm.visualstudio.com/_apis/public/Release/badge/3ddd3b5d-f54b-4244-ab0e-4c40a3ebded7/1/1)](https://cal5barton.vsrm.visualstudio.com/_apis/public/Release/badge/3ddd3b5d-f54b-4244-ab0e-4c40a3ebded7/1/1)
FrontSharp is a C# Wrapper that simplifies the ability to interface with the [FrontApp API](https://dev.frontapp.com/)

## Installation
### Nuget
Install the [NuGet package](https://www.nuget.org/packages/FrontSharp/) from the package manager console:
```powershell
Install-Package FrontSharp
```
## Getting Started
```CSharp
var client = new FrontSharpClient("FRONTAPI_ENDPOINT", "FRONTAPI_TOKEN");
var conversation = client.Conversations.Get("cnv_52c7c1");
```
If you are looking for a more succinct setup of your client you can store your connection details in your web.config file's AppSettings tag.
```xml
<configuration>
    <appSettings>
        <add key="FrontAPIEndpoint" value="ENDPOINT"/>
        <add key="FrontAPIToken" value="FRONTAPITOKEN"/>
      </appSettings>
</configuration>
```
```CSharp
var client = new FrontSharpClient();
```
## Supported Methods
* FrontSharpClient
  * Attachments
      * **Download**
  * Channels
      * **GetByAddress**
      * **GetById**
  * Comments
      * **Create**
  * Contacts
      * **Get**
  * Conversations
      * **Get**
      * **List**
      * **ListInboxes**
      * **ListMessages**
      * **Update**
  * Events
      * **Get**
      * **List**
  * Inboxes
      * **Get**
      * **List**
      * **ListConversations**
  * Messages
      * **SendReply**
      * **ImportMessage**
  * Tags
      * **CreateTag**
      * **DeleteTag**
      * **ListTags**
  * Teammates
      * **Get**
      * **List**
      * **ListConversations**
      * **ListInboxes**
      * **Update**

## License
FrontSharp is licensed under the [MIT](https://github.com/cal5fishbowl/frontsharp/blob/master/LICENSE) license.
