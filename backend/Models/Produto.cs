using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public sealed class Produto
    {
        public long Id { get; private set; }
        public long? CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; private set; } = null!;
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        public bool Destaque { get; set; }
        public bool Disponivel { get; set; }
        public float Avaliacao { get; set; }
        public string Ingredientes { get; set; }

        private Produto()
        {
            // Usado pelo EF Core para materialização da entidade a partir do banco.
        }

        public Produto(string nome, string descricao, long? categoriaId, decimal preco, string imagem, bool destaque, bool disponivel, float avaliacao, string ingredientes)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do produto é obrigatório.", nameof(nome));

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do produto é obrigatória.", nameof(descricao));

            if (preco <= 0)
                throw new ArgumentException("O preço do produto deve ser maior que zero.", nameof(preco));

            if (string.IsNullOrWhiteSpace(imagem))
                throw new ArgumentException("A imagem do produto é obrigatória.", nameof(imagem));
                
            CategoriaId = categoriaId;
            Nome = nome.Trim();
            Descricao = descricao;
            Preco = preco;
            Imagem = imagem;
            Destaque = destaque;
            Disponivel = disponivel;
            Avaliacao = avaliacao;
            Ingredientes = ingredientes;
        }
    }
}