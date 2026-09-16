// import React from "react";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import React from "react";
import type { Produto } from "@/types/produto";
import { useCarrinho } from "@/contexts/CarrinhoContext";
import {
  Card,
  CardAction,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardPrice,
  CardTitle,
} from "@/components/ui/card";

const Cardapio = ({ produtos }: { produtos: Produto[] }) => {  
  const { adicionarProduto } = useCarrinho();

  return (
    <div className="text-white">
      <ul className="w-fit grid grid-cols-4 gap-4">
        {produtos.map((produto) => (
          <li key={produto.id} className="w-fit">
            <Card size="sm" className="relative mx-auto w-full max-w-sm pt-0 bg-white/10 text-white border border-white/10">
              {/* <div className="absolute inset-0 z-30 aspect-video bg-black/35" /> */}
              <img
                src={produto.imagem}
                alt={produto.nome}
                className="relative z-20 aspect-video w-full object-cover"
              />
              <CardHeader className="flex">
                <CardAction>
                  <Badge variant="default">
                    {produto.categoriaId.map((categoria) => categoria.nome).join(", ")}
                  </Badge>
                </CardAction>
              </CardHeader>
              <CardContent className="flex flex-col gap-4">
                <CardTitle>{produto.nome}</CardTitle>
                <CardDescription>{produto.descricao}</CardDescription>
                <CardPrice>R$ {produto.preco.toFixed(2)}</CardPrice>
              </CardContent>
              <CardFooter className="bg-transparent border-none">
                <Button className="w-full text-black" variant='outline' onClick={() => adicionarProduto(produto)}>
                  Adicionar
                </Button>
              </CardFooter>
            </Card>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default Cardapio;
