using System;
using System.Threading.Tasks;

namespace SimpleChat.Services
{
	internal interface IChatMessageIdGenerator
	{
		Task<Guid> GetNextAsync();
	}
}