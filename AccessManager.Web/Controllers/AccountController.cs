

using AccessManager.Core.Interfaces;
using Model;

using AccessManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccessManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public JsonResult Register([FromForm] RegistrationViewModel model)
        {
            if (model == null) return Json(new { success = false, message = "Invalid request data." });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return Json(new { success = false, message = string.Join(", ", errors) });
            }

            if (_userRepository.GetUserByEmail(model.Email) != null)
                return Json(new { success = false, message = "Email already exists." });

            if (_userRepository.GetUserByUsername(model.UserName) != null)
                return Json(new { success = false, message = "Username already exists." });

            if (model.Password != model.ConfirmPassword)
                return Json(new { success = false, message = "Passwords do not match." });

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var newUser = new UserAccount
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                Password = hashedPassword
            };

            _userRepository.AddUser(newUser);
            _userRepository.SaveChanges();

            return Json(new
            {
                success = true,
                message = "Registration successful",
                redirectUrl = Url.Action("Login", "Account")
            });
        }

        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public JsonResult Login([FromForm] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return Json(new { success = false, message = string.Join(", ", errors) });
            }

            var user = _userRepository.GetUserByUsername(model.UserName);

            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                HttpContext.Session.SetString("UserName", user.UserName);

                return Json(new
                {
                   success = true,
                    message = "Login successful",
                    redirectUrl = Url.Action("Dashboard", "Home")
                });
            }

            return Json(new { success = false, message = "Invalid username or password" });
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
