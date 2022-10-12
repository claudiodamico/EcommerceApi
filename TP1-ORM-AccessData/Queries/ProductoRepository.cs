
using System.Net;
using TP1_ORM_AccessData.Data;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_AccessData.Queries
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly TiendaDbContext _context;

        public ProductoRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public List<Producto> GetAllProductos()
        {
            return _context.Productos.ToList();
        }

        public List<Producto> GetProducto(string? nombre = null)
        {
            return _context.Productos.
                                      Where(producto => (string.IsNullOrEmpty(nombre) || producto.Nombre == nombre)).OrderBy(producto => producto.Precio).ToList();
        }

        public Producto GetProductoById(int id)
        {
            return _context.Productos.SingleOrDefault(producto => producto.ProductoId == id);
        }
    }
}
