using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TP1_ORM_Application.Services;
using TP1_ORM_Domain.Dtos;
using TP2_ORM_Damico_Claudio.Utilities;

namespace TP2_ORM_Damico_Claudio.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        private readonly IMapper _mapper;
        private readonly IValidations _validations;

        public ClienteController(IClientesService clientesService,
            IMapper mapper,
            IValidations validations)
        {
            _clientesService = clientesService;
            _mapper = mapper;
            _validations = validations;
        }

        /// <summary>
        /// Filtrar Clientes por Nombre, Apellido o Dni
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetClientes(string? nombre, string? apellido, string? dni)
        {
            {
                try
                {
                    return new JsonResult(_clientesService.GetCliente(nombre, apellido, dni)) { StatusCode = 200 };
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }
        }

        /// <summary>
        /// Registrar Cliente
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult RegistrarCliente([FromForm] ClienteDto cliente)
        {
            try
            {
                bool validar = _validations.ValidarCliente(cliente.Dni);
                if (validar != true)
                {
                    var clienteEntity = _clientesService.CrearCliente(cliente);
                    if (clienteEntity != null)
                    {
                        var clienteCreado = _mapper.Map<ClienteDto>(clienteEntity);
                        return new JsonResult(clienteCreado) { StatusCode = 201 };
                    }
                    return BadRequest();
                }               
                return Conflict(new ErrorDto());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
