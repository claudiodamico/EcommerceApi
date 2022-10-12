
namespace TP1_ORM_Domain.Entities
{
    public class Producto
    {
        public Producto()
        {
            CarritoProductos = new HashSet<CarritoProducto>();
        }
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Codigo { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public virtual ICollection<CarritoProducto> CarritoProductos { get; set; }
    }
}
