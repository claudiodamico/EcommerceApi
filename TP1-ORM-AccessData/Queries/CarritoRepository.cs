
using Microsoft.EntityFrameworkCore;
using TP1_ORM_AccessData.Data;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_AccessData.Queries
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly TiendaDbContext _context;

        public CarritoRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public Carrito GetCarritoId(Guid Id)
        {
            return _context.Carritos.Include(Carrito => Carrito.CarritoProductos)
                                    .ThenInclude(carro => carro.Producto)
                                    .FirstOrDefault(d => d.CarritoId.Equals(Id) && d.Estado == true);
        }

        public Carrito GetCarritoClienteId(int Id)
        {
            return _context.Carritos.Include(Carrito => Carrito.CarritoProductos)
                                    .ThenInclude(carro => carro.Producto)
                                    .FirstOrDefault(d => d.ClienteId.Equals(Id) && d.Estado == true);
        }

        public void AddCarrito(Carrito carrito)
        {
            var tempCarrito = new Carrito
            {
                CarritoId = new Guid(),
                ClienteId = new int(),
                Estado = false,
            };
            _context.Carritos.Add(tempCarrito);
            _context.SaveChanges();
        }

        public CarritoProducto GetCarritoProductoById(Guid id, int Id)
        {
            return _context.CarritoProductos.FirstOrDefault(d => d.CarritoId == id && d.ProductoId == Id);
        }

        public Carrito GetCarritoById(Guid id)
        {
            return _context.Carritos.Include(Carrito => Carrito.CarritoProductos)
                                 .ThenInclude(carro => carro.Producto)
                                 .FirstOrDefault(d => d.CarritoId.Equals(id));
        }

        public Carrito CreateCarrito(Carrito carrito)
        {
            _context.Carritos.Add(carrito);
            _context.SaveChanges();
            return carrito;
        }

        public Carrito UpdateCarrito(Carrito Carrito)
        {
            _context.Update(Carrito);
            _context.SaveChanges();
            return Carrito;
        }

        public CarritoProducto UpdateCarritoProducto(CarritoProducto carrito)
        {
            _context.CarritoProductos.Update(carrito);
            _context.SaveChanges();
            return carrito;
        }

        public Carrito ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id)
        {
            var cliente = _context.Clientes.Find(Id);
            Carrito modify = (from x in _context.Carritos where x.CarritoId == Id select x).FirstOrDefault();
            modify.ClienteId = cliente.ClienteId;
            modify.Estado = true;

            _context.Update(modify);
            _context.SaveChanges();

            return modify;
        }

        public CarritoProducto DeleteProductoCarrito(CarritoProducto carritoProducto)
        {
            _context.Remove(carritoProducto);
            _context.SaveChanges();
            return carritoProducto;
        }
    }
}
