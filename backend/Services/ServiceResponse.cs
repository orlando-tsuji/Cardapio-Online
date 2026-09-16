using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    public class ServiceResponse<T>
    {
        public bool Sucesso { get; set; }
        public T Dados { get; set; }
        public List<string> Erros { get; set; } = new();
    }
}