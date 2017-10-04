namespace SimpleChat.Services
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using SimpleChat.Models;

	internal sealed class ChatService: IChatService
	{
		private readonly IChatMessageStorage _chatMessageStorage;

		private readonly INotificationService _notificationService;

		private readonly ITimeService _timeService;

		public ChatService(
			IChatMessageStorage chatMessageStorage,
			INotificationService notificationService,
			ITimeService timeService)
		{
			_chatMessageStorage = chatMessageStorage ?? throw new ArgumentNullException(nameof(chatMessageStorage));
			_notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
			_timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
		}

		public async Task<IEnumerable<ChatMessageModel>> Get() =>
			await _chatMessageStorage.GetAll();

		public async Task<ChatMessageModel> Get(Guid messageUid) =>
			await _chatMessageStorage.Get(messageUid);

		public async Task<ChatMessageModel> Send(string message)
		{
			var currentDateTimeUtc = await _timeService.GetUtc();

			var chatMessage = new ChatMessageModel(message, currentDateTimeUtc);

			await _chatMessageStorage.Push(chatMessage);

			await _notificationService.Push(chatMessage);

			return chatMessage;
		}
	}
}