

using Domain.Entities;
using infraestrocture.Context;
using infraestrocture.Core;
using infraestrocture.Interfaces;

namespace infraestrocture.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly AplicationContext aplicationContext;
        public UsuarioRepository(AplicationContext context) : base(context)
        {
            this.aplicationContext = context;
        }


        public override void DeleteEntity(Usuario usuario)
        {
            var UsuarioDeleted = GetEntityById(usuario.IdUsuario);
            try
            {
                if (UsuarioDeleted != null)
                {
                    aplicationContext.Usuario.Remove(usuario);
                    aplicationContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }


        }


        public override List<Usuario> FindEntitys(Func<Usuario, bool> filter)
        {
            List<Usuario> usuarios;
            try
            {
                usuarios = aplicationContext.Usuario.Where(filter).ToList();
                return usuarios;

            }catch (Exception ex) {

                throw new Exception();
            }
           
        }

        public override List<Usuario> GetAllEntities()
        {
            return base.GetAllEntities();

        }

        public Usuario GetUsuarioByNameYContra(string name, string contrasena)
        {
            var usuario = aplicationContext.Usuario.FirstOrDefault(cd => cd.Nombre == name && cd.Contrasena == contrasena);

            if (usuario is null)
            {
                return null;
            }
            return usuario;
        }

        public override void SaveEnttites(Usuario usuario)
        {
            aplicationContext.Usuario.Add(usuario);
            aplicationContext.SaveChanges();

        }

        public override void UpdateEntity(Usuario usuario)
        {
            var UsuarioUpdated = GetEntityById(usuario.IdUsuario);
            try
            {

                if (UsuarioUpdated != null)
                {
                    UsuarioUpdated.Nombre = usuario.Nombre == "string" ? UsuarioUpdated.Nombre : usuario.Nombre;
                    UsuarioUpdated.Telefono = usuario.Telefono == "string" ? UsuarioUpdated.Telefono : usuario.Telefono;
                    UsuarioUpdated.Email = usuario.Email == "string"? UsuarioUpdated.Email : usuario.Email;
                    UsuarioUpdated.Contrasena = usuario.Contrasena == "string" ? UsuarioUpdated.Contrasena : usuario.Contrasena;
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
