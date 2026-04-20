using Microsoft.AspNetCore.Mvc;
using TiendaVirtualReyes.Data;
using TiendaVirtualReyes.Models;

namespace TiendaVirtualReyes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly TiendaContext _context;

        public UsuarioController(TiendaContext context)
        {
            _context = context;
        }

        // Listado de usuarios
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("index", "Login");
            }
            return View(_context.usuarios.ToList());
        }

        // Formulario Crear (GET)
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("index", "Login");
            }
            return View();
        }

        // Guardar Usuario (POST)
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("index", "Login");
            }
            if (ModelState.IsValid)
            {
                _context.usuarios.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(usuario);
        }

        // Formulario Editar (GET)
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("index", "Login");
            }
            var usuario = _context.usuarios.Find(id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // Guardar cambios (POST)
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("index", "Login");
            }
            if (ModelState.IsValid)
            {
                _context.usuarios.Update(usuario);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(usuario);
        }

        // Eliminar Usuario
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("index", "Login");
            }
            var usuario = _context.usuarios.Find(id);
            if (usuario != null)
            {
                _context.usuarios.Remove(usuario);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}