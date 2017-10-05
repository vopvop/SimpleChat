using System;
using Microsoft.AspNetCore.Http;
using SimpleChat.Models;

namespace SimpleChat.Utils
{
	internal sealed class UserInfoProvider: IUserInfoProvider
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserInfoProvider(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor
				?? throw new ArgumentNullException(nameof(httpContextAccessor));
		}

		public UserInfoModel Get()
		{
			var userIdentity = _httpContextAccessor.HttpContext.User.Identity;

			if (!userIdentity.IsAuthenticated)
				throw new UnauthorizedAccessException();

			return new UserInfoModel(userIdentity.Name);
		}
	}
}