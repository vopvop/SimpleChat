using System.Threading.Tasks;

using SimpleChat.Models;

namespace SimpleChat.Services
{
	internal interface INotificationService
	{
		Task PushAsync(ChatMessageModel chatMessage);
	}
}