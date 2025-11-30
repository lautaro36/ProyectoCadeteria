using Microsoft.AspNetCore.Mvc;
using ProyectoCadeteria.Models;
using ProyectoCadeteria.Repositories;

public class CadeteriaController : Controller
{
    private readonly ICadeteriaRepository _cadeteriaRepository;
    private readonly ICadeteRepository _cadeteRepository;

    public CadeteriaController(ICadeteriaRepository cadeteriaRepository, ICadeteRepository cadeteRepository)
    {
        _cadeteriaRepository = cadeteriaRepository;
        _cadeteRepository = cadeteRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
        
        return View();
    }
}