using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.DTOs;

namespace backend.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<GetProdutosResponseDTO>> ObterProdutosAsync();
        Task<ProdutoResponseDTO> CriarProduto(CreateProdutoRequestDTO request);
        Task<GetProdutosResponseDTO> ObterProdutosByNomeAsync(string nome);
    }
}