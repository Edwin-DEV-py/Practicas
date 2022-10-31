using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage ="Campo Obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string? Correo { get; set; }
    }
}
