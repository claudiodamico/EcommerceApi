
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Application.Services
{
    public interface ICarritoService
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
    public class CarritoService : ICarritoService
    {
        private readonly ICarritoRepository _carritoRepository;

        public CarritoService(ICarritoRepository carritoRepository)
        {
            _carritoRepository = carritoRepository;
        }

        public Carrito GetCarritoId(Guid Id)
        {
            return _carritoRepository.GetCarritoId(Id); 
        }

        public Carrito GetCarritoClienteId(int id)
        {
            return _carritoRepository.GetCarritoClienteId(id);
        }

        public CarritoProducto GetCarritoProductoById(Guid id, int productoId)
        {
            return _carritoRepository.GetCarritoProductoById(id, productoId);
        }

        public Carrito GetCarritoById(Guid id)
        {
            return _carritoRepository.GetCarritoById(id);
        }

        public Carrito UpdateCarrito(Carrito carrito)
        {
            return _carritoRepository.UpdateCarrito(carrito);
        }
        public CarritoProducto UpdateCarritoProducto(CarritoProducto carrito)
        {
            return _carritoRepository.UpdateCarritoProducto(carrito);
        }

        public Carrito ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id)
        {
            var mCarrito = _carritoRepository.ModifyCarrito(modifyCarritoDto, Id);

            return mCarrito;
        }

        public Carrito CreateCarrito(Carrito carrito)
        {
            return _carritoRepository.CreateCarrito(carrito);
        }

        public CarritoProducto DeleteProductoCarrito(CarritoProducto carritoProducto)
        {
            return _carritoRepository.DeleteProductoCarrito(carritoProducto);
        }
    }
}
