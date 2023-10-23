
using TP1_ORM_AccessData.Data;
using TP1_ORM_Domain.Commands;
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

        public Orden CrearOrden(Orden orden)
        {
            _context.Ordenes.Add(orden);
            _context.SaveChanges();
            return orden;
        }

        public List<Orden> GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            if (FechaDesde == null && FechaHasta == null)
            {
                var ordenes = _context.Ordenes.ToList();
                return ordenes;
            }
            else
            {
                var ordenes = _context.Ordenes.Where(x => x.Fecha == FechaDesde && x.Fecha == FechaHasta).ToList();
                return ordenes;
            }
        }       
    }
}
