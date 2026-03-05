using Microsoft.AspNetCore.Mvc;
using TiendaVirtualReyes.Models;
namespace TiendaVirtualReyes.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            var categorias = new List<Categoria>
            {
                new Categoria { Id = 1,Nombre="mauro",Descripcion="amable" },
                new Categoria { Id = 2,Nombre="leo", Descripcion="amable" },
                new Categoria { Id = 0,Nombre="", Descripcion="" }
            };
            return View(categorias);
        }
    }
}
