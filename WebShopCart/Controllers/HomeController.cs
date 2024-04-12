using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShopCart.Models;

namespace WebShopCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Login()
		{
			return View();
		}

		public IActionResult ProductDetails()
		{
			return View();
		}

		public IActionResult Products()
		{
			return View();
		}

		public IActionResult BlogList()
		{
			return View();
		}

		public IActionResult BlogSingle()
		{
			return View();
		}

		public IActionResult Cart()
		{
			return View();
		}

		public IActionResult CheckOut()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

/*        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
