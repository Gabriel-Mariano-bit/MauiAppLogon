public partial class CadastroPage : ContentPage
{
    public static List<Produto> Produtos = new List<Produto>();

    public CadastroPage()
    {
        InitializeComponent();
    }

    private void AdicionarProduto(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(nomeEntry.Text) || string.IsNullOrWhiteSpace(modeloEntry.Text) || string.IsNullOrWhiteSpace(precoEntry.Text))
        {
            DisplayAlert("Erro", "Todos os campos devem ser preenchidos!", "OK");
            return;
        }

        if (!decimal.TryParse(precoEntry.Text, out decimal preco))
        {
            DisplayAlert("Erro", "Preço inválido!", "OK");
            return;
        }

        var produto = new Produto
        {
            Nome = nomeEntry.Text,
            Modelo = modeloEntry.Text,
            Preco = preco
        };

        Produtos.Add(produto);
        DisplayAlert("Sucesso", "Produto cadastrado!", "OK");

        // Limpar os campos
        nomeEntry.Text = string.Empty;
        modeloEntry.Text = string.Empty;
        precoEntry.Text = string.Empty;
    }
}
