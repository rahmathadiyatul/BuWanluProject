import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';

import HomePage from './Views/Homepage/Home';
import ProductList from './Views/Products/ProductList';
import CustomerList from './Views/Customers/CustomerList';

function App() {
  return (
    <BrowserRouter>
      <div>
        <Routes>
          <Route exact path="/home" element={<HomePage></HomePage>} />
          <Route path="/products" element={<ProductList />} />
          <Route path="/customers" element={<CustomerList />} />
          <Route exact path="/" element={<HomePage></HomePage>} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
