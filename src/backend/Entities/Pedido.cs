public class Pedido
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public StatusPedido Status { get; set; }
    public decimal DescontoPercentual { get; set; }
    public decimal Total { get; set; }

    public List<ItemPedido> Itens { get; set; } = new();

    public decimal CalcularTotalComDesconto(List<ItemPedido> itensPedido, decimal descontoPercentual)
    {
        decimal total = 0;

        foreach(var item in itensPedido)
        {
            if(item.Preco > 0)
            {
                var precoItemDesconto =  item.Preco - (item.Preco/100) * descontoPercentual; 

                total += precoItemDesconto;
                
                // /100 * descontoPercentual;    
            }
        }
        return total;
    }
}
