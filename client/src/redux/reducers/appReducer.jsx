import { combineReducers } from "redux";
import AdminProductReducer from "./AdminProductReducer";
import LoginAdminReducer from "./LoginAdminReducer";
import AdminProductTypeReducer from './AdminProductTypeReducer'


const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer,
    AdminProductReducer : AdminProductReducer,
    AdminProductTypeReducer,
})

export default appReducers