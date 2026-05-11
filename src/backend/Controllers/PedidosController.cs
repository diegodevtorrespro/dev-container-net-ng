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
        var todosPedidos = _context.Pedidos.Where(x => x.Id == id).ToList();

        Pedido? pedidoAtual = null;

        foreach(var pedido in todosPedidos)
        {
            pedidoAtual = pedido;
            RemovePedido(_context, id, todosPedidos);
            return Ok();
        }

        if (pedidoAtual == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CriarPedido([FromBody] PedidoDto dto)
    {
        if (dto.Itens == null || dto.Itens.Count == 0)
            return BadRequest("O pedido deve ter ao menos 1 item.");

        Task<IActionResult> valorTotalPedidos = CriarPedido(dto, _context);

        return Created();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AtualizarPedido([FromBody] PedidoDto dto)
    {
        return Ok();
    }
   
 
    public void RemovePedido(AppDbContext _context, Guid _Pedido, List<Pedido>? _todosPedidos)
    {
            if (_todosPedidos is null)
                _todosPedidos = new List<Pedido>();
            _context.Remove(_Pedido);
            _context.AddRange(_todosPedidos);
            _context.SaveChanges();
    }

    public async Task<IActionResult> CriarPedido(PedidoDto _dto, AppDbContext _context)
    {
        var pedido = new Pedido
        {
            Id = Guid.NewGuid(),
            Data = new DateTime(),
            Status = StatusPedido.NoCarrinho,
            DescontoPercentual = _dto.DescontoPercentual,
            Total = _dto.Total,
            Itens = _dto.Itens.Select(i => new ItemPedido
            {
                Nome = i.Nome,
                Preco = i.Preco
            }).ToList()
        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return Created();

    }

    public decimal CalculaTotalPedidos(AppDbContext _context)
    {
        //Calcular o total de pedido, somando os preços dos itens selecionados e subtraindo o percentual de desconto aplicado;
        decimal _totalPedidos = 0;
        foreach(var pedido in _context.Pedidos){
            _totalPedidos = pedido.Total - ((pedido.Total * pedido.DescontoPercentual) / 100);
        }
        return 0;
    }

}