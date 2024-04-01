
using Microsoft.IdentityModel.Tokens;

namespace Aplication.Validaciones
{
    public enum Accion
    {
        save,
        update
    }

    public static class Validations
    {

        public static string StringValidation(string str)
        {
           var stringValidada = str.IsNullOrEmpty();
            return stringValidada ? "no puede estar vacio" : null; 
        }

    }
}
