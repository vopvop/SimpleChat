namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.SignalR;

	using SimpleChat.Hubs;
	using SimpleChat.Models;


	internal sealed class NotificationService: INotificationService
	{
		private readonly IHubContext<ChatHub> _context;

		public NotificationService(IHubContext<ChatHub> context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task Push(ChatMessageModel chatMessage) =>
			await _context.Clients.All.InvokeAsync("Send", chatMessage);
	}
}