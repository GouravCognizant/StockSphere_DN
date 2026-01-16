using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockSphere.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string role)
        {
            // Defaults to "User" if no role is specified
            ViewBag.Role = role ?? "User";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password, string role)
        {
            bool isAuthenticated = false;

            // 1. CREDENTIALS CHECK (Hardcoded for demo)
            if (role == "Admin" && email == "admin@stocksphere.com" && password == "Admin123")
                isAuthenticated = true;
            else if (role == "Compliance" && email == "comp@stocksphere.com" && password == "Comp123")
                isAuthenticated = true;
            else if (role == "User" && email == "user@stocksphere.com" && password == "User123")
                isAuthenticated = true;

            if (isAuthenticated)
            {
                // 2. CREATE CLAIMS
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, email),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60)
                };

                // 3. SIGN IN
                await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

                // 4. REDIRECT BASED ON ROLE
                // Maps role "User" to Area "User", "Compliance" to Area "Compliance", etc.
                return RedirectToAction("Index", "Dashboard", new { area = role });
            }

            // 5. IF CREDENTIALS FAIL
            ModelState.AddModelError("", $"Invalid email or password for {role} access.");
            ViewBag.Role = role;
            return View();
        }

        // Updated Logout to handle both GET (from links) and POST (from forms)
        [HttpGet, HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Clears the authentication cookie defined in Program.cs
            await HttpContext.SignOutAsync("CookieAuth");

            // Redirects to Login with a default role
            return RedirectToAction("Login", "Account", new { role = "User" });
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View();
            }

            // For now, redirect to login after "successful" registration
            TempData["Success"] = "Registration successful! Please login.";
            return RedirectToAction("Login", "Account", new { role = "User" });
        }
    }
}