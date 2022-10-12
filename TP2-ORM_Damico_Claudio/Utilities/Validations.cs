using TP1_ORM_Domain.Commands;

namespace TP2_ORM_Damico_Claudio.Utilities
{
    public interface IValidations
    {
        bool ValidarCliente(string dni);
    }

    public class Validations : IValidations
    {
        private readonly IClienteRepository _clienteRepository;

        public Validations(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool ValidarCliente(string dni)
        {
            var cliente = _clienteRepository.GetClienteByDni(dni);

            if (cliente != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
