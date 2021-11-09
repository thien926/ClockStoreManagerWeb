import { combineReducers } from "redux";
import LoginAdminReducer from "./LoginAdminReducer";


const appReducers = combineReducers({
    LoginAdminReducer : LoginAdminReducer
})

export default appReducers