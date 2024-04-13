using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using WebShopCart.Data;
using WebShopCart.Models;
using WebShopCart.Services;

namespace WebShopCart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDBContext _context;

		private static UserRegistrationModel userLoggedIn;
		private UserService service;

        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
			service = new UserService();
        }

        public IActionResult Index(UserRegistrationModel user)
        {
			if (user == null)
			{
                return View();
            }
			else
			{
				//UserService.ValidateUser();
				return View(userLoggedIn);
			}
            
        }

		public IActionResult Login(UserIdentity user)
		{
			if (string.IsNullOrEmpty(user.user_name))
			{
                return View();
            }

			var queryResults = _context.User_Identity.
									Where(u => u.user_name == user.user_name).
									ToList();

			UserIdentity userIdentity = queryResults[0];

			Boolean userAvailable = service.verifyUserIdentity(userIdentity.user_name, userIdentity.password, user.password);
			if (userAvailable)
			{
				if (userLoggedIn == null)
					userLoggedIn = new UserRegistrationModel();
				userLoggedIn.user_name = user.user_name;
			}

			return RedirectToAction("Index");
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

		
		public IActionResult SignUp() 
		{
			return View();
		}

        [HttpPost]
        public IActionResult RegisterUser(UserRegistrationModel registerUser)
        {

            if (!ModelState.IsValid)
            {
				// Handle validation errors
				if (!service.isPasswordSame(registerUser.password, registerUser.confirmPassword))
					return RedirectToAction("SignUp");
            }

            string userId = "user-" + Guid.NewGuid().ToString();
			User user = service.createUser(registerUser, userId);
			UserIdentity userIdentity = service.createUserIdentity(registerUser, userId);

			//Save to DB
            _context.Add(user);
            _context.Add(userIdentity);
            _context.SaveChanges();

			//Auto log in if user registration is confirmed
			if (userLoggedIn == null)
				userLoggedIn = new UserRegistrationModel();

			userLoggedIn.user_name = registerUser.user_name;
			return RedirectToAction("Index");
        }
    }
}
