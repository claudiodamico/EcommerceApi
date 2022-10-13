
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Domain.Commands
{
    public interface ICarritoRepository
    {
        Carrito GetCarritoId(Guid Id);
        void AddCarrito(Carrito carrito);
        Carrito ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id);
        void DeleteProductoCarrito(string codigo);
    }
}
