
namespace TP1_ORM_Domain.Dtos
{
    public class ClienteErrorDto
    {
        public int CodigoError { get; set; }
        public string Descripcion { get; set; }

        public ClienteErrorDto()
        {
            Descripcion = "Ya existe un Cliente con ese Dni ingresado";
            CodigoError = 1;
        }
    }
}
