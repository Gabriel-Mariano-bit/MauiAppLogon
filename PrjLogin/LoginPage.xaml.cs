
namespace PrjLogin;

public partial class LoginPage : ContentPage
{
    List<Usuario> lista;
    public LoginPage()
    {
        InitializeComponent();
        lista = new List<Usuario>();

        lista.Add(
            new Usuario()
            {
                Nome = "jose",
                Senha = "123"
            }
        );

        lista.Add(
            new Usuario()
            {
                Nome = "maria",
                Senha = "321"
            }
        );
    }

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        await ValidarUsuario();
    }

    private async Task ValidarUsuario()
    {
        try
        {
            var usuarioDigitado = new Usuario() { Nome = txtUsuario.Text, Senha = txtSenha.Text };

            bool valido = lista.Any(u => usuarioDigitado.Nome.Equals(u.Nome) && usuarioDigitado.Senha.Equals(u.Senha));

            if (valido)
            {
                Preferences.Default.Set("usuario", usuarioDigitado.Nome);
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                throw new Exception("Usuário e/ou senha inválidos");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro de exceção", ex.Message, "Fechar");
        }
    }

    protected override bool OnBackButtonPressed() { return true; }

    private async void txtSenha_Completed(object sender, EventArgs e)
    {
        await txtSenha.HideSoftInputAsync(CancellationToken.None);
        await ValidarUsuario();
    }

    private void ToggleTheme_ToolbarItem_Clicked(object sender, EventArgs e)
    {
        App.Current.UserAppTheme = App.Current.UserAppTheme switch
        {
            AppTheme.Dark => AppTheme.Light,
            AppTheme.Light => AppTheme.Dark,
            AppTheme.Unspecified => AppTheme.Dark
        };

    }
}