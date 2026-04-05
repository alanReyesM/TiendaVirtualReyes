using Microsoft.AspNetCore.Mvc;
using TiendaVirtualReyes.Data; // Conexión a tu DB
using TiendaVirtualReyes.Models;

namespace TiendaVirtualReyes.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly TiendaContext _context;

        // Constructor para conectar la base de datos
        public CategoriaController(TiendaContext context)
        {
            _context = context;
        }

        // Listado de categorías reales
        public IActionResult index()
        {
            var listaCategorias = _context.categorias.ToList();
            return View(listaCategorias);
        }

        // Formulario Crear (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Guardar Nueva Categoría (POST)
        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid) // Revisa las reglas [Required] del modelo
            {
                _context.categorias.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(categoria);
        }

        // Formulario Editar (GET)
        public IActionResult Edit(int id)
        {
            var categoria = _context.categorias.Find(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        // Guardar Cambios (POST)
        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.categorias.Update(categoria);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(categoria);
        }

        // Eliminar Categoría
        public IActionResult Delete(int id)
        {
            var categoria = _context.categorias.Find(id);
            if (categoria != null)
            {
                _context.categorias.Remove(categoria);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}