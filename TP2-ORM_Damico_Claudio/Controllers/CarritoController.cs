using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP1_ORM_Application.Services;
using TP1_ORM_Domain.Dtos;

namespace TP2_ORM_Damico_Claudio.Controllers
{
    [Route("api/carrito")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;
        private readonly IMapper _mapper;


        public CarritoController(ICarritoService carritoService,
            IMapper mapper)
        {
            _carritoService = carritoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Agregar productos al carrito
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddProductoCarrito(CarritoDto carritoDto)
        {
            {
                try
                {
                    return new JsonResult(_carritoService.AddCarrito(carritoDto)) { StatusCode = 200 };
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RegistrarVenta()
        {
            {
                try
                {
                    return new JsonResult(_carritoService.RegistrarVenta()) { StatusCode = 200 };
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }
    } 
}
