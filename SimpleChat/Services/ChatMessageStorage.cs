namespace SimpleChat.Services
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using SimpleChat.Models;

	internal sealed class ChatMessageStorage: IChatMessageStorage
	{
		private readonly IChatMessageIdGenerator _chatMessageIdGenerator;

		private readonly ConcurrentQueue<ChatMessageModel> _messageQueue = new ConcurrentQueue<ChatMessageModel>();

		public ChatMessageStorage(IChatMessageIdGenerator chatMessageIdGenerator)
		{
			_chatMessageIdGenerator = chatMessageIdGenerator ?? throw new ArgumentNullException(nameof(chatMessageIdGenerator));
		}

		public async Task<IEnumerable<ChatMessageModel>> Pull() =>
			await Task.Factory.StartNew(() => _messageQueue.AsEnumerable());

		public async Task Push(ChatMessageModel chatMessage)
		{
			if (chatMessage == null) throw new ArgumentNullException(nameof(chatMessage));

			chatMessage.Id = await _chatMessageIdGenerator.GetNext();

			_messageQueue.Enqueue(chatMessage);
		}
	}
}