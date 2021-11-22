import { combineReducers } from "redux";
import AdminProductReducer from "./AdminProductReducer";
import LoginAdminReducer from "./LoginAdminReducer";
import AdminProductTypeReducer from './AdminProductTypeReducer'
import HeaderProductTypeReducer from "./HeaderProductTypeReducer";

const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer,
    AdminProductReducer : AdminProductReducer,
    AdminProductTypeReducer,
    HeaderProductTypeReducer,
})

export default appReducers