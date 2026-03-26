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

        //formulario crear
        public IActionResult Create()
        {
            return View();
        }

        //guardar productos
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _context.productos.Add(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //formulario editar
        public IActionResult Edit(int id)
        {
            // 1. Buscas el producto que vas a editar
            var producto = _context.productos.Find(id);

            // 2. ¡ESTA ES LA LÍNEA CLAVE! 
            // Debes traer las categorías de la DB para que el ViewBag no sea nulo
            ViewBag.Categorias = _context.categorias.ToList();

            // 3. Envías el producto a la vista
            return View(producto);
        }

        //actualizar producto 
        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            _context.productos.Update(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Eliminar producto 
        public IActionResult Delete (int id)
        {
            var produco = _context.productos.Find(id);

            _context.productos.Remove(produco);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
