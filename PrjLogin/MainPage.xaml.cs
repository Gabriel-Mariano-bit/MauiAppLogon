namespace PrjLogin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();


        }

        public string ImageSource { get; private set; }

       

        private void ToggleTheme_ToolbarItem_Clicked(object sender, EventArgs e)
        {
            App.Current.UserAppTheme = App.Current.UserAppTheme switch
            {
                AppTheme.Dark => AppTheme.Light,
                AppTheme.Light => AppTheme.Dark,
                AppTheme.Unspecified => AppTheme.Dark
            };
           
        }
        private async void GoToCadastroPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroPage());
        }

        private async void GoToListaPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPage());
        }
    }
}


