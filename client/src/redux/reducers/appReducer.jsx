import { combineReducers } from "redux";
import AdminProductReducer from "./AdminProductReducer";
import LoginAdminReducer from "./LoginAdminReducer";
import AdminProductTypeReducer from './AdminProductTypeReducer'
import HeaderProductTypeReducer from "./HeaderProductTypeReducer";
import AdminMachineReducer from "./AdminMachineReducer";
import AdminWireReducer from "./AdminWireReducer";
import AdminNCCReducer from "./AdminNCCReducer";
import AdminBrandReducer from "./AdminBrandReducer";
import ShopPageReducer from './ShopPageReducer'
import HomePageReducer from './HomePageReducer'
import ProductPageReducer from './ProductPageReducer'
import UserKhachHangReducer from './UserKhachHangReducer'
import AdminCustomReducer from './AdminCustomReducer'

const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer,
    AdminProductReducer : AdminProductReducer,
    AdminProductTypeReducer,
    AdminCustomReducer,
    AdminMachineReducer,
    AdminWireReducer,
    AdminNCCReducer,
    AdminBrandReducer,
    HeaderProductTypeReducer,
    ShopPageReducer,
    HomePageReducer,
    ProductPageReducer,
    UserKhachHangReducer
})

export default appReducers