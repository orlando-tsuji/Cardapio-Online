using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class GetProdutosResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoComDesconto { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Destaque { get; set; }
        public bool Disponivel { get; set; }
        public float Avaliacao { get; set; }
        public string Ingredientes { get; set; }

        public CategoriaResponseDTO Categoria { get; set; }
    }

    public class CategoriaResponseDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}