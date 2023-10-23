
using AutoMapper;
using System.Net;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Application.Services
{
    public interface IProductoService
    {
        List<Producto> GetAllProductos();
        ProductoDto GetProductoById(int id);
        List<ProductoDto> GetProducto(string? nombre = null);
    }
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public List<Producto> GetAllProductos()
        {
            return _productoRepository.GetProducto().ToList();
        }

        public List<ProductoDto> GetProducto(string? nombre = null)
        {
            var productos = _productoRepository.GetProducto(nombre);

            return _mapper.Map<List<ProductoDto>>(productos);
        }

        public ProductoDto GetProductoById(int id)
        {
            var producto = _productoRepository.GetProductoById(id);
            if (producto == null)
            {
                return null;
            }
            return _mapper.Map<ProductoDto>(producto);
        }
    }
}
