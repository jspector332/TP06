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
        return RedirectToAction("salaCodigoCesar");
    }
    BD bd = new BD();
    codigoCesar codigo = new codigoCesar();
    public IActionResult salaCodigoCesar()
    {   
        codigo.corrimiento=5;
        codigo.letra=bd.mensajeCodigo();
        ViewBag.mensajeEncriptado = codigo.codigo();
        ViewBag.mensajeOriginal = codigo.letra;
        return View();
    }

    public IActionResult verificarCodigoC(string input, string msj)
    {
        Console.WriteLine(msj);
        if(msj == input.ToUpper()){
            return RedirectToAction("irASala2");
        }
        else{
            return RedirectToAction("index");
        }
    }

    public IActionResult irASala2()
    {
        return RedirectToAction("salaSimon"); //https://github.com/Khairul25556/simon-game/tree/main
    }

    public IActionResult salaSimon(){
        return View();
    }

    public IActionResult irASala3()
    {
        return RedirectToAction("Index");
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
