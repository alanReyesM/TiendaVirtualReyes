using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualReyes.Data;
using TiendaVirtualReyes.Models;

namespace TiendaVirtualReyes.Controllers
{
    public class ProductoController : Controller
    {
        private readonly TiendaContext _context;
        public ProductoController(TiendaContext context)
        {
            _context = context;
        }
        public IActionResult index()
        {
            var productos = _context.productos
                .Include(p => p.Categoria)
                .ToList();

            return View(productos);
        }
    }
}
