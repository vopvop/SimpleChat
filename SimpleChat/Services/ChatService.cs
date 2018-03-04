using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SimpleChat.Models;
using SimpleChat.Utils;

namespace SimpleChat.Services
{
	internal sealed class ChatService : IChatService
	{
		private readonly IChatMessageStorage _chatMessageStorage;

		private readonly INotificationService _notificationService;

		private readonly ITimeService _timeService;

		private readonly IUserInfoProvider _userInfoProvider;

		public ChatService(
			IChatMessageStorage chatMessageStorage,
			INotificationService notificationService,
			ITimeService timeService,
			IUserInfoProvider userInfoProvider)
		{
			_chatMessageStorage = chatMessageStorage ?? throw new ArgumentNullException(nameof(chatMessageStorage));
			_notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
			_timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
			_userInfoProvider = userInfoProvider ?? throw new ArgumentNullException(nameof(userInfoProvider));
		}

		public async Task<IReadOnlyCollection<ChatMessageModel>> GetAllAsync() => await _chatMessageStorage.GetAllAsync();

		public async Task<ChatMessageModel> GetAsync(Guid messageUid) => await _chatMessageStorage.GetAsync(messageUid);

		public async Task<ChatMessageModel> SendAsync(string message)
		{
			var currentDateTimeUtc = _timeService.GetUtc();

			var user = _userInfoProvider.Get();

			var chatMessage = new ChatMessageModel(message, currentDateTimeUtc, user);

			await _chatMessageStorage.PushAsync(chatMessage);

			await _notificationService.PushAsync(chatMessage);

			return chatMessage;
		}
	}
}