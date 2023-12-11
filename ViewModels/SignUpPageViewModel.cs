using System.ComponentModel;
using TecnologicoAppDani2.Models;
using TecnologicoAppDani2.Service.Interface;
using TecnologicoAppDani2;

namespace TecnologicoAppDani2.ViewModels;

public class SignUpPageViewModel : INotifyPropertyChanged

{
    private readonly ISignUpSignInService SignUpSignInService;
    public UsuarioRegistro Usuario { get; set; }

    public string Password2 { get; set; }

    public Command SaveCommand { get; set; }
    public SignUpPageViewModel(ISignUpSignInService SignUpSignInService)
    {
        Usuario = new UsuarioRegistro();
        SaveCommand = new Command(SignUpAsync);
        this.SignUpSignInService = SignUpSignInService;
    }

    private async void SignUpAsync()
    {
        var result = await SignUpSignInService.SignUpAsync(Usuario);

        if (!result)
        {
            await Util.ShowToastAsync("El usuario no ha sido registrado.");
            return;
        }

        await Util.ShowToastAsync($"Su usuario: {Usuario.Email}, se ha registrado correctamente.");
        await Shell.Current.Navigation.PopAsync();
    }


    public event PropertyChangedEventHandler PropertyChanged;
}