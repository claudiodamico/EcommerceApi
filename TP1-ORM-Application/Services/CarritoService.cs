
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
        Orden RegistrarVenta();
        void AddOrden(Guid Id, decimal total);
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

        public Orden RegistrarVenta()
        {
            var venta = _carritoRepository.RegistrarVenta();

            return;
        }

        public void ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id)
        {
            _carritoRepository.ModifyCarrito(modifyCarritoDto, Id);
        }

        public void AddOrden(Guid Id, decimal total)
        {
            _carritoRepository.AddOrden(Id, total);
        }

        public void DeleteCarrito(Guid Id)
        {
            _carritoRepository.DeleteCarrito(Id);
        }
    }
}
