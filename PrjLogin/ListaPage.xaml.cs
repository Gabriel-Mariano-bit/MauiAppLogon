using System.Collections.ObjectModel;

namespace PrjLogin
{
    public partial class ListaPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; }

        public ListaPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            Products = products;
            BindingContext = this;
        }

        private async void GoToCadastroPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroPage(Products));
        }
        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage()); 
        }
    }
}