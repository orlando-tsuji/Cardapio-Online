using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.DTOs;

namespace backend.Services.Interfaces
{
    public interface IProdutoServices
    {
        Task<IEnumerable<GetProdutosResponseDTO>> ObterProdutosAsync();
        Task<ServiceResponse<ProdutoResponseDTO>> CriarProduto(CreateProdutoRequestDTO request);
    }
}