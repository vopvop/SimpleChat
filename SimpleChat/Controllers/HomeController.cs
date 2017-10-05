using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBasic.Controllers
{
	/// <summary>
	/// Default controller
	/// </summary>
	[Authorize]
	public class HomeController: Controller
	{
		/// <summary>
		/// Get default page
		/// </summary>
		/// <returns>Default page</returns>
		public IActionResult Index() => View();

		/// <summary>
		/// Get error page
		/// </summary>
		/// <returns>Error page</returns>
		public IActionResult Error() => View();
	}
}