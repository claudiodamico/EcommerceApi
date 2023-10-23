
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
            ICarritoService clienteService,
            IClientesService clientesService,
            IMapper mapper)
        {
            _ordenService = ordenService;
            _carritoService = clienteService;
            _clienteService = clientesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Registrar venta
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        public IActionResult RegistrarVenta(int ClienteId)
        {
            try
            {
                var cliente = _clienteService.GetClienteById(ClienteId);
                if(cliente == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Cliente inexistente",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }
                var carritoId = _carritoService.GetCarritoClienteId(ClienteId);
                if(carritoId == null)
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
                    decimal total = 0;
                    foreach (CarritoProducto producto in carritoId.CarritoProductos)
                    {
                        total = (decimal)(producto.Producto.Precio * producto.Cantidad);
                    }
                    var Orden = new Orden
                    {
                        OrdenId = Guid.NewGuid(),
                        CarritoId = carritoId.CarritoId,
                        Total = total,
                        Fecha = DateTime.Now
                    };
                    _ordenService.CrearOrden(Orden);
                    carritoId.Estado = false;
                    _carritoService.UpdateCarrito(carritoId);
                    return Ok("Se ha creado la orden de compra exitosamente");
                }
            }
            catch (Exception)
            {
                return BadRequest("Los datos ingresados son incorrectos");
            }
        }

        /// <summary>
        /// Traer balance diario de ventas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<OrdenDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
        public IActionResult GetBalanceDiario([FromQuery] DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            try
            {
                var orden = _ordenService.GetBalanceDiario(FechaDesde, FechaHasta);
                List<OrdenDto> ordenes = new List<OrdenDto>();
                foreach(var item in orden)
                {
                    List<ProductoDto> productos = new List<ProductoDto>();
                    var carrito = _carritoService.GetCarritoById(item.CarritoId);
                    foreach(var producto in carrito.CarritoProductos)
                    {
                        productos.Add(_mapper.Map<ProductoDto>(producto.Producto));
                    }
                    var ordenMapped = _mapper.Map<OrdenDto>(item);
                    ordenMapped.Productos = productos;
                    ordenes.Add(ordenMapped);
                }

                return Ok(ordenes);
            }
            catch (Exception e)
            {
                var error = new ErrorDto()
                {
                    descripcion = e.Message,
                    codigoError = "404",
                };
                return NotFound(error);
            }
        }
    }
}
