using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityFromScratch.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}