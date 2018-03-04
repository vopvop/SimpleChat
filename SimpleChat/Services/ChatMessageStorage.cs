using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SimpleChat.Models;

namespace SimpleChat.Services
{
	internal sealed class ChatMessageStorage : IChatMessageStorage
	{
		private readonly IChatMessageIdGenerator _chatMessageIdGenerator;

		private readonly ConcurrentQueue<ChatMessageModel> _messageQueue = new ConcurrentQueue<ChatMessageModel>();

		public ChatMessageStorage(IChatMessageIdGenerator chatMessageIdGenerator)
		{
			_chatMessageIdGenerator = chatMessageIdGenerator ?? throw new ArgumentNullException(nameof(chatMessageIdGenerator));
		}

		public Task<IReadOnlyCollection<ChatMessageModel>> GetAllAsync()
		{
			return Task.FromResult((IReadOnlyCollection<ChatMessageModel>) _messageQueue);
		}

		public Task<ChatMessageModel> GetAsync(Guid messageUid)
		{
			return Task.Factory.StartNew(() => _messageQueue.SingleOrDefault(_ => _.Id == messageUid));
		}

		public async Task PushAsync(ChatMessageModel chatMessage)
		{
			if (chatMessage == null)
				throw new ArgumentNullException(nameof(chatMessage));

			chatMessage.Id = await _chatMessageIdGenerator.GetNextAsync();

			_messageQueue.Enqueue(chatMessage);
		}
	}
}