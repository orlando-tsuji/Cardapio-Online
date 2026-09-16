export interface Categoria {
  id: number;
  nome: string;
}

export interface Produto {
  id: number;
  nome: string;
  descricao: string;
  categoriaId: Categoria[];
  preco: number;
  precoPromocional: number | null;
  imagem: string;
  destaque: boolean;
  disponivel: boolean;
  tempoPreparo: number;
  avaliacao: number;
  ingredientes: string[];
}

export interface CardapioDatabase {
  categorias: Categoria[];
  produtos: Produto[];
}
