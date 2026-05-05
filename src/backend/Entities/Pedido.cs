public class Pedido
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public StatusPedido Status { get; set; }
    public decimal DescontoPercentual { get; set; }
    public decimal Total { get; set; }

    public List<ItemPedido> Itens { get; set; } = new();

    public decimal CalcularTotal()
    {
       return Itens.Sum(x => x.Preco);
    }

    public decimal desconto()
    {
        var valorTotal = CalcularTotal();
        return valorTotal * (DescontoPercentual / 100); 
    }
}
