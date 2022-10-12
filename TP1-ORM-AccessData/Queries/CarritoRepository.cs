
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
            return _context.Carritos.SingleOrDefault(x => x.CarritoId == Id);
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

        public Orden RegistrarVenta()
        {
            var carrito = new Carrito
            {
                CarritoId = Guid.NewGuid(),
                ClienteId = 1,
                Estado = true
            };
            _context.Carritos.Add(carrito);

            var producto = _context.Productos.Find();

            decimal total = 0;

            int cantidad = carrito.ClienteId;
            if (cantidad != 0 && cantidad != null)
            {
                var itemCarrito = new CarritoProducto
                {
                    CarritoId = carrito.CarritoId,
                    ProductoId = producto.ProductoId,
                    Cantidad = cantidad
                };
                _context.CarritoProductos.Add(itemCarrito);
                _context.SaveChanges();

                total = producto.Precio * cantidad;

                AddOrden(carrito.CarritoId, total);
                _context.SaveChanges();
            }

            return 
        }

        public void ModifyCarrito(ModifyCarritoDto modifyCarritoDto, Guid Id)
        {
            var cliente = _context.Clientes.Find(Id);
            Carrito modify = (from x in _context.Carritos where x.CarritoId == Id select x).FirstOrDefault();
            modify.ClienteId = cliente.ClienteId;
            modify.Estado = true;

            _context.Update(modify);
            _context.SaveChanges();
        }

        public void DeleteCarrito(Guid Id)
        {
            _context.Remove(Id);
            _context.SaveChanges();
        }

        public void AddOrden(Guid Id, decimal total)
        {
            var orden = new Orden
            {
                OrdenId = Guid.NewGuid(),
                CarritoId = Id,
                Fecha = DateTime.Now,
                Total = total
            };
            _context.Add(orden);
        }
    }
}
