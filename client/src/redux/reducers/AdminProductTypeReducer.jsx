
// const initialState = {
//     "listLSP": [
//         {
//             "id": 1,
//             "name": "ĐỒNG HỒ ĐỂ BÀN",
//             "description": "Đồng hồ dành để bàn cho việc học và làm việc",
//             "sanPhams": []
//         }
//     ],
//     "sort": "name-asc",
//     "search": "",
//     "pageIndex": 1,
//     "pageSize": 9,
//     "count": 5,
//     "range": 9,
//     "totalPage": 1
// }

import { GET_PRODUCT_TYPE_ADMIN, 
    UPDATE_PRODUCT_TYPE_ADMIN, 
    ADD_PRODUCT_TYPE_ADMIN 
} from "../actions/AdminProductTypeAction";

const initialState = {
    // data : {},
    // message : ''
};

const AdminProductTypeReducer = (state = initialState, action) => {       //action.type action.payload
    switch (action.type) {
        case GET_PRODUCT_TYPE_ADMIN:
            return action.payload;
        case ADD_PRODUCT_TYPE_ADMIN:
            return action.payload;
        case UPDATE_PRODUCT_TYPE_ADMIN: 
            return action.payload;
        default:
            return {
                ...state
            }
    }
}

export default AdminProductTypeReducer

// return {
//     ...state,
//     data: [...action.payload]
// };