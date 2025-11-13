using Actividad5LengProg3.Data;
using Actividad5LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Actividad5LengProg3.Controllers
{
    public class RecintosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecintosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lista = _context.Recintos.ToList();
            return View(lista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Recinto model)
        {
            if (ModelState.IsValid)
            {
                _context.Recintos.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Editar(int id)
        {
            var recinto = _context.Recintos.Find(id);
            if (recinto == null) return NotFound();
            return View(recinto);
        }

        [HttpPost]
        public IActionResult Editar(Recinto model)
        {
            if (ModelState.IsValid)
            {
                _context.Recintos.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Eliminar(int id)
        {
            var recinto = _context.Recintos.Find(id);
            if (recinto != null)
            {
                _context.Recintos.Remove(recinto);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
