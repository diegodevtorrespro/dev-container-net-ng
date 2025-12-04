public class ItemPedido
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public Guid PedidoId { get; set; }
    public Pedido Pedido { get; set; }
}
