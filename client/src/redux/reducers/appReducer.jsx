import { combineReducers } from "redux";
import AdminProductReducer from "./AdminProductReducer";
import LoginAdminReducer from "./LoginAdminReducer";


const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer,
    AdminProductReducer : AdminProductReducer,
})

export default appReducers