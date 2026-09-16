import React from "react";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
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

const CarrinhoList = () => {
  const { carrinho } = useCarrinho();

  return (
    <div className="text-white">
      <ul className="w-full grid grid-cols-1 gap-4">
        {carrinho.length === 0 ? (
          <p className="text-center text-lg">O carrinho está vazio.</p>
        ) : (
          carrinho.map((produto, id) => (
            <li key={id} className="w-full">
              <Card
                size="sm"
                className="max-w-full relative flex-row m-0 !pb-0 bg-white/10 text-white border border-white/10"
              >
                {/* <div className="absolute inset-0 z-30 aspect-video bg-black/35" /> */}
                <img
                  src={produto.imagem}
                  alt={produto.nome}
                  className="relative z-20 aspect-video rounded-xl w-64 object-cover"
                />
                <div className="flex flex-col justify-between gap-4 align-center py-3 w-full">
                  <CardHeader className="flex">
                    <CardAction>
                      <Badge variant="default">
                        {produto.categoriaId
                          .map((categoria) => categoria.nome)
                          .join(", ")}
                      </Badge>
                    </CardAction>
                  </CardHeader>
                  <CardContent className="flex flex-col gap-4">
                    <CardTitle>{produto.nome}</CardTitle>
                    <CardDescription>{produto.descricao}</CardDescription>
                    <CardPrice>R$ {produto.preco.toFixed(2)}</CardPrice>
                  </CardContent>
                </div>
                {/* <CardFooter className="bg-transparent border-none">
                  <Button
                    className="w-full text-black"
                    variant="outline"
                    onClick={() => adicionarProduto(produto)}
                  >
                    Adicionar
                  </Button>
                </CardFooter> */}
              </Card>
            </li>
          ))
        )}
      </ul>
    </div>
  );
};

export default CarrinhoList;
