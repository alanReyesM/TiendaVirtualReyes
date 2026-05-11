using System.ComponentModel.DataAnnotations; // Necesario para las etiquetas de validación
namespace TiendaVirtualReyes.Models
{
    public class CarritoItem
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        
    }
}