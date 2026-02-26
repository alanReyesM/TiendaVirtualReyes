using Microsoft.AspNetCore.Mvc;
using TiendaVirtualReyes.Models;

namespace TiendaVirtualReyes.Controllers
{
    public class PorductoController : Controller
    {
        public IActionResult Index()
        {
            var productos = new List<Producto>
            {
                new Producto { Id = 1,Nombre="Laptop",Precio= 3000, Stock=5 },
                new Producto { Id = 2,Nombre="Mouse", Precio=80, Stock=5 }
            };
            return View(productos);
        }
    }
}
