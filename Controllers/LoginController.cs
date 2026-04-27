using Microsoft.AspNetCore.Mvc;
using TiendaVirtualReyes.Data;
using TiendaVirtualReyes.Models;
using System.Linq;
using TiendaVirtualReyes.Helpers;
namespace TiendaVirtualJojoa.Controllers
{
    public class LoginController : Controller
    {
        private readonly TiendaContext _context;
        public LoginController(TiendaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string correo, string clave)
        {
            string claveHash = HashHelpers.ObtenerHash(clave);
            var usuario = _context.usuarios
                .FirstOrDefault(u => u.Correo == correo && u.clave == claveHash);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Nombre);
                HttpContext.Session.SetString("Rol", usuario.Rol);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
