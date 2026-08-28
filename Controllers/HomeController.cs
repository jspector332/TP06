using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tp06.Models;

namespace tp06.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult irASala1()
    {
        redirecttoaction("salaCodigoCesar")
    }
    bd bd = new bd();
    codigoCesar codigo = new codigoCesar;
    public IActionResult salaCodigoCesar()
    {   codigo.corrimiento=5;
        codigo.letra=bd.mensajeCodigo();
        ViewBag.mensajeEncriptado = codigo.codigo();
        return View();
    }

     public IActionResult verificarCodigoC(string input)
    {
       if(msj == input) 
        
        return View();
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
