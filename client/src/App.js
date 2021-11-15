import logo from './logo.svg';
import './App.css';
import Shop from './pages/ShopPages/Shop/Shop';
import { Navigate, Route, Routes } from 'react-router';
import AdminLayout from './layouts/AdminLayout/AdminLayout';
import ProductsAdmin from './pages/AdminPages/ProductsAdmin/ProductsAdmin';
import ShopLayout from './layouts/ShopLayout/ShopLayout';
import LoginAdminPage from './pages/LoginAdminPage/LoginAdminPage';
import CustomAdmin from './pages/AdminPages/CustomAdmin/CustomAdmin';
import StaffAdmin from './pages/AdminPages/StaffAdmin/StaffAdmin';
import ProductTypeAdmin from './pages/AdminPages/ProductTypeAdmin/ProductTypeAdmin';
import PermissionAdmin from './pages/AdminPages/PermissionAdmin/PermissionAdmin';
import UserAdmin from './pages/AdminPages/UserAdmin/UserAdmin';
import Home from './pages/ShopPages/Home/Home';

function App() {
  return (
    <Routes>
      <Route path='/' exact element={<Navigate to="/home" />} />
      <Route element={<ShopLayout />}>
        <Route path='/home' element={<Home />} />
        {/* <Route path='/shop' element={<Shop />} /> */}
        <Route path='/shop/:productId' element={<Shop />} />
      </Route>
      <Route element={<AdminLayout />}>
        <Route path='/admin/account' element={<UserAdmin />} />
        <Route path='/admin/products' element={<ProductsAdmin />} />
        <Route path='/admin/custom' element={<CustomAdmin />} />
        <Route path='/admin/staff' element={<StaffAdmin />} />
        <Route path='/admin/product-type' element={<ProductTypeAdmin />} />
        <Route path='/admin/permission' element={<PermissionAdmin />} />
      </Route>
      <Route path='/auth/login' element={<LoginAdminPage /> } />
    </Routes>

  );
}

export default App;
