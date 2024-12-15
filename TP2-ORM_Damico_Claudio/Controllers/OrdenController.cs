using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP1_ORM_Application.Services;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP2_ORM_Damico_Claudio.Controllers
{
    [Route("api/orden")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly ICarritoService _carritoService;
        private readonly IClientesService _clienteService;
        private readonly IMapper _mapper;

        public OrdenController(IOrdenService ordenService,
            ICarritoService carritoService,
            IClientesService clienteService,
            IMapper mapper)
        {
            _ordenService = ordenService;
            _carritoService = carritoService;
            _clienteService = clienteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Registrar venta
        /// </summary>
        [HttpPost("registrar-venta")]
        public IActionResult RegistrarVenta(int ClienteId)
        {
            try
            {
                var cliente = _clienteService.GetClienteById(ClienteId);
                if (cliente == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Cliente inexistente",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }
                var carritoId = _carritoService.GetCarritoClienteId(ClienteId);
                if (carritoId == null || !carritoId.CarritoProductos.Any())
                {
                    var error = new ErrorDto
                    {
                        descripcion = "El carrito de compras no contiene productos, por favor ingrese productos",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }
                else
                {
                    decimal total = carritoId.CarritoProductos.Sum(producto => (decimal)(producto.Producto.Precio * producto.Cantidad));

                    var orden = new Orden
                    {
                        OrdenId = Guid.NewGuid(),
                        CarritoId = carritoId.CarritoId,
                        Total = total,
                        Fecha = DateTime.Now
                    };

                    _ordenService.CrearOrden(orden);

                    carritoId.Estado = false;
                    _carritoService.UpdateCarrito(carritoId);

                    return Ok(new { message = "Se ha creado la orden de compra exitosamente" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error inesperado al registrar la venta", detalle = ex.Message });
            }
        }


        /// <summary>
        /// Obtener balance diario de ventas
        /// </summary>
        [HttpGet("balance-diario")]
        [ProducesResponseType(typeof(List<OrdenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public IActionResult GetBalanceDiario([FromQuery] DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            try
            {
                // Obtener órdenes en el rango de fechas
                var ordenes = _ordenService.GetBalanceDiario(FechaDesde, FechaHasta);
                var resultado = new List<OrdenDto>();

                foreach (var orden in ordenes)
                {
                    var carrito = _carritoService.GetCarritoById(orden.CarritoId);
                    var productos = carrito.CarritoProductos
                                           .Select(cp => _mapper.Map<ProductoDto>(cp.Producto))
                                           .ToList();

                    var ordenDto = _mapper.Map<OrdenDto>(orden);
                    ordenDto.Productos = productos;

                    resultado.Add(ordenDto);
                }

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDto
                {
                    descripcion = $"Error al obtener el balance diario: {ex.Message}",
                    codigoError = "500"
                });
            }
        }
    }
}
