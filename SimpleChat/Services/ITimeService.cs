namespace SimpleChat.Services
{
	using System;
	using System.Threading.Tasks;

	public interface ITimeService
	{
		Task<DateTime> GetUtc();
	}
}