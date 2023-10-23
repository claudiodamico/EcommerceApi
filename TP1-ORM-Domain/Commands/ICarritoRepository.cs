
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Domain.Commands
{
    public interface ICarritoRepository
    {
        Carrito GetCarritoId(Guid Id);
        Carrito GetCarritoClienteId(int Id);
        CarritoProducto GetCarritoProductoById(Guid id, int Id);
        Carrito GetCarritoById(Guid id);
        Carrito CreateCarrito(Carrito carrito);
        Carrito UpdateCarrito(Carrito Carrito);
        CarritoProducto UpdateCarritoProducto(CarritoProducto carrito);
        Carrito ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id);
        CarritoProducto DeleteProductoCarrito(CarritoProducto carritoProducto);
    }
}
