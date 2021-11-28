// const initialState = {
//     dataValue : {
//         listNCC: [
//             {
//                 id: 2,
//                 name: "Cty Bến Tre",
//                 address: "Bến Tre",
//                 phone: "0364117408",
//                 fax: "4598-8789-8789-7897"
//             }
//         ],
//         sort: "name-asc",
//         search: "bến",
//         pageIndex: 1,
//         pageSize: 9,
//         count: 1,
//         range: 9,
//         totalPage: 1
//     },
//     message : ''
// }

import { ADD_NCC_ADMIN, DELETE_NCC_ADMIN, GET_NCC_ADMIN, RESET_MESSAGE_NCC_ADMIN, UPDATE_NCC_ADMIN } from "../actions/AdminNCCAction";

const initialState = {
    dataValue : {},
    message : ''
}

const AdminNCCReducer = (state = initialState, action) => {
    switch (action.type) {
        case RESET_MESSAGE_NCC_ADMIN:
            return {
                ...state,
                message : action.payload
            }
        case GET_NCC_ADMIN:
            return {
                ...state,
                dataValue : action.payload
            }
        case ADD_NCC_ADMIN:
            return {
                ...state,
                message: action.payload
            };
        case UPDATE_NCC_ADMIN:
            return {
                ...state,
                message: action.payload
            };
        case DELETE_NCC_ADMIN:
            return {
                ...state,
                message: action.payload
            };
        default:
            return {
                ...state
            }
    }
}

export default AdminNCCReducer
