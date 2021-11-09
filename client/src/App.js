import logo from './logo.svg';
import './App.css';
import Shop from './pages/ShopPages/Shop/Shop';
import { Route, Routes } from 'react-router';
import AdminLayout from './layouts/AdminLayout/AdminLayout';
import ProductsAdmin from './pages/AdminPages/ProductsAdmin/ProductsAdmin';
import ShopLayout from './layouts/ShopLayout/ShopLayout';
import LoginAdminPage from './pages/LoginAdminPage/LoginAdminPage';

function App() {
  return (
    <Routes>
      <Route element={<ShopLayout />}>
        <Route path='/shop' element={<Shop />} />
      </Route>
      <Route element={<AdminLayout />}>
        <Route path='/admin/products' element={<ProductsAdmin />} />
      </Route>
      <Route path='/auth/login' element={<LoginAdminPage /> } />
    </Routes>

  );
}

export default App;
