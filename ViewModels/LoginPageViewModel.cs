using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TecnologicoAppDani2.Models;
using TecnologicoAppDani2.Service.Interface;
using TecnologicoAppDani2.Views;

namespace TecnologicoAppDani2.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        #region "Properties"


        public UsuarioRegistro Usuario { get; set; }

        public Command LoginCommand { get; set; }

        public Command RegisterCommand { get; set; }

        #endregion

        public LoginPageViewModel(ISignUpSignInService SignupSigninService)
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
            RegisterCommand = new Command(GoToSignupPageAsync);
            
        }

        #region "Logic"

        private async void LoginAsync()
        {
            if (string.IsNullOrEmpty(Usuario.Email) || Util.IsAValidEmail(Usuario.Email.ToLower()))
            {
                await Util.ShowToastAsync("El E-mail que ingresaste no es válido.");
                return;
            }

            if (string.IsNullOrEmpty(Usuario.Password))
            {
                await Util.ShowToastAsync("La contraseña que ingresaste no es válida.");
                return;
            }

            var loginData = GetLoginData();

            if (loginData != null && !loginData.Any())
            {
                await Util.ShowToastAsync("Debe registrarse!");
                return;
            }

            var loginDataEmail = loginData.FirstOrDefault(x => x.Key == Usuario.Email);

            if (loginDataEmail.Equals(default(KeyValuePair<string, string>)))
            {
                await Util.ShowToastAsync($"El E-mail ingresado: {Usuario.Email}, no existe");
                return;
            }

            if (loginDataEmail.Value != Usuario.Password)
            {
                await Util.ShowToastAsync($"Contraseña Incorrecta");
                return;
            }


            Settings.IsAuthenticated = true;
            Settings.Email = Usuario.Email;
            Settings.EmailRegistro = Usuario.Email;
            Settings.PasswordRegistro = Usuario.Password;

            await Shell.Current.GoToAsync($"///{nameof(WelcomePage)}");
        }



        private async void GoToSignupPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }


        private List<KeyValuePair<string, string>> GetLoginData()
        {
            return new List<KeyValuePair<string, string>>()
            {
                new("daniel@istlcg.com", "Mama1234."),
                new("gus@mail.com", "Guayaquil"),
                new(Settings.EmailRegistro, Settings.PasswordRegistro)
            };

        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}