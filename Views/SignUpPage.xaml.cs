using TecnologicoAppDani2.ViewModels;

namespace TecnologicoAppDani2.Views;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel SignUpPageViewModel)
    {
        try
        {
            InitializeComponent();
            BindingContext = SignUpPageViewModel;
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