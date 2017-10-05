using SimpleChat.Models;

namespace SimpleChat.Utils
{

	public interface IUserInfoProvider
	{
		UserInfoModel Get();
	}
}