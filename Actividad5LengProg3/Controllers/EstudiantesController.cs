using Actividad5LengProg3.Data;
using Actividad5LengProg3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Actividad5LengProg3.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void CargarCombos()
        {
            ViewBag.Carreras = new SelectList(_context.Carreras.ToList(), "Id", "Nombre");
            ViewBag.Recintos = new SelectList(_context.Recintos.ToList(), "Id", "Nombre");
        }

        public IActionResult Index()
        {
            CargarCombos();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            _context.SaveChanges();
            return RedirectToAction("Lista");


        }
        public IActionResult Lista()
        {
            var lista = _context.Estudiantes
                .Include(e => e.Carrera)
                .Include(e => e.Recinto)
                .ToList();

            return View(lista);
        }


        public IActionResult Editar(string matricula)
        {
            var estudiante = _context.Estudiantes
                .FirstOrDefault(e => e.Matricula == matricula);

            if (estudiante == null) return NotFound();

            ViewBag.Carreras = new SelectList(_context.Carreras.ToList(), "Id", "Nombre", estudiante.CarreraId);
            ViewBag.Recintos = new SelectList(_context.Recintos.ToList(), "Id", "Nombre", estudiante.RecintoId);

            return View(estudiante);
        }



        [HttpPost]
        public IActionResult Editar(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                return RedirectToAction("Lista");
            }


            CargarCombos();
            return View("Index", estudiante);
        }

        public IActionResult Eliminar(string matricula)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.Matricula == matricula);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
            }

            return RedirectToAction("Lista");
        }
    }
}
