
using AutoMapper;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Application.Services
{
    public interface IOrdenService
    {
        Orden CrearOrden(Orden orden);
        List<Orden> GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null);
    }
    public class OrdenService : IOrdenService
    {
        private readonly IOrdenRepository _ordenRepository;
        private readonly IMapper _mapper;

        public OrdenService(IOrdenRepository ordenRepository, 
            IMapper mapper)
        {
            _ordenRepository = ordenRepository;
            _mapper = mapper;
        }

        public Orden CrearOrden(Orden orden)
        {
            return _ordenRepository.CrearOrden(orden);
        }

        public List<Orden> GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null )
        {
            var reporte = _ordenRepository.GetBalanceDiario(FechaDesde, FechaHasta).ToList();

            return reporte;
        }
    }
}
