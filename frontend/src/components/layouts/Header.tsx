import { Link } from "react-router-dom";
import { useCarrinho } from "@/contexts/CarrinhoContext";

const Header = () => {
  const { carrinho } = useCarrinho();

  return (
    <div className="w-full h-[60px] bg-gray-800 text-white flex items-center justify-center p-4">
      <div className="container flex items-center justify-between">
        <span>Logo</span>

        <Link to="/">Home</Link>

        <Link to="/carrinho">
          Carrinho ({carrinho.length})
        </Link>
      </div>
    </div>
  );
};

export default Header;