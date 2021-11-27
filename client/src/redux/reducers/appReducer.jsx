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

const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer,
    AdminProductReducer : AdminProductReducer,
    AdminProductTypeReducer,
    HeaderProductTypeReducer,
    AdminMachineReducer,
    AdminWireReducer,
    AdminNCCReducer,
    AdminBrandReducer,
    ShopPageReducer,
    HomePageReducer,
    ProductPageReducer
})

export default appReducers