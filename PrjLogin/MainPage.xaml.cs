namespace PrjLogin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();


        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
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
}


