using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductApp.ProductAppData.Context;
using ProductApp.ProductAppData.DataModel;
using ProductApp.ProductAppData.ViewModels;

namespace ProductApp.Controllers;

public class AuthController : Controller
{
    private readonly ProductAppDbContext _context;

    public AuthController(ProductAppDbContext context)
    {
        _context = context;
    }
// Login page action
    [HttpGet]
    public IActionResult Login()
    {
        if (HttpContext.Session.GetString("AuthToken").IsNullOrEmpty())
        {
            return View();
        }

        return new RedirectToActionResult("Index","Home",null);
    }

// Login form submission action
    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        // Validate user's credentials
        var user = _context.Users.SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
        if (user == null)
        {
            ModelState.AddModelError("", "Invalid email or password.");
            return View(model);
        }

        // Generate authentication token
        var token = GenerateAuthToken();

        // Save token in session or cookie
        HttpContext.Session.SetString("AuthToken", token);
        HttpContext.Session.SetString("IsLoggedIn", "true");

        // Redirect to dashboard or home page
        return RedirectToAction("Index", "Home");
    }


// Generate a cryptographically secure authentication token
    private static string GenerateAuthToken()
    {
        var bytes = new byte[64];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(bytes);
        }
        return Convert.ToBase64String(bytes);
    }
}