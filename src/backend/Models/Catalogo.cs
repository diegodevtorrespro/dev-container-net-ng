public class Catalogo
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public decimal Preco { get; private set; }
    public string Categoria { get; private set; } = null!;
    public int Estoque { get; private set; }

    // Construtor para criação da entidade
    public Catalogo(string nome, decimal preco, string categoria, int estoque)
    {
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
        Estoque = estoque;
    }

    protected Catalogo() { }

    public void AtualizarEstoque(int quantidade)
    {
        Estoque = quantidade;
    }
}