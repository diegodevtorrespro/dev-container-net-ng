public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public decimal Preco { get; private set; }
    public string Categoria { get; private set; } = null!;
    public int Estoque { get; private set; }
    
    public Produto(string nome, decimal preco, string categoria, int estoque)
    {
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
        Estoque = estoque;
    }

    protected Produto() { }

    public void AtualizarEstoque(int quantidade)
    {
        Estoque = quantidade;
    }
}