using Microsoft.AspNetCore.Mvc;
namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private static List<dynamic> pedidosUsuario = new()
    {
        new {
            Id = Guid.NewGuid(),
            Data = DateTime.UtcNow.AddDays(-4),
            Status = "AguardandoPagamento",
            DescontoPercentual = 0m,
            Itens = new []
            {
                new { Id = 1, Nome = "Mouse Gamer RGB", Preco = 120.90m },
                new { Id = 2, Nome = "Teclado Mecânico Redragon", Preco = 289.00m }
            }
        },
        new {
            Id = Guid.NewGuid(),
            Data = DateTime.UtcNow.AddDays(-2),
            Status = "EmPreparacao",
            DescontoPercentual = 10m,
            Itens = new []
            {
                new { Id = 3, Nome = "Monitor 27'' 144hz", Preco = 1499.90m }
            }
        }
    };

    [HttpGet("pedidos")]
    public IActionResult GetPedidos()
    {
        var retorno = pedidosUsuario.Select(p => new {
            p.Id,
            p.Data,
            p.Status,
            Total = CalcularTotal(p),
            Itens = p.Itens.Length
        });

        return Ok(retorno);
    }

    private decimal CalcularTotal(dynamic pedido)
    {
        decimal soma = 0;

        foreach (var item in pedido.Itens)
            soma += item.Preco;

        if (pedido.DescontoPercentual > 0)
            soma -= soma * (pedido.DescontoPercentual / 100);

        return soma;
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePedido(Guid id)
    {
        var pedido = pedidosUsuario.FirstOrDefault(p => p.Id == id);
        if (pedido == null)
            return NotFound();

        pedidosUsuario.Remove(pedido);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult AtualizarStatus(Guid id, [FromBody] dynamic body)
    {
        var pedido = pedidosUsuario.FirstOrDefault(p => p.Id == id);
        if (pedido == null)
            return NotFound();

        string novoStatus = body?.status;
        if (!string.IsNullOrWhiteSpace(novoStatus))
        {
            pedido.Status = novoStatus;
        }

        return Ok(pedido);
    }
}