namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	internal interface IChatMessageIdGenerator
	{
		Task<Guid> GetNext();
	}
}