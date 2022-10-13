
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Domain.Commands
{
    public interface IOrdenRepository
    {
        Orden RegistrarVenta(OrdenDto ordenDto);
        void AddOrden(Guid Id, decimal total);
        List<Orden> GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null);
    }
}
