public class PedidoDto 
{
    public decimal DescontoPercentual { get; set; }
    public List<ItemPedidoDto> Itens { get; set; }
}