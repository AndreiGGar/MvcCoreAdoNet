using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;

        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }

        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
        public IActionResult Detalles(int idhospital)
        {
            Hospital hospital = this.repo.FindHospital(idhospital);
            return View(hospital);
        }
        public IActionResult NewHospital()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewHospital(Hospital hospital)
        {
            this.repo.CreateHospital(hospital.idHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital insertado";
            return View();
        }
    }
}
