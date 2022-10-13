
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
        private readonly IMapper _mapper;

        public OrdenController(IOrdenService ordenService,
            IMapper mapper)
        {
            _ordenService = ordenService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RegistrarVenta(OrdenDto ordenDto)
        {
            try
            {
                return new JsonResult(_ordenService.RegistrarVenta(ordenDto)) { StatusCode = 201 };
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public IActionResult GetBalanceDiario(DateTime? FechaDesde = null, DateTime? FechaHasta = null)
        {
            try
            {
                return new JsonResult(_ordenService.GetBalanceDiario(FechaDesde)) { StatusCode = 200 };
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
