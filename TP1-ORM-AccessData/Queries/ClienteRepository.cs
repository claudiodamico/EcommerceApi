
using TP1_ORM_AccessData.Data;
using TP1_ORM_Domain.Commands;
using TP1_ORM_Domain.Entities;

namespace TP1_ORM_AccessData.Queries
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TiendaDbContext _context;

        public ClienteRepository(TiendaDbContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAllClientes()
        {
            return _context.Clientes.ToList();
        }

        public List<Cliente> GetCliente(string? nombre = null, string? apellido = null, string? dni = null)
        {
            return _context.Clientes.
                                    Where(cliente => (string.IsNullOrEmpty(nombre) || cliente.Nombre == nombre) &&
                                    (string.IsNullOrEmpty(apellido) || cliente.Apellido == apellido) &&
                                    (string.IsNullOrEmpty(dni) || cliente.Dni == dni)).ToList();
        }

        public void AddCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente GetClienteById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Delete(GetClienteById(id));
        }

        public Cliente GetClienteByDni(string dni)
        {
            return _context.Clientes.FirstOrDefault(c => c.Dni == dni);
        }   
    }
}
