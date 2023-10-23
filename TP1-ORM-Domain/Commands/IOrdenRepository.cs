
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Domain.Commands
{
    public interface IOrdenRepository
    {
        Orden CrearOrden(Orden orden);
        List<Orden> GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null);
    }
}
