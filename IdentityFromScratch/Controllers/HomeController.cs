using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityFromScratch.Models;
using IdentityFromScratch.Services;
using Microsoft.AspNetCore.Authorization;

namespace IdentityFromScratch.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRoleManagerService _roleManagerService;

    public HomeController(ILogger<HomeController> logger, IRoleManagerService roleManagerService)
    {
        _logger = logger;
        _roleManagerService = roleManagerService;
    }

    public async Task<IActionResult> Index()
    {
        await SeedRoles();
        return View();
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task SeedRoles()
    {
        await _roleManagerService.EnsureRoleExistsAsync("Admin");
        await _roleManagerService.EnsureRoleExistsAsync("Member");
    }
}