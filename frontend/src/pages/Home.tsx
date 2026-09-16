import Cardapio from "@/components/Cardapio";
import Header from "../components/layouts/Header";
import { GET_CATEGORIAS, GET_PRODUTOS } from "@/api";
import React from "react";
import type { Produto, Categoria } from "@/types/produto";
import { Button } from "@/components/ui/button";

async function getProdutos(): Promise<Produto[]> {
  try {
    const { url, options } = GET_PRODUTOS();
    const response = await fetch(url, options);

    if (!response.ok) {
      throw new Error("Não foi possível buscar os produtos.");
    }
    const data = await response.json();

    return data;
  } catch (error) {
    throw new Error("erro: " + error);
  }
}

async function getCategorias(): Promise<Categoria[]> {
  try {
    const { url, options } = GET_CATEGORIAS();
    const response = await fetch(url, options);

    if (!response.ok) {
      throw new Error("Não foi possível buscar os produtos.");
    }
    const data = await response.json();

    return data;
  } catch (error) {
    throw new Error("erro: " + error);
  }
}

const Home = () => {
  const [filter, setFilter] = React.useState<string>("all");
  const [produtos, setProdutos] = React.useState<Produto[]>([]);
  const [produtosFiltrados, setProdutosFiltrados] = React.useState<Produto[]>([]);
  const [categorias, setCategorias] = React.useState<Categoria[]>([]);

  React.useEffect(() => {
    setProdutosFiltrados(
    filter === "all"
      ? produtos
      : produtos.filter((produto) => produto.categoriaId[0].nome === filter),
    );
  }, [filter])

  React.useEffect(() => {
    setProdutosFiltrados(produtos)
  }, [produtos])

  React.useEffect(() => {
    async function fetchProdutos() {
      setCategorias(await getCategorias());
      setProdutos(await getProdutos());
    }
    
    fetchProdutos();
  }, []);

  return (
    <div className="w-full min-h-screen bg-gradient-to-r from-[#030303] to-[#221202]">
      <Header />
      <div className="container mx-auto py-10">
        <div className="grid grid-flow-col mb-8 gap-2">
          <Button className="" variant="outline" onClick={() => setFilter("all")}>
            All
          </Button>
          {categorias.map((categoria) => (
            <Button
              key={categoria.id}
              onClick={() => setFilter(categoria.nome)}
            >
              {categoria.nome}
            </Button>
          ))}
        </div>
        <Cardapio produtos={produtosFiltrados} />
      </div>
    </div>
  );
};

export default Home;
