import Header from "@/components/layouts/Header";
import CarrinhoList from "@/components/CarrinhoList";

const Carrinho = () => {
  return (
    <div className="w-full min-h-screen bg-gradient-to-r from-[#030303] to-[#221202]">
      <Header />
      <div className="container mx-auto py-10"><CarrinhoList /></div>
    </div>
  );
};

export default Carrinho;
