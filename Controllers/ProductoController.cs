using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaVirtualReyes.Data;
using TiendaVirtualReyes.Models;
using System.Linq; // Necesario para los filtros .Where

namespace TiendaVirtualReyes.Controllers
{
    public class ProductoController : Controller
    {
        private readonly TiendaContext _context; //conexion con la db
        public ProductoController(TiendaContext context)
        {
            _context = context;
        }
        public IActionResult index()
        {
            var productos = _context.productos
                .Include(p => p.Categoria)  // hereda de categoria 
                .Where(p => p.Categoria.Estado == "Activo") // Filtro: Oculta productos de categorías inactivas
                .ToList(); // slect * from

            return View(productos);
        }

        // 1. FORMULARIO CREAR (GET)
        public IActionResult Create()
        {
            //categorías de la base de datos para el menú desplegable
            // Filtro: Solo muestra categorías activas en el selector
            ViewBag.Categorias = _context.categorias.Where(c => c.Estado == "Activo").ToList();
            return View();
        }

        // Recibe los datos y los guarda
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            // A. Validar exista en la tabla categorias
            var existeCategoria = _context.categorias.Any(c => c.Id == producto.CategoriaId);

            if (!existeCategoria)
            {
                ModelState.AddModelError("CategoriaId", "seleccionar categoria valida");
            }

            // B. Si el modelo es válido ( nombre, precio, etc)
            if (ModelState.IsValid)
            {
                _context.productos.Add(producto);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            // Filtro: Recarga solo las categorías activas si el formulario falla
            ViewBag.Categorias = _context.categorias.Where(c => c.Estado == "Activo").ToList();
            return View(producto);
        }

        //formulario editar
        public IActionResult Edit(int id)
        {
            // 1. Buscas el producto que vas a editar
            var producto = _context.productos.Find(id);

            // traer las categorías para que ViewBag
            // Filtro: Evita mover productos a categorías inactivas
            ViewBag.Categorias = _context.categorias.Where(c => c.Estado == "Activo").ToList();

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

        // Eliminar producto 
        public IActionResult Delete(int id)
        {
            // 1. Buscamos el producto por su ID
            var producto = _context.productos.Find(id);

            if (producto != null)
            {
                _context.productos.Remove(producto);
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
