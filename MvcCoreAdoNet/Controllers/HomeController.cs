using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contenido()
        {
            return View();
        }

        public IActionResult VistaMascota()
        {
            Mascota mascota = new Mascota();
            mascota.Nombre = "Wolf";
            mascota.Raza = "Hasky";
            return View(mascota);
        }
    }
}
