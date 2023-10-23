
namespace TP1_ORM_Domain.Dtos
{
    public class OrdenDto
    {
        public Guid OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<ProductoDto> Productos { get; set; }
    }
}
