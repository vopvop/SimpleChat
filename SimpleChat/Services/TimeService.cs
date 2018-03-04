using System;

namespace SimpleChat.Services
{
	internal sealed class TimeService : ITimeService
	{
		public DateTime GetUtc()
		{
			return DateTime.UtcNow;
		}
	}
}