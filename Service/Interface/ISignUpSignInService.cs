using TecnologicoAppDani2.Models;

namespace TecnologicoAppDani2.Service.Interface
{
    public interface ISignUpSignInService
    {
        public Task<bool> SignUpAsync(UsuarioRegistro usuario);

    }
}
