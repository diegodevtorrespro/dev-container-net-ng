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
    public IActionResult GetPedidos()
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
        var todosPedidos = _context.Pedidos.AsNoTracking().Include(x => x.Itens).ToList();

        Pedido? pedidoAtual = null;
        foreach(var pedido in todosPedidos)
        {
            if(pedido.Id.Equals(id))
            {
                pedidoAtual = pedido;
            }
        }

        if (pedidoAtual == null)
        {
            return NotFound();
        }
        else
        {
            _context.Pedidos.RemoveRange(todosPedidos);
            _context.SaveChanges();

            todosPedidos.Remove(pedidoAtual);
            _context.AddRange(todosPedidos);
            _context.SaveChanges();
            
            return Ok();
        }
        
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] PedidoDto dto)
    {
        if (dto.Itens == null || dto.Itens.Count == 0)
            return BadRequest("O pedido deve ter ao menos 1 item.");

        var pedido = new Pedido
        {
            Id = Guid.NewGuid(),
            Data = new DateTime(),
            Status = StatusPedido.NoCarrinho,
            DescontoPercentual = dto.DescontoPercentual,
            Itens = dto.Itens.Select(i => new ItemPedido
            {
                Nome = i.Nome,
                Preco = i.Preco
            }).ToList()
        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();
        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AtualizarPedido([FromBody] PedidoDto dto)
    {
        return Ok();
    }
}