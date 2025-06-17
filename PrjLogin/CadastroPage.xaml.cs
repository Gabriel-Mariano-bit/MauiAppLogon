using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PrjLogin
{
    public partial class CadastroPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Product> _products;
        private string _name = string.Empty;
        private string _model = string.Empty;
        private decimal? _price; 
        private string _description = string.Empty;

        public CadastroPage(ObservableCollection<Product> products)
        {
            InitializeComponent();
            _products = products;
            BindingContext = this;
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Model
        {
            get => _model;
            set { _model = value; OnPropertyChanged(); }
        }

        public decimal? Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

      private void AddProduct(object sender, EventArgs e)
{
    

    // Verifica se os demais campos est�o preenchidos
    if (string.IsNullOrWhiteSpace(Name) || 
        string.IsNullOrWhiteSpace(Model) || 
        string.IsNullOrWhiteSpace(Description))
    {
        DisplayAlert("Erro", "Todos os campos devem ser preenchidos.", "OK");
        return; // Sai sem cadastrar
    }

            // Verifica se o pre�o cont�m apenas n�meros antes de validar campos vazios
            if (string.IsNullOrWhiteSpace(Price?.ToString()) || !decimal.TryParse(Price?.ToString(), out decimal validPrice))
            {
                DisplayAlert("Erro", "O pre�o deve conter apenas n�meros", "OK");
                return; // Sai sem cadastrar
            }

            // Adiciona o produto � lista
            _products.Add(new Product
    {
        Name = Name,
        Model = Model,
        Price = validPrice, // Usa o valor validado
        Description = Description
    });

    // Limpa os campos ap�s o cadastro
    Name = string.Empty;
    Model = string.Empty;
    Price = null;
    Description = string.Empty;
}

        private void ClearProductList(object sender, EventArgs e)
        {
            _products.Clear(); 
        }

        private async void GoToListaPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPage(_products));
        }
        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}  

