using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoCadeteria.Models;
using ProyectoCadeteria.Repositories;
using ProyectoCadeteria.ViewModels;

namespace ProyectoCadeteria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICadeteriaRepository _cadeteriaRepository;

    public HomeController(ILogger<HomeController> logger, ICadeteriaRepository cadeteriaRepository)
    {
        _logger = logger;
        _cadeteriaRepository = cadeteriaRepository;
    }

    public IActionResult Index()
    {
        Cadeteria model = _cadeteriaRepository.Get();
        return View(new IndexCadeteriaVM(model));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
