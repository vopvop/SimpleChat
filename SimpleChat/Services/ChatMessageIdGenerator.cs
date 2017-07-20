namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	internal sealed class ChatMessageIdGenerator: IChatMessageIdGenerator
	{
		public async Task<Guid> GetNext() => await Task.Factory.StartNew(() => Guid.NewGuid());
	}
}