namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	using Microsoft.AspNetCore.SignalR.Infrastructure;

	using SimpleChat.Hubs;
	using SimpleChat.Models;

	internal sealed class NotificationService: INotificationService
	{
		private readonly IConnectionManager _connectionManager;

		public NotificationService(IConnectionManager connectionManager)
		{
			_connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager));
		}

		public async Task Push(ChatMessageModel chatMessage)
		{
			await _connectionManager.GetHubContext<ChatHub>().Clients.All.Send(chatMessage);
		}
	}
}