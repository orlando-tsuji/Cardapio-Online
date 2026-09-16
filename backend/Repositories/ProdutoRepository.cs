using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<GetProdutosResponseDTO>> ObterProdutosAsync()
        {
            var produtos = await _context.Produtos.Select(p => new GetProdutosResponseDTO
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

            }).ToListAsync();

            return produtos;
        }

        public async Task<GetProdutosResponseDTO> ObterProdutosByNomeAsync(string nome)
        {
            var produto = await _context.Produtos
                .Where(p => p.Nome == nome)
                .Select(p => new GetProdutosResponseDTO
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

                }).FirstOrDefaultAsync();

                return produto;
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