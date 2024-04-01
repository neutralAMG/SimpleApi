

using Aplication.Contracts;
using Aplication.Core;
using Aplication.Dtos.Usuario;
using Aplication.Models;
using Aplication.Validaciones;
using infraestrocture.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Aplication.Services
{
    public class UsuarioService : IUsuarioServise
    {
        IUsuarioRepository UsuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this.UsuarioRepository = usuarioRepository;
        }
        public ServiceResult<UsuarioGetModel> DeleteEntity(int id)
        {
            ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();
            try
            {
                var UsuarioDeleted = UsuarioRepository.GetEntityById(id);
                if (!result.IsSuccess)
                {

                }
                result.message = "Usuario Eliminado con exito";
                UsuarioRepository.DeleteEntity(UsuarioDeleted);
                return result;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public ServiceResult<List<UsuarioGetModel>> getEntities()
        {
            ServiceResult<List<UsuarioGetModel>> result = new ServiceResult<List<UsuarioGetModel>>();
            try
            {
                result.Data = this.UsuarioRepository.GetAllEntities().Select(us => new UsuarioGetModel()
                {
                    IdUsuario = us.IdUsuario,
                    Nombre = us.Nombre,
                    Telefono = us.Telefono,
                    Fecha_creacion = us.Fecha_creacion,
                    Email = us.Email,
                    tipo = us.tipo,
                    Contrasena = us.Contrasena,

                }).ToList();

                if (!result.IsSuccess)
                {

                }
                result.message = "Usuario recuperado con exito";
                return result;
            }
            catch (Exception ex)
            {
            }

            return result;
        }

        public ServiceResult<UsuarioGetModel> getEntity(int id)
        {
            ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();
            try
            {
                var selectedUsuario = UsuarioRepository.GetEntityById(id);

                result.Data = new UsuarioGetModel()
                {
                    IdUsuario = selectedUsuario.IdUsuario,
                    Nombre = selectedUsuario.Nombre,
                    Telefono = selectedUsuario.Telefono,
                    Fecha_creacion = selectedUsuario.Fecha_creacion,
                    Email = selectedUsuario.Email,
                    tipo = selectedUsuario.tipo,
                    Contrasena = selectedUsuario.Contrasena,
                };


                result.message = "Usuario recuperado con exito";

                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ServiceResult<UsuarioGetModel> GetUsuarioByNameYContra(string name, string contrasena)
        {
            ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();
            try
            {
                var selectedUsuario = UsuarioRepository.GetUsuarioByNameYContra(name, contrasena);

                if (selectedUsuario == null)
                {
                    result.IsSuccess = false;
                    result.message = "Usuario no encontrado";
                    return result;
                }

                result.Data = new UsuarioGetModel()
               {
                   IdUsuario = selectedUsuario.IdUsuario,
                   Nombre = selectedUsuario.Nombre,
                   Telefono = selectedUsuario.Telefono,
                   Fecha_creacion = selectedUsuario.Fecha_creacion,
                   Email = selectedUsuario.Email,
                   tipo = selectedUsuario.tipo,
                   Contrasena = selectedUsuario.Contrasena,
               };
                result.message = "Usuario recuperado con exito";
                return result;
            }catch (Exception ex) { 
            
            }
            return result;
        }

        public ServiceResult<UsuarioGetModel> SaveEntity(UsuarioSaveDto entity)
        {
            ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();
            try
            {

                var validar = Validaciones(entity, Accion.save);

                if (!validar.IsSuccess)
                {
                    result.IsSuccess = validar.IsSuccess;
                    result.message = validar.message;
                    return result;
                }

                if (entity.tipo != 1 || entity.tipo !=2)
                {
                    result.IsSuccess = false;
                    result.message = "Valor de tipo no reconocido, es entre 1 y 2";
                    return result;
                }

                UsuarioRepository.SaveEnttites(new Domain.Entities.Usuario()
                {
                    Nombre = entity.Nombre,
                    tipo = entity.tipo,
                    Fecha_creacion = entity.Fecha_creacion,
                    Email = entity.Email,
                    Contrasena = entity.Contrasena,
                    Telefono = entity.Telefono,
                });

                result.message = "Usuario guardado con exito";
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public ServiceResult<UsuarioGetModel> UpdateEntity(UsuarioUpdateDto entity)
        {
            ServiceResult<UsuarioGetModel> result = new ServiceResult<UsuarioGetModel>();
            try
            {


                var validar = Validaciones(entity, Accion.update);

                if (!validar.IsSuccess)
                {
                    result.IsSuccess = validar.IsSuccess;
                    result.message = validar.message;
                    return result;
                }
                UsuarioRepository.UpdateEntity(new Domain.Entities.Usuario()
                {
                    Nombre = entity.Nombre,
                    Telefono = entity.Telefono,
                    Email = entity.Email,
                    Contrasena = entity.Contrasena,
                    IdUsuario = entity.IdUsuario,

                });
                result.message = "Usuario Actualizado con exito";
                return result;
            }
            catch (Exception ex)
            {

            }

            return result;
        }
        //revisar
        private ServiceResult<UsuarioGetModel> Validaciones(UsuarioBaseDto dto, Accion accion)
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
                result.message = "El telefono no puede ser mayoy a 10 digitos";
                result.IsSuccess = false;
                return result;
            }
            if (string.IsNullOrEmpty(dto.Contrasena))
            {
                result.message = "La Contrasena no puede ser null";
                result.IsSuccess = false;
                return result;
            }
            if (dto.Contrasena.Length < 10)
            {
                result.message = "La Contrasena no puede tener menos de 10 digitos";
                result.IsSuccess = false;
                return result;
            }

            if (accion == Accion.save)
            {
                if (UsuarioRepository.Exist(us => us.Nombre == dto.Nombre))
                {
                    result.message = "El Usuario ya existe";
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
