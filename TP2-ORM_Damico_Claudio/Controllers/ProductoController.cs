using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP1_ORM_Application.Services;

namespace TP2_ORM_Damico_Claudio.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService,
           IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Filtrar Productos por Nombre y precio
        /// </summary>
        [HttpGet]
        public IActionResult GetProductos(string? nombre)
        {
            {
                try
                {
                    return new JsonResult(_productoService.GetProducto(nombre)) { StatusCode = 200 };
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }

        /// <summary>
        /// Filtrar Productos por Id
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetProductosByid(int id)
        {
            {
                try
                {
                    return new JsonResult(_productoService.GetProductoById(id)) { StatusCode = 200 };
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }
    }
}
