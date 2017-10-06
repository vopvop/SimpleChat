# Simple chat
Another one example of text messages exchange service. Based on the next libs list:
1. ASP.NET Core 2.0;
1. SignalR 1.0.0-alpha1-final for ASP.NET Core 2.0;
1. Angular 4.1.2;
1. Typescript 2.3;
1. Swagger 1.0.0.
## How to
To implement SignalR usage on ASP.NET Core app you should:
1. Create ASP.NET Core project;
1. Add NuGet references to the next libs:
    1. `Microsoft.AspNetCore.All`;
    1. `Microsoft.AspNetCore.SignalR`.
1. Implement nested from `Hub` or `Hub<T>` class:
```csharp
namespace SimpleChat.Hubs
{
	using System;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.SignalR;

	using SimpleChat.Models;

	public sealed class ChatHub: Hub<IChatHub>
	{
		public async Task Send(ChatMessageModel chatMessage)
		{
			if (chatMessage == null) throw new ArgumentNullException(nameof(chatMessage));

			await Clients.All.Send(chatMessage);
		}
	}
}
```
4. Add support for SignalR in Startup.cs. Enable SignalR for our application:
```csharp
services.AddSignalR();
```
Create route mapping for our Chat SignalR Hub implementation:
    
```csharp
app.UseSignalR(routes =>
  routes.MapHub<ChatHub>("chathub")
);
```
5. Install the latest version of the ASP.NET Core SignalR NPM package:
```
npm install @aspnet/signalr-client
```
6. Now we can create, setup and start SignalR's HubConnection in a Typescript component:
```typescript
this.chatHub = new HubConnection(originUrl + "/chathub");

this.chatHub.on(
  "Send",
  data => this.receiveMessage(data));

this.chatHub
  .start()
  .catch(error => console.log(error));
```
That is all.
## Useful links
* SignalR home page on GitHub: https://github.com/aspnet/SignalR
* SignalR for ASP.NET Core 2.0: https://blogs.msdn.microsoft.com/webdev/2017/09/14/announcing-signalr-for-asp-net-core-2-0/
* SignalR with Windows authentication: http://msharonov.blogspot.com/2017/10/signalr-windows-authentication.html
* Swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio
