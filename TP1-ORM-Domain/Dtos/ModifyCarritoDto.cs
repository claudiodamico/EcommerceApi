
namespace TP1_ORM_Domain.Dtos
{
    public class ModifyCarritoDto
    {
        public Guid CarritoId { get; set; }
        public int ClienteId { get; set; }
        public bool Estado { get; set; }
    }
}
