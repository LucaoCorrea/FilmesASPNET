using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using Movies.Services;
namespace Movies.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFilmeService _filmeService;
    public HomeController(ILogger<HomeController> logger, IFilmeService filmeService)
    {
        _logger = logger;
        _filmeService = filmeService;
    }
    public IActionResult Index(string tipo)
    {
        var movie = _filmeService.GetMoviesDto();
        ViewData["filter"] = string.IsNullOrEmpty(tipo) ? "all" : tipo;
        return View(movie);
    }
    public IActionResult Details(int Numero)
    {
        var filme = _filmeService.GetDetailedFilme(Numero);
        return View(filme);
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id
        ?? HttpContext.TraceIdentifier
        });
    }
}