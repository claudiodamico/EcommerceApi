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
        /// Filtrar Productos por Nombre (opcional).
        /// </summary>
        [HttpGet]
        public IActionResult GetProductos(string? nombre)
        {
            try
            {
                var productos = _productoService.GetProducto(nombre);

                if (productos == null || !productos.Any())
                {
                    return NotFound(new { message = "No se encontraron productos." });
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", detalle = ex.Message });
            }
        }

        /// <summary>
        /// Filtrar Productos por Id.
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetProductosByid(int id)
        {
            try
            {
                var producto = _productoService.GetProductoById(id);

                if (producto == null)
                {
                    return NotFound(new { message = $"No se encontró el producto con ID {id}." });
                }

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", detalle = ex.Message });
            }
        }

        /// <summary>
        /// Filtrar productos por precio (mayor o menor).
        /// </summary>
        [HttpGet("filtrar-por-precio")]
        public IActionResult GetProductosPorPrecio([FromQuery] bool mayor)
        {
            try
            {
                var productos = mayor
                    ? _productoService.GetProducto().OrderByDescending(p => p.Precio).ToList()
                    : _productoService.GetProducto().OrderBy(p => p.Precio).ToList();

                if (!productos.Any())
                {
                    return NotFound(new { message = "No se encontraron productos." });
                }

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", detalle = ex.Message });
            }
        }
    }
}
