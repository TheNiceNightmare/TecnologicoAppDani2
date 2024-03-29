using TecnologicoAppDani2.ViewModels;

namespace TecnologicoAppDani2.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel loginPageViewModel)
    {
        try
        {
            InitializeComponent();
            BindingContext = loginPageViewModel;
        }
        catch (XamlParseException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}