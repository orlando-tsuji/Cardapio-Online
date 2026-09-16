import React from "react";
import type { Produto } from "@/types/produto";

type CarrinhoContextType = {
  carrinho: Produto[];
  adicionarProduto: (produto: Produto) => void;
  removerProduto: (produtoId: number) => void;
};

const CarrinhoContext = React.createContext({} as CarrinhoContextType);

export function CarrinhoProvider({ children }: { children: React.ReactNode }) {
  const [carrinho, setCarrinho] = React.useState<Produto[]>(() => {
    const carrinhoSalvo = localStorage.getItem("carrinho");

    if (!carrinhoSalvo) {
      return [];
    }

    return JSON.parse(carrinhoSalvo);
  });

  React.useEffect(() => {
    localStorage.setItem("carrinho", JSON.stringify(carrinho));
  }, [carrinho]);

  function adicionarProduto(produto: Produto) {
    setCarrinho((carrinhoAtual) => [...carrinhoAtual, produto]);
  }

  function removerProduto(produtoId: number) {
    setCarrinho((carrinhoAtual) =>
      carrinhoAtual.filter((produto) => produto.id !== produtoId)
    );
  }

  return (
    <CarrinhoContext.Provider
      value={{ carrinho, adicionarProduto, removerProduto }}
    >
      {children}
    </CarrinhoContext.Provider>
  );
}

export function useCarrinho() {
  return React.useContext(CarrinhoContext);
}