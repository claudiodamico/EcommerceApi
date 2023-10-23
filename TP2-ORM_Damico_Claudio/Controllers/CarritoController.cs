using AutoMapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Mvc;
using TP1_ORM_Application.Services;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP2_ORM_Damico_Claudio.Controllers
{
    [Route("api/carrito")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;
        private readonly IProductoService _productoService;
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;


        public CarritoController(ICarritoService carritoService,
            IProductoService productoService,
            IClientesService clientesService,
            IMapper mapper)
        {
            _carritoService = carritoService;
            _productoService = productoService;
            _clientesService = clientesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Agregar productos al carrito
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        public IActionResult AddProductoCarrito([FromBody] CarritoDto carritoDto)
        {
            try
            {
                var existeCliente = _clientesService.GetClienteById(carritoDto.ClienteId);
                if (existeCliente == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Cliente inexistente",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }

                var existeProducto = _productoService.GetProductoById(carritoDto.ProductoId);
                if (existeProducto == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Producto inexistente",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }

                if (carritoDto.Cantidad < 1)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Ingrese cantidad valida",
                        codigoError = "409"
                    };
                    return NotFound(error);
                }

                var carritoId = _carritoService.GetCarritoClienteId(carritoDto.ClienteId);
                if (carritoId == null)
                {
                    var newCarro = new Carrito
                    {
                        CarritoId = Guid.NewGuid(),
                        ClienteId = carritoDto.ClienteId,
                        Estado = true,
                    };
                    var producto = new CarritoProducto
                    {
                        Cantidad = carritoDto.Cantidad,
                        ProductoId = carritoDto.ProductoId,
                    };
                    newCarro.CarritoProductos.Add(producto);
                    var newCarrito = _carritoService.CreateCarrito(newCarro);
                    return NoContent();
                }
                else
                {
                    var producto = new CarritoProducto
                    {
                        Cantidad = carritoDto.Cantidad,
                        ProductoId = carritoDto.ProductoId,
                    };
                    carritoId.CarritoProductos.Add(producto);
                    _carritoService.UpdateCarrito(carritoId);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return BadRequest("Los datos ingresados son incorrectos");
            }
        }

        /// <summary>
        /// Modificar carrito
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseDto), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        public IActionResult ModifyCarrito([FromBody] ModifyCarritoDto modifyCarritoDto)
        {
            try
            {
                var cliente = _clientesService.GetClienteById(modifyCarritoDto.ClienteId);
                if(cliente == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Cliente inexistente",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }
                var existeProducto = _productoService.GetProductoById(modifyCarritoDto.ProductoId);
                if (existeProducto == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "Producto inexistente",
                        codigoError = "404"
                    };
                    return NotFound(error);
                }
                var carritoId = _carritoService.GetCarritoClienteId(modifyCarritoDto.ClienteId);
                if (carritoId == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "El carrito de compras no contiene productos, por favor ingrese productos",
                        codigoError = "409"
                    };
                    return NotFound(error);
                }
                else
                {
                    var productoCarrito = _carritoService.GetCarritoProductoById(carritoId.CarritoId, modifyCarritoDto.ProductoId);
                    if (productoCarrito == null)
                    {
                        var error = new ErrorDto
                        {
                            descripcion = "El Producto no esta en el carrito o fue eliminado, ingrese un producto existente en del carrito.",
                            codigoError = "404"
                        };
                        return NotFound(error);
                    }
                    productoCarrito.Cantidad = modifyCarritoDto.Cantidad;
                    _carritoService.UpdateCarritoProducto(productoCarrito);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return BadRequest("Se han ingresado los datos de forma incorrecta");
            }
        }

        /// <summary>
        /// Eliminar producto del carrito
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProductoCarrito(int ClienteId, int ProductoId)
        {
            try
            {
                var cliente = _clientesService.GetClienteById(ClienteId);
                if (cliente == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "El cliente ingresado no existe",
                        codigoError = "404"
                    };
                }
                var producto = _productoService.GetProductoById(ProductoId);
                if (producto == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "El producto ingresado no existe",
                        codigoError = "404"
                    };
                    return NotFound(error);
                };
                var carritoId = _carritoService.GetCarritoClienteId(ClienteId);
                if (carritoId == null)
                {
                    var error = new ErrorDto
                    {
                        descripcion = "El carrito de compras no contiene productos, por favor ingrese productos",
                        codigoError = "409"
                    };
                    return NotFound(error);
                }
                else
                {
                    var productoCarrito = _carritoService.GetCarritoProductoById(carritoId.CarritoId, ProductoId);
                    if (productoCarrito == null)
                    {
                        var error = new ErrorDto
                        {
                            descripcion = "El Producto no esta en el carrito o fue eliminado, ingrese un producto existente en del carrito.",
                            codigoError = "404"
                        };
                        return NotFound(error);
                    }
                    _carritoService.DeleteProductoCarrito(productoCarrito);
                    return NoContent();
                }
            }
            catch (Exception)
            {
                return BadRequest("Se han ingresado los datos de forma incorrecta");
            }
        }
    }
}
