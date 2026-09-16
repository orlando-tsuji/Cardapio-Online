import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Carrinho from "./pages/Carrinho";
import { CarrinhoProvider } from "./contexts/CarrinhoContext";

function App() {
  return (
    <CarrinhoProvider>
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/carrinho" element={<Carrinho />} />
        </Routes>
      </BrowserRouter>
    </CarrinhoProvider>
  );
}

export default App;