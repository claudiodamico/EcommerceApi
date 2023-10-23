
using AutoMapper;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Dtos;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_Application.Services
{
    public interface IClientesService
    {
        List<ClienteDto> GetCliente(string nombre = null, string apellido = null, string dni = null);
        Cliente CrearCliente(ClienteDto cliente);
        ClienteDto GetClienteById(int id);
        List<Cliente> GetAllClientes();
    }
    public class ClienteService : IClientesService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public Cliente CrearCliente(ClienteDto cliente)
        {
            var clienteMapeado = _mapper.Map<Cliente>(cliente);
            _clienteRepository.AddCliente(clienteMapeado);

            return clienteMapeado;
        }

        public List<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes().ToList();
        }

        public List<ClienteDto> GetCliente(string? nombre = null, string? apellido = null, string dni = null)
        {
            var clientes = _clienteRepository.GetCliente(nombre, apellido, dni);

            return _mapper.Map<List<ClienteDto>>(clientes);
        }

        public ClienteDto GetClienteById(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);
            return _mapper.Map<ClienteDto>(cliente);
        }
    }
}
