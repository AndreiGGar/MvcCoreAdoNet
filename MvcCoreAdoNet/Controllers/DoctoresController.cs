using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        private RepositoryDoctor repo;

        public DoctoresController()
        {
            this.repo = new RepositoryDoctor();
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctores();
            List<string> especialidades = this.repo.GetEspecialidades();
            Doctors DoctorsModel = new Doctors
            {
                Doctores = doctores,
                Especialidades = especialidades
            };
            return View(DoctorsModel);
        }

        [HttpPost]
        public IActionResult Index(string especialidad)
        {
            List<Doctor> doctores = new List<Doctor>();
            if (string.IsNullOrEmpty(especialidad))
            {
                doctores = this.repo.GetDoctores();
            }
            else
            {
                doctores = this.repo.GetDoctoresEspecialidad(especialidad);
            }
            List<string> especialidades = this.repo.GetEspecialidades();
            Doctors DoctorsModel = new Doctors
            {
                Doctores = doctores,
                Especialidades = especialidades
            };
            ViewData["MENSAJE"] = "Refreshed";
            return View(DoctorsModel);
        }
        /*public IActionResult Index(string especialidad)
        {
            List<Doctor> doctores = new List<Doctor>();
            if (string.IsNullOrEmpty(especialidad))
            {
                doctores = this.repo.GetDoctores();
            } else
            {
                doctores = this.repo.GetDoctoresEspecialidad(especialidad);
            }
            List<string> especialidades = this.repo.GetEspecialidades();
            Doctors DoctorsModel = new Doctors
            {
                Doctores = doctores,
                Especialidades = especialidades
            };
            ViewData["MENSAJE"] = "Refreshed";
            return View(DoctorsModel);
        }*/
    }
}
