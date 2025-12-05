using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly AppDbContext _context;
    public PedidosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Pedido>> GetPedidos()
    {
        var retorno = _context.Pedidos.AsNoTracking().Select(p => new {
            p.Id,
            p.Data,
            p.Status,
            p.Total,
            p.Itens,
            ItensCount = p.Itens.Count
        });

        return Ok(retorno);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePedido(Guid id)
    {
        try
        {
            Pedido? order = GetOrderByGuiId(id);

            if (order == null)
                return NotFound();
            else
            {
                _context.Pedidos.Remove(order);
                _context.SaveChanges();

                return Ok();
            }
        }catch(Exception ex)
        {
            Console.Write(ex.InnerException);   
            return BadRequest();         
        }
    }

    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] PedidoDto dto)
    {
        if (dto.Itens == null || dto.Itens.Count == 0)
            return BadRequest("O pedido deve ter ao menos 1 item.");
        
        if (dto.Itens.Any(e => e.Preco <= 0))
            return BadRequest("Os itens devem possuir valores maiores que zero.");

        Pedido pedido = CreateOrder(dto);

        pedido.Itens = CreateOrderItens(dto.Itens);
        
        decimal totalizer = GenereteTotlizerOrderItens(dto.Itens);

        pedido.Total = SumDescaontPercent(totalizer, dto.DescontoPercentual);

        _context.Pedidos.Add(pedido);

        await _context.SaveChangesAsync();
        
        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AtualizarPedido([FromBody] PedidoDto dto)
    {
        return Ok();
    }

    private Pedido? GetOrderByGuiId(Guid id)
    {
        return _context.Pedidos.Where(e => e.Id == id).FirstOrDefault(); 
    }

    private Pedido CreateOrder(PedidoDto order)
    {
        return new Pedido
        {
            Id = Guid.NewGuid(),
            Data = DateTime.UtcNow,
            Status = StatusPedido.NoCarrinho,
            DescontoPercentual = order.DescontoPercentual,
        };
    }   

    private List<ItemPedido> CreateOrderItens(List<ItemPedidoDto> listItens)
    {
        return listItens.Select(i => new ItemPedido
            {
                Nome = i.Nome,
                Preco = i.Preco
            }).ToList();
    }

    private decimal GenereteTotlizerOrderItens(List<ItemPedidoDto> itens)
    {
        return itens.Sum(e => e.Preco);
    }

    private decimal SumDescaontPercent(decimal totalize, decimal descaunt)
    {
        return  (totalize * (1 - (descaunt / 100)));
    }
}