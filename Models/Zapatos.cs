using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_P1.Models
{
    public class Zapatos
    {
        [Key]
        public int IdZapatos { get; set; }

        public int? IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Ingrese la marca")]
        public string? Marca { get; set; }
        [Required]
        [StringLength(15)]
        [DisplayName("Ingrese el modelo")]
        [NotNull]
        public string? Modelo { get; set; }
        [Required]
        [NotNull]
        [DisplayName("Ingrese el precio")]
        [Range(1, 1000, ErrorMessage = "El precio es muy alto $1 a $1000")]
        public decimal Precio { get; set; }
        [Required]
        [DisplayName("Ingrese la cantidad de zapatos")]
        [Range(1, 1, ErrorMessage = "Solo se pueden añadir 1")]
        public int Cantidad { get; set; }
        [Required]
        [DisplayName("Ingreso de producto (Dia/Mes/Año)")]
        public DateTime Fecha { get; set; }

        [Required]
        public byte[]? Imagen { get; set; } = default!;

        [NotMapped]
        public string? ImagenVisual => GetImagenVisual();

        private string? GetImagenVisual()
        {
            if (Imagen is null)
                return null;
            string imreBase64Data = Convert.ToBase64String(Imagen);
            return string.Format("data:image/png;base64,{0}", imreBase64Data);
        }
    }
}
