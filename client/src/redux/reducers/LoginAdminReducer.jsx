
import { LOGIN_ADMIN, GET_USER } from "../actions/LoginAdminAction";

const initialState = {
    user : '',
    password : '',
    name : '',
    phone : '',
    address : '',
    gender : '',
    dateborn : '',
    quyenId : 0,
    status : 0
}

const LoginAdminReducer = (state = initialState, action) => {       //action.type action.payload
    switch (action.type) {
        case LOGIN_ADMIN:
            return action.payload;
        case GET_USER :
            return action.payload;
        default:
            return {
                ...state
            }
    }
}

export default LoginAdminReducer