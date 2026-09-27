using System.ComponentModel.DataAnnotations;

namespace ClientesBlazorApp.Models
{
    public class Cliente
    {
        public int Id_cliente { get; set; }

        [Required(ErrorMessage = "El CUI es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string CUI { get; set; } = string.Empty;

        [Required(ErrorMessage = "El NIT es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string NIT { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime Fecha_Nacimiento { get; set; } = DateTime.Today.AddYears(-18);
    }
}