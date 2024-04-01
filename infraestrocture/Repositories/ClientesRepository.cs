
using Domain.Entities;
using infraestrocture.Context;
using infraestrocture.Core;
using infraestrocture.Interfaces;

namespace infraestrocture.Repositories
{
    public class ClientesRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly AplicationContext aplicationContext;
        public ClientesRepository(AplicationContext context) : base(context)
        {
            aplicationContext = context;
        }

        public List<Cliente> GetClienteByUsuarioID(int id)
        {
            List<Cliente> ClientesDeUsuarioEspecifico;
            try
            {
                ClientesDeUsuarioEspecifico = aplicationContext.Cliente.Where(cd => cd.IdUsuario == id).ToList();

                return ClientesDeUsuarioEspecifico;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public override void DeleteEntity(Cliente cliente)
        {
            Cliente clientedDeleted = GetEntityById(cliente.IdCliente);
            try
            {
                aplicationContext.Cliente.Remove(clientedDeleted);
                aplicationContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public override List<Cliente> FindEntitys(Func<Cliente, bool> filter)
        {
            List<Cliente> clientes;
            try
            {
                clientes = aplicationContext.Cliente.Where(filter).ToList();
                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        public override List<Cliente> GetAllEntities()
        {
            return base.GetAllEntities();

        }


        public override void SaveEnttites(Cliente cliente)
        {
            aplicationContext.Cliente.Add(cliente);
            aplicationContext.SaveChanges();

        }

        public override void UpdateEntity(Cliente cliente)
        {
            Cliente clienteUpdated = GetEntityById(cliente.IdCliente);
            try
            {
                if (clienteUpdated != null)
                {
                    clienteUpdated.Nombre = cliente.Nombre == "string" ? clienteUpdated.Nombre : clienteUpdated.Nombre;
                    clienteUpdated.Telefono = cliente.Telefono == "string" ? clienteUpdated.Telefono : clienteUpdated.Telefono;
                    clienteUpdated.Email = cliente.Email == "string" ? clienteUpdated.Email : clienteUpdated.Email;
                    clienteUpdated.pago = clienteUpdated.pago == 0 ? clienteUpdated.pago : cliente.pago ;
                    aplicationContext.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw new Exception();
            }


        }
    }
}
