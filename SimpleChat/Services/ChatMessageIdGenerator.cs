namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	internal sealed class ChatMessageIdGenerator: IChatMessageIdGenerator
	{
		public async Task<Guid> GetNext()
		{
			return await Task.Run(() => Guid.NewGuid());
		}
	}
}