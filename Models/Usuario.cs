using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Proyecto_P1.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [DisplayName("Nombre")]
        [NotNull]
        public string? Name { get; set; }

        [Required]
        [DisplayName("Numero de Teléfono")]
        [NotNull]
        [StringLength(10)]
        public string? Telefono { get; set; }
        [Required]
        [DisplayName("Ingrese tu correo")]
        [NotNull]
        public string? Correo { get; set; }
        [Required]
        [Compare(nameof(Correo), ErrorMessage = "Los correos no coinciden")]
        public string? VerificarCorreo { get; set; }
        public string? Contraseña { get; set; }
        [Required]
        [Compare(nameof(Contraseña), ErrorMessage = "Las contraseñas no coninciden")]
        public string? VerificarContraseña { get; set; }
    }
}
