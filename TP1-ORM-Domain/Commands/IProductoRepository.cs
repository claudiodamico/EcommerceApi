
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Domain.Commands
{
    public interface IProductoRepository
    {
        List<Producto> GetAllProductos();
        Producto GetProductoById(int id);
        List<Producto> GetProducto(string? nombre = null);
    }
}
