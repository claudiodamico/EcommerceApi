
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

        public void DeleteProductoCarrito(string codigo)
        {
            _context.Remove(codigo);
            _context.SaveChanges();
        }
    }
}
