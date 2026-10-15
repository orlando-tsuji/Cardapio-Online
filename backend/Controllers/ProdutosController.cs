using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using backend.Services.Interfaces;
using backend.DTOs;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoServices _produtoServices;
        public ProdutosController(IProdutoServices produtoServices)
        {
            _produtoServices = produtoServices;
        }

        [HttpGet("/obter-produtos")]
        public async Task<ActionResult<IEnumerable<GetProdutosResponseDTO>>> GetProdutos()
        {
            var produtos = await _produtoServices.ObterProdutosAsync();

            return Ok(produtos);
        }

        [HttpGet("/obter-produtos/{id}")]
        public async Task<ActionResult<GetProdutosResponseDTO>> GetProdutosById(long id)
        {
            var produto = await _produtoServices.ObterProdutoPorIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost("/novo-produto")]
        public async Task<ActionResult<ProdutoResponseDTO>> AdicionarProduto([FromBody] CreateProdutoRequestDTO produtoDto)
        {
            var resultado = await _produtoServices.CriarProduto(produtoDto);

            if (!resultado.Sucesso)
            {
                return BadRequest(resultado.Erros);
            }

            return CreatedAtAction(nameof(GetProdutosById), new { id = resultado.Dados.Id }, resultado.Dados);
        }
    }
}