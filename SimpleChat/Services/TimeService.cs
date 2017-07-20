namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	internal sealed class TimeService: ITimeService
	{
		public async Task<DateTime> GetUtc() => await Task.Run(() => DateTime.UtcNow);
	}
}