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
        return RedirectToAction("salaSimon");
    }

    public IActionResult salaSimon(){
        return View();
    }

    public IActionResult irASala3()
    {
        return RedirectToAction("salaBird");
    }

    public IActionResult salaBird(){
        return View();
    }

    public IActionResult irASala4()
    {
        return RedirectToAction("salaTrivia");
    }

    public IActionResult salaTrivia(int id = 1){
        
        ViewBag.pregunta1 = bd.obtenerPregunta(1);
        ViewBag.pregunta2 = bd.obtenerPregunta(2);
        ViewBag.pregunta3 = bd.obtenerPregunta(3);
        // mostrar una pregunta a la vez; id indica cuál mostrar (1..3)
        ViewBag.pregunta = bd.obtenerPregunta(id);
        ViewBag.idPregunta = id;
        return View();
    }

    // recibe una sola respuesta y el id de la pregunta actual
    public IActionResult VerificarTrivia(string respuesta, int idPregunta){
        var correcta = bd.obtenerRespuesta(idPregunta);
        // comparar trim + case-insensitive para evitar fallos por mayúsculas/espacios
        if (!string.IsNullOrEmpty(respuesta) && !string.IsNullOrEmpty(correcta) &&
            string.Equals(respuesta.Trim(), correcta.Trim(), StringComparison.OrdinalIgnoreCase))
        {
            if (idPregunta < 3) return RedirectToAction("salaTrivia", new { id = idPregunta + 1 });
            return RedirectToAction("salaFinal");
        }
        return RedirectToAction("irASala3");
    }

    public IActionResult salaFinal(){
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
