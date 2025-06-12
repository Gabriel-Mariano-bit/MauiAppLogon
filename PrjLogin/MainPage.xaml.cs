namespace PrjLogin
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            LightThemeButton.IsVisible = true;
            DarkThemeButton.IsVisible = true;
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
        private void OnLightThemeClicked(object sender, EventArgs e)
        {
            // Aplica o tema claro
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new Light());
            // Atualiza visibilidade dos botões
            LightThemeButton.IsVisible = false;
            DarkThemeButton.IsVisible = true;
        }
        private void OnDarkThemeClicked(object sender, EventArgs e)
        {
            // Aplica o tema escuro
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(new Dark());
            // Atualiza visibilidade dos botões
            DarkThemeButton.IsVisible = false;
            LightThemeButton.IsVisible = true;
        }
    }

}
