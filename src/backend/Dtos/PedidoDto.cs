public class PedidoDto 
{
    public decimal DescontoPercentual { get; set; }
    public decimal Total { get; set; }
    public List<ItemPedidoDto> Itens { get; set; }
}