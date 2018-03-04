using System;

namespace SimpleChat.Services
{
	public interface ITimeService
	{
		DateTime GetUtc();
	}
}