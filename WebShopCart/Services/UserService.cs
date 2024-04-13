using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;
using WebShopCart.Models;

namespace WebShopCart.Services
{
	public class UserService
	{
		public Boolean isPasswordSame(string password, string confirmPassword)
		{
			if (password == confirmPassword)
			{
				return true;
			}
			return false;
		}

		public User createUser(UserRegistrationModel registerUser, string userId)
		{

			User user = new User();
			user.user_id = userId;
			user.user_name = registerUser.user_name;
			user.role = "Regular User";
			user.created_at = DateTime.Now.ToString();

			return user;
		}

		public UserIdentity createUserIdentity(UserRegistrationModel registerUser, string userId)
		{

			UserIdentity userIdentity = new UserIdentity();
			//Hash password from user before storing in database!
			userIdentity.password = hashPassword(registerUser.user_name, registerUser.password);
			userIdentity.user_id = userId;
			userIdentity.email = registerUser.email;
			userIdentity.user_name = registerUser.user_name;

			return userIdentity;
		}

		public string hashPassword(string userName, string password)
		{
			PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
			string hashedPassword = passwordHasher.HashPassword(userName, password);
			return hashedPassword;
		}

		public Boolean verifyUserIdentity(string userName, string dbPassword, string password)
		{
			Boolean loggedIn;

			PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
			var verificationResult = passwordHasher.VerifyHashedPassword(userName, dbPassword, password);

			if (verificationResult == PasswordVerificationResult.Success)
				loggedIn = true;
			else
				loggedIn = false;
			return loggedIn;
		}
	}
}
