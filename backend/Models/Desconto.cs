using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public sealed class Desconto
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Percentual { get; private set; }

        private Desconto()
        {
            // Usado pelo EF Core para materialização da entidade a partir do banco.
        }

        public Desconto(string nome, decimal percentual)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do desconto é obrigatório.", nameof(nome));

            if (percentual < 0 || percentual > 100)
                throw new ArgumentException("O percentual do desconto deve estar entre 0 e 100.", nameof(percentual));

            Id = 0; // O Id será gerado pelo banco de dados.
            Nome = nome.Trim();
            Percentual = percentual;
        }
    }
}