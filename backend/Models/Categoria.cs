using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public sealed class Categoria
    {
        public long Id { get; private set; }
        public long? DescontoId { get; private set; }
        public string Nome { get; private set; }
        public Desconto Desconto { get; private set; }

        private Categoria()
        {
            // Usado pelo EF Core para materialização da entidade a partir do banco.
        }

        public Categoria(string nome, long descontoId, Desconto desconto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da categoria é obrigatório.", nameof(nome));

            if (desconto == null)
                throw new ArgumentNullException(nameof(desconto), "O desconto da categoria é obrigatório.");

            Id = 0; // O Id será gerado pelo banco de dados.
            Nome = nome.Trim();
            DescontoId = descontoId;
            Desconto = desconto;
        }
    }
}