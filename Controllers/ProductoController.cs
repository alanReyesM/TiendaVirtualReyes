using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualReyes.Data;
using TiendaVirtualReyes.Models;

namespace TiendaVirtualReyes.Controllers
{
    public class ProductoController : Controller
    {
        private readonly TiendaContext _context; //conexio con la db
        public ProductoController(TiendaContext context)
        {
            _context = context;
        }
        public IActionResult index()
        {
            var productos = _context.productos
                .Include(p => p.Categoria)  // hereda de categoria 
                .ToList(); // slect * from

            return View(productos);
        }
    }
}
