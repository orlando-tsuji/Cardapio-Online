# 🍕 Cardápio Online

Cardápio digital para restaurantes e pizzarias: o cliente navega pelos produtos, filtra por categoria e monta o carrinho de pedidos.

> 🚧 **Projeto em desenvolvimento.** O back-end em ASP.NET Core e o front-end em React estão sendo construídos em paralelo. Hoje, o front-end consome uma API simulada (json-server) enquanto os endpoints .NET são concluídos. Veja o [roadmap](#-roadmap).

---

## 📌 Sobre o projeto

O objetivo é construir uma aplicação full-stack completa, do banco de dados à interface, aplicando boas práticas de arquitetura em camadas no back-end e componentização no front-end.

**Funcionalidades atuais**

- Listagem de produtos com imagem, descrição, categoria e preço
- Filtro de produtos por categoria
- Carrinho de compras com persistência no navegador (`localStorage`)
- API REST para consulta e cadastro de produtos
- Cálculo de preço com desconto por categoria, feito na consulta ao banco
- Documentação interativa da API com Swagger

---

## 🛠️ Tecnologias

### Back-end

| Tecnologia | Uso |
|---|---|
| **C# / .NET 10** | Linguagem e plataforma |
| **ASP.NET Core Web API** | API REST com Controllers |
| **Entity Framework Core 10** | ORM, LINQ e migrations |
| **SQL Server** | Banco de dados relacional |
| **Swagger (Swashbuckle)** | Documentação e testes dos endpoints |

### Front-end

| Tecnologia | Uso |
|---|---|
| **React 19 + TypeScript** | Interface e tipagem |
| **Vite** | Build e servidor de desenvolvimento |
| **Tailwind CSS 4 + shadcn/ui** | Estilização e componentes de interface |
| **React Router** | Navegação entre páginas |
| **Context API** | Estado global do carrinho |
| **json-server** | API simulada durante o desenvolvimento |

---

## 🏗️ Arquitetura do back-end

A API segue uma arquitetura em camadas, em que cada camada tem uma responsabilidade:

```
Requisição HTTP
      │
      ▼
Controllers   → recebem a requisição e devolvem a resposta HTTP
      │
      ▼
Services      → regras de negócio e validações
      │
      ▼
Repositories  → acesso a dados com Entity Framework e LINQ
      │
      ▼
SQL Server
```

**Decisões de implementação**

- **DTOs** separam o contrato da API das entidades do banco (`CreateProdutoRequestDTO`, `GetProdutosResponseDTO`).
- **Entidades protegidas:** construtores validam o estado inicial (nome obrigatório, preço maior que zero, desconto entre 0 e 100%), e o EF Core usa um construtor privado para materializar os dados.
- **Injeção de dependência** registra Services e Repositories por interface (`IProdutoServices`, `IProdutoRepository`).
- **Projeção com LINQ:** as consultas usam `Select` direto para DTO e calculam o preço com desconto no próprio SQL, sem carregar entidades desnecessárias.
- **`ServiceResponse<T>`** padroniza o retorno dos serviços com sucesso, dados e lista de erros.
- **Fluent API** (`IEntityTypeConfiguration`) mapeia tabelas, tamanhos de campo e relacionamentos.

### Modelo de dados

```
Desconto (1) ──── (N) Categoria (1) ──── (N) Produto
```

- **Produto:** nome, descrição, preço, imagem, destaque, disponibilidade, avaliação e ingredientes
- **Categoria:** agrupa os produtos e pode ter um desconto
- **Desconto:** percentual aplicado aos produtos da categoria

---

## 🔌 Endpoints

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/obter-produtos` | Lista todos os produtos com categoria e preço com desconto |
| `GET` | `/obter-produtos/{id}` | Busca um produto pelo ID |
| `POST` | `/novo-produto` | Cadastra um novo produto |

Com a API rodando, a documentação fica em `http://localhost:5112/swagger`.

---

## 📁 Estrutura de pastas

```
Cardapio-Online/
├── backend/
│   ├── Controllers/        # Endpoints da API
│   ├── Data/               # DbContext e migrations
│   ├── DTOs/               # Objetos de entrada e saída
│   ├── Models/             # Entidades de domínio
│   │   └── Configurations/ # Mapeamento Fluent API
│   ├── Repositories/       # Acesso a dados
│   ├── Services/           # Regras de negócio
│   └── Program.cs          # Configuração e injeção de dependência
│
└── frontend/
    ├── db.json             # Dados da API simulada
    └── src/
        ├── components/     # Cardápio, carrinho, layout e UI
        ├── contexts/       # Estado do carrinho
        ├── pages/          # Home e Carrinho
        └── types/          # Tipos TypeScript
```

---

## ▶️ Como executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (Express ou LocalDB)
- [Node.js](https://nodejs.org/) 20 ou superior
- Ferramenta do EF Core: `dotnet tool install --global dotnet-ef`

### Back-end

```bash
cd backend

# Ajuste a connection string "DefaultConnection" em appsettings.Development.json, se necessário

dotnet restore
dotnet ef database update
dotnet run
```

A API sobe em `http://localhost:5112`, e o Swagger abre em `/swagger`.

### Front-end

```bash
cd frontend
npm install

# Terminal 1: API simulada na porta 3000
npx json-server db.json --port 3000

# Terminal 2: aplicação React
npm run dev
```

Acesse o endereço exibido pelo Vite (normalmente `http://localhost:5173`).

---

## 🗺️ Roadmap

- [x] Estrutura da API em camadas (Controllers, Services, Repositories)
- [x] Entidades, relacionamentos e migrations com EF Core e SQL Server
- [x] Listagem e cadastro de produtos
- [x] Interface do cardápio com filtro por categoria
- [x] Carrinho com persistência local
- [ ] Endpoints de categorias e descontos
- [ ] Integrar o front-end com a API .NET (substituindo o json-server) e configurar CORS
- [ ] Quantidade de itens e total no carrinho
- [ ] Finalização do pedido
- [ ] Integração de pagamento
- [ ] Tratamento global de erros e validações com respostas padronizadas
- [ ] Testes unitários (xUnit)
- [ ] Deploy

---

## 👤 Autor

**Orlando Tsuji Neto**, Desenvolvedor Back-end .NET

[LinkedIn](https://www.linkedin.com/in/orlando-tsuji-38659b168) · [GitHub](https://github.com/orlando-tsuji)
