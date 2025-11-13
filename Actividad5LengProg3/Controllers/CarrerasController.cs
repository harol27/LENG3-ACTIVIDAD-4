using Actividad5LengProg3.Data;
using Actividad5LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Actividad5LengProg3.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarrerasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Carreras.ToList();
            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Carrera model)
        {
            if (ModelState.IsValid)
            {
                _context.Carreras.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Editar(int id)
        {
            var carrera = _context.Carreras.Find(id);
            if (carrera == null) return NotFound();
            return View(carrera);
        }

        [HttpPost]
        public IActionResult Editar(Carrera model)
        {
            if (ModelState.IsValid)
            {
                _context.Carreras.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Eliminar(int id)
        {
            var carrera = _context.Carreras.Find(id);
            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
