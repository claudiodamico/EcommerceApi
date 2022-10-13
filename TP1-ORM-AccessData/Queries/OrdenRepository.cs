
using TP1_ORM_AccessData.Data;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_AccessData.Queries
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly TiendaDbContext _context;

        public OrdenRepository(TiendaDbContext context)
        {
            _context = context;
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

        public List<Orden> GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            return _context.Ordenes.Where(x => x.Fecha == FechaDesde && x.Fecha == FechaHasta).ToList();
        }

        public Orden RegistrarVenta(OrdenDto ordenDto)
        {
            Orden orden = new Orden();

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
            }

            AddOrden(carrito.CarritoId, total);

            return orden;
        }
    }
}
