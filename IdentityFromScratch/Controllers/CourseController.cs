using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityFromScratch.Controllers;

[Authorize(Roles = "Member")]
public class CourseController : Controller
{
    
    public IActionResult Index()
    {
        return View();
    }
}