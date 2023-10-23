
namespace TP1_ORM_Domain.Dtos
{
    public class CarritoDto
    {
        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
