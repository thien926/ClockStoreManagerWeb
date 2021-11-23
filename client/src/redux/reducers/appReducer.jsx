import { combineReducers } from "redux";
import AdminProductReducer from "./AdminProductReducer";
import LoginAdminReducer from "./LoginAdminReducer";
import AdminProductTypeReducer from './AdminProductTypeReducer'
import HeaderProductTypeReducer from "./HeaderProductTypeReducer";
import AdminMachineReducer from "./AdminMachineReducer";
import AdminWireReducer from "./AdminWireReducer";
import AdminNCCReducer from "./AdminNCCReducer";

const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer,
    AdminProductReducer : AdminProductReducer,
    AdminProductTypeReducer,
    HeaderProductTypeReducer,
    AdminMachineReducer,
    AdminWireReducer,
    AdminNCCReducer
})

export default appReducers