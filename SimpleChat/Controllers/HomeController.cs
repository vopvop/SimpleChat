using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBasic.Controllers
{
	public class HomeController: Controller
	{
		public IActionResult Index() => View();

		public IActionResult Error() => View();
	}
}