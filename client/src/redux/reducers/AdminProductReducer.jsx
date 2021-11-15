
import { GET_PRODUCT_ADMIN } from "../actions/AdminProductAction";

// const initialState = {
//     Id  : '',
//     LSPId  : '',
//     brandId : '',
//     wireId : '',
//     machineId : '',
//     nccId : '',
//     name  : '',
//     amount : '',
//     price : '',
//     description  : '',
//     img  : ''
// }

const initialState = [];

const AdminProductReducer = (state = initialState, action) => {       //action.type action.payload
    switch (action.type) {
        case GET_PRODUCT_ADMIN:
            return action.payload;
        
        default:
            return {
                ...state
            }
    }
}

export default AdminProductReducer