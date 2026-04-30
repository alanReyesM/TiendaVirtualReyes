using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualReyes.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio")]
        public string Rol { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        [RegularExpression(@"^3\d{9}$", ErrorMessage = "El celular debe empezar por 3 y tener 10 dígitos")]
        public string celular { get; set; }

        [Required(ErrorMessage = "La clave es obligatoria")]
        [MinLength(4, ErrorMessage = "minimo 4 caracteres")]
        public string clave { get; set; }
    }
}