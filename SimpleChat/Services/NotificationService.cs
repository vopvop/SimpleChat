using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

using SimpleChat.Hubs;
using SimpleChat.Models;

namespace SimpleChat.Services
{
	internal sealed class NotificationService : INotificationService
	{
		private readonly IHubContext<ChatHub> _context;

		public NotificationService(IHubContext<ChatHub> context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task PushAsync(ChatMessageModel chatMessage)
		{
			await _context.Clients.All.SendAsync("Send", chatMessage);
		}
	}
}