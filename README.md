## FrontSharp - A [FrontApp API](https://dev.frontapp.com/) C# Wrapper

### License
FrontSharp is licensed under the [MIT](https://github.com/cal5fishbowl/frontsharp/blob/master/LICENSE) license.


### Quick Start
Install the [NuGet package](https://www.nuget.org/packages/FrontSharp/) from the package manager console:
```powershell
Install-Package FrontSharp
```
Using it in code
```CSharp
FrontSharpClient client = new FrontSharpClient(baseUrl, token); //if you have it in code

<add key="FrontAPIEndpoint" value="ENDPOINT"/>
<add key="FrontAPIToken" value="FRONTAPITOKEN"/>

FrontSharpClient client = new FrontSharpClient(); //if you have it in config
```
