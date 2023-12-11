using TecnologicoAppDani2.Models;
using TecnologicoAppDani2.Service.Interface;

namespace TecnologicoAppDani2.Service;


public class SignUpSignInService : ISignUpSignInService
{
    public async Task<bool> SignUpAsync(UsuarioRegistro usuario)
    {
        await Task.Delay(1000);
        if (usuario == null ||
            string.IsNullOrWhiteSpace(usuario.Email) ||
            string.IsNullOrWhiteSpace(usuario.Password))
        {
            return false;
        }

        Settings.EmailRegistro = usuario.Email;
        Settings.PasswordRegistro = usuario.Password;

        return true;
    }
}
