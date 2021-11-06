import logo from './logo.svg';
import './App.css';
import Shop from './pages/Shop/Shop/Shop';
import { Route, Routes } from 'react-router';
import AdminLayout from './layouts/AdminLayout/AdminLayout';
import ProductsAdmin from './pages/Admin/ProductsAdmin/ProductsAdmin';
import ShopLayout from './layouts/ShopLayout/ShopLayout';

function App() {
  return (
    // <div className="App">
    //   <header className="App-header">
    //     <img src={logo} className="App-logo" alt="logo" />
    //     <p>
    //       Edit <code>src/App.js</code> and save to reload.
    //     </p>
    //     <a
    //       className="App-link"
    //       href="https://reactjs.org"
    //       target="_blank"
    //       rel="noopener noreferrer"
    //     >
    //       Learn React
    //     </a>
    //   </header>
    // </div>
    <Routes>

      <Route element={<ShopLayout />}>
        <Route path='/shop' element={<Shop />} />
      </Route>
      <Route element={<AdminLayout />}>
        <Route path='/admin/products' element={<ProductsAdmin />} />
      </Route>
    </Routes>

  );
}

export default App;
