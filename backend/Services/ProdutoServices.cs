using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services.Interfaces;
using backend.Repositories;
using backend.Models;
using backend.DTOs;

namespace backend.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IProdutoRepository _ProdutoRepository;
        public ProdutoServices(IProdutoRepository ProdutoRepository)
        {
            _ProdutoRepository = ProdutoRepository;
        }

        public async Task<IEnumerable<GetProdutosResponseDTO>> ObterProdutosAsync()
        {
            var produtos = await _ProdutoRepository.ObterProdutosAsync();

            return produtos;
        }

        public async Task<GetProdutosResponseDTO> ObterProdutoPorIdAsync(long id)
        {
            return await _ProdutoRepository.ObterProdutoPorIdAsync(id);
        }

        public async Task<ServiceResponse<ProdutoResponseDTO>> CriarProduto(CreateProdutoRequestDTO request)
        {
            var resultado = new ServiceResponse<ProdutoResponseDTO>();

            if(string.IsNullOrWhiteSpace(request.Nome))
            {
                resultado.Sucesso = false;
                resultado.Erros.Add("O nome do produto é obrigatório.");
                return resultado;
            }

            var nomeExists = await _ProdutoRepository.ObterProdutosByNomeAsync(request.Nome.Trim());

            if(nomeExists is not null)
            {
                resultado.Sucesso = false;
                resultado.Erros.Add("Produto já cadastrado.");
                return resultado;
            }

            try
            {
                var produtoResponse = await _ProdutoRepository.CriarProduto(request);

                resultado.Sucesso = true;
                resultado.Dados = produtoResponse;
            }
            catch (ArgumentException ex)
            {
                // Validações do construtor de Produto (descrição, preço, imagem) viram erro de requisição, não 500.
                resultado.Sucesso = false;
                resultado.Erros.Add(ex.Message);
            }

            return resultado;
        }
    }
}