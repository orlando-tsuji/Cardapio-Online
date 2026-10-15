using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CardapioDbContext _context;

        public ProdutoRepository(CardapioDbContext context)
        {
            _context = context;
        }

        // Projeção reutilizada pelas consultas: o EF Core traduz para SQL,
        // incluindo o cálculo do preço com desconto da categoria.
        private static readonly Expression<Func<Produto, GetProdutosResponseDTO>> ProjecaoProduto = p => new GetProdutosResponseDTO
        {
            Id = p.Id,
            Nome = p.Nome,
            PrecoComDesconto = p.Categoria.DescontoId != null ? p.Preco * (1 - p.Categoria.Desconto.Percentual / 100) : p.Preco,
            Preco = p.Preco,
            Descricao = p.Descricao,
            Imagem = p.Imagem,
            Destaque = p.Destaque,
            Disponivel = p.Disponivel,
            Avaliacao = p.Avaliacao,
            Ingredientes = p.Ingredientes,

            Categoria = p.Categoria != null ? new CategoriaResponseDTO
            {
                Id = p.Categoria.Id,
                Nome = p.Categoria.Nome,
            } : null
        };

        public async Task<IEnumerable<GetProdutosResponseDTO>> ObterProdutosAsync()
        {
            return await _context.Produtos
                .AsNoTracking()
                .Select(ProjecaoProduto)
                .ToListAsync();
        }

        public async Task<GetProdutosResponseDTO> ObterProdutoPorIdAsync(long id)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(ProjecaoProduto)
                .FirstOrDefaultAsync();
        }

        public async Task<GetProdutosResponseDTO> ObterProdutosByNomeAsync(string nome)
        {
            return await _context.Produtos
                .AsNoTracking()
                .Where(p => p.Nome == nome)
                .Select(ProjecaoProduto)
                .FirstOrDefaultAsync();
        }

        public async Task<ProdutoResponseDTO> CriarProduto(CreateProdutoRequestDTO request)
        {

            var produto = new Produto(request.Nome,
                                        request.Descricao,
                                        request.CategoriaId,
                                        request.Preco,
                                        request.Imagem,
                                        request.Destaque,
                                        request.Disponivel,
                                        request.Avaliacao,
                                        request.Ingredientes);

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return new ProdutoResponseDTO
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco
            };
        }
    }
}