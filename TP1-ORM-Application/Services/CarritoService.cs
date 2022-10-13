
using AutoMapper;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Application.Services
{
    public interface ICarritoService
    {
        Carrito GetCarritoId(Guid Id);
        Carrito AddCarrito(CarritoDto carrito);
        void AddOrden(Carrito carrito);
        Carrito ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id);
        void DeleteProductoCarrito(string codigo);
    }
    public class CarritoService : ICarritoService
    {
        private readonly ICarritoRepository _carritoRepository;
        private readonly IMapper _mapper;

        public CarritoService(ICarritoRepository carritoRepository, 
            IMapper mapper)
        {
            _carritoRepository = carritoRepository;
            _mapper = mapper;
        }

        public Carrito GetCarritoId(Guid Id)
        {
            return _carritoRepository.GetCarritoId(Id); 
        }

        public Carrito AddCarrito(CarritoDto carrito)
        {
            var carritoMapeado = _mapper.Map<Carrito>(carrito);
            _carritoRepository.AddCarrito(carritoMapeado);

            return carritoMapeado;
        }
      
        public Carrito ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id)
        {
            var mCarrito = _carritoRepository.ModifyCarrito(modifyCarritoDto, Id);

            return mCarrito;
        }

        public void AddOrden(Carrito carrito)
        {
            _carritoRepository.AddCarrito(carrito);
        }

        public void DeleteProductoCarrito(string codigo)
        {
            _carritoRepository.DeleteProductoCarrito(codigo);
        }
    }
}
