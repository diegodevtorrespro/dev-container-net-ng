using Microsoft.AspNetCore.Mvc;
namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogosController : ControllerBase
{
    private static List<dynamic> itensCatalogo = new()
    {
        new { Id = 1, Nome = "Mouse Gamer RGB", Preco = 120.90m, Categoria = "Periféricos", Estoque = 15 },
        new { Id = 2, Nome = "Teclado Mecânico Redragon", Preco = 289.00m, Categoria = "Periféricos", Estoque = 8 },
        new { Id = 3, Nome = "Monitor 27'' 144hz", Preco = 1499.90m, Categoria = "Monitores", Estoque = 5 },
        new { Id = 4, Nome = "Notebook i7 16GB 512SSD", Preco = 4899.90m, Categoria = "Hardware", Estoque = 3 },
        new { Id = 5, Nome = "Headset HyperX Cloud", Preco = 399.90m, Categoria = "Headset", Estoque = 10 },
        new { Id = 6, Nome = "Placa de Vídeo RTX 4060 8GB", Preco = 2399.00m, Categoria = "Hardware", Estoque = 4 },
        new { Id = 7, Nome = "SSD NVMe 1TB Gen4", Preco = 499.90m, Categoria = "Armazenamento", Estoque = 12 },
        new { Id = 8, Nome = "Roteador Wi-Fi 6 AX1800", Preco = 349.00m, Categoria = "Redes", Estoque = 9 },
        new { Id = 9, Nome = "Cadeira Gamer Ergonômica", Preco = 899.90m, Categoria = "Acessórios", Estoque = 6 },
        new { Id = 10, Nome = "Webcam Full HD 1080p", Preco = 189.00m, Categoria = "Periféricos", Estoque = 14 },
        new { Id = 11, Nome = "Mesa Gamer", Preco = 1200.00m, Categoria = "Acessórios", Estoque = 5 },
        new { Id = 12, Nome = "Computador Gamer", Preco = 7200.00m, Categoria = "Hardware", Estoque = 3 }
    };

    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(itensCatalogo);
    }
}