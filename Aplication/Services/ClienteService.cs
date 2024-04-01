
using Aplication.Contracts;
using Aplication.Core;
using Aplication.Dtos.Cliente;

using Aplication.Models;
using Aplication.Validaciones;
using infraestrocture.Interfaces;
using infraestrocture.Repositories;


namespace Aplication.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IUsuarioRepository usuarioRepository;
        public ClienteService(IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository)
        {
            this.clienteRepository = clienteRepository;
            this.usuarioRepository = usuarioRepository;
        }
        public ServiceResult<ClienteGetModel> DeleteEntity(int id)
        {
            ServiceResult<ClienteGetModel> result = new ServiceResult<ClienteGetModel>();
            try
            {
                var ClienteDeleted = clienteRepository.GetEntityById(id);

                if (!result.IsSuccess)
                {

                }
                clienteRepository.DeleteEntity(ClienteDeleted);
                result.message = "Cliente eliminado con exito";
                return result;

            }
            catch { }
            return result;
        }

        public ServiceResult<List<ClienteGetModel>> GetClienteByUsuarioId(int id)
        {
            ServiceResult<List<ClienteGetModel>> result = new ServiceResult<List<ClienteGetModel>>();
            try
            {
                result.Data = clienteRepository.GetClienteByUsuarioID(id).Select(cd => new ClienteGetModel()
                {
                    IdCliente = cd.IdCliente,
                    Nombre = cd.Nombre,
                    Email = cd.Email,
                    Fecha_creacion = cd.Fecha_creacion,
                    pago = cd.pago,
                    Telefono = cd.Telefono,
                    IdUsuario = cd.IdUsuario,

                }).ToList();

                if (!result.IsSuccess)
                {

                }

                result.message = "Clientes recuperados con exito ";
                return result;

            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ServiceResult<List<ClienteGetModel>> getEntities()
        {
            ServiceResult<List<ClienteGetModel>> result = new ServiceResult<List<ClienteGetModel>>();
            try
            {
                result.Data = clienteRepository.GetAllEntities().Select(cd => new ClienteGetModel()
                {
                    IdCliente = cd.IdCliente,
                    Nombre = cd.Nombre,
                    Email = cd.Email,
                    Fecha_creacion = cd.Fecha_creacion,
                    pago = cd.pago,
                    Telefono = cd.Telefono,
                    IdUsuario = cd.IdUsuario,
                }).ToList();
                if (!result.IsSuccess)
                {

                }

                result.message = "Clientes recuperados con exito ";
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ServiceResult<ClienteGetModel> getEntity(int id)
        {
            ServiceResult<ClienteGetModel> result = new ServiceResult<ClienteGetModel>();
            try
            {
                var cliente = clienteRepository.GetEntityById(id);

                result.Data = new ClienteGetModel()
                {
                    IdCliente = cliente.IdCliente,
                    Nombre = cliente.Nombre,
                    Email = cliente.Email,
                    Fecha_creacion = cliente.Fecha_creacion,
                    pago = cliente.pago,
                    Telefono = cliente.Telefono,
                    IdUsuario = cliente.IdUsuario,
                };
                if (!result.IsSuccess)
                {

                }

                result.message = "Cliente recuperado con exito ";
                return result;
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public ServiceResult<ClienteGetModel> SaveEntity(ClienteSaveDto entity)
        {
            ServiceResult<ClienteGetModel> result = new ServiceResult<ClienteGetModel>();
            try
            {
                var validacion = Validaciones(entity, Accion.save);

                if (!validacion.IsSuccess)
                {
                    result.IsSuccess = validacion.IsSuccess;
                    result.message = validacion.message;
                    return result;
                }
                if (!usuarioRepository.Exist(cd => cd.IdUsuario == entity.IdUsuario))
                {
                    result.IsSuccess = false;
                    result.message = "El usuario que intenta agregar un cliente no existe";
                    return result;
                }

                clienteRepository.SaveEnttites(new Domain.Entities.Cliente()
                {
                    Nombre = entity.Nombre,
                    Email = entity.Email,
                    pago = entity.pago,
                    Telefono = entity.Telefono,
                    Fecha_creacion = entity.Fecha_creacion,
                    IdUsuario = entity.IdUsuario,

                });
                //validaciones
                //id not null
                // nombre not null y > 10
                // email not null, > 0 y contener @
                // contrasena not null, > 10 
                // telefono = 10, not null 

                result.message = "Cliente guardado con exito ";
                return result;
            }
            catch
            (Exception ex)
            {
            }
            return result;
        }

        public ServiceResult<ClienteGetModel> UpdateEntity(ClienteUpdateDto entity)
        {
            ServiceResult<ClienteGetModel> result = new ServiceResult<ClienteGetModel>();
            try
            {
                var validacion = Validaciones(entity, Accion.update);

                if (!validacion.IsSuccess)
                {
                    result.IsSuccess = validacion.IsSuccess;
                    result.message = validacion.message;
                    return result;
                }


                clienteRepository.UpdateEntity(new Domain.Entities.Cliente()
                {
                    Nombre = entity.Nombre,
                    Email = entity.Email,
                    Telefono = entity.Telefono,
                    pago = entity.pago,
                    IdCliente = entity.IdCliente,

                });

                //validaciones
                //id not null
                // nombre not null y > 10
                // email not null, > 0 y contener @
                // contrasena not null, > 10 
                // telefono = 10, not null 

                result.message = "Cliente actualizad con exito ";
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        //revisar
        private ServiceResult<UsuarioGetModel> Validaciones(ClienteBaseDto dto, Accion accion)
        {
            ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();
            //validaciones
            //id not null
            // nombre not null y < 10
            // email not null, > 0 y contener @
            // contrasena not null, < 10 
            // telefono = 10, not null 

            if (string.IsNullOrEmpty(dto.Nombre))
            {
                result.message = "El nombre no puede ser null";
                result.IsSuccess = false;
                return result;
            }
            if (string.IsNullOrEmpty(dto.Email))
            {
                result.message = "El email no puede ser null";
                result.IsSuccess = false;
                return result;
            }

            if (!dto.Email.Contains("@"))
            {
                result.message = "No es un email si no contiene @";
                result.IsSuccess = false;
                return result;
            }
            if (string.IsNullOrEmpty(dto.Telefono))
            {
                result.message = "El telefono no puede ser null";
                result.IsSuccess = false;
                return result;
            }
            if (dto.Telefono.Length != 10)
            {
                result.message = "El telefono no puede ser mayor a 10 digitos";
                result.IsSuccess = false;
                return result;
            }
            if (dto.pago == 0)
            {
                result.message = "El pago no puede ser 0";
                result.IsSuccess = false;
                return result;
            }

            if (accion == Accion.save)
            {
                if (clienteRepository.Exist(cl => cl.Nombre == dto.Nombre))
                {
                    result.message = "El cliente ya existe";
                    result.IsSuccess = false;
                    return result;
                }

            }
            if (accion == Accion.update)
            {
 
            }
            return result;
        }
    }
}
