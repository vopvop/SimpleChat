using System;
using System.Threading.Tasks;

namespace SimpleChat.Services
{
	internal sealed class ChatMessageIdGenerator : IChatMessageIdGenerator
	{
		public async Task<Guid> GetNextAsync() => await Task.Factory.StartNew(Guid.NewGuid);
	}
}