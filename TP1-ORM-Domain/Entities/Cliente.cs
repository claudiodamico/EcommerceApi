
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TP1_ORM_Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            Carritos = new HashSet<Carrito>();
        }
        public int ClienteId { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 7)]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese solo numeros")]
        [Display(Name = "DNI")]
        public string Dni { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 9)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 8)]
        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }
    }
}
