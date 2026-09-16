using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class CreateProdutoRequestDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public long? CategoriaId { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Destaque { get; set; }
        public bool Disponivel { get; set; }
        public float Avaliacao { get; set; }
        public string Ingredientes { get; set; }
    }
}