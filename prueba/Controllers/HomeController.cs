using Microsoft.AspNetCore.Mvc;
using prueba.Models;
using System.Diagnostics;
using prueba.Datos;

namespace prueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        UsuarioDatos _UsuarioDatos = new UsuarioDatos();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Ingresar()
        {
            return View();
        }

        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var Lista = _UsuarioDatos.Listar();

            return View(Lista);
        }

        [HttpPost]
        public IActionResult Ingresar(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            var rta = _UsuarioDatos.Guardar(usuario);

            if(rta)
                return RedirectToAction("Index");
            else
                return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}