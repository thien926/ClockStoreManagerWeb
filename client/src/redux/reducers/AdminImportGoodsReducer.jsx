// const initialState = {
//     dataLoad: {
//         "listSP": [
//             {
//                 "id": 1,
//                 "lspId": 4,
//                 "brandId": 1,
//                 "wireId": 1,
//                 "machineId": 1,
//                 "name": "Đồng hồ nam chính hãng LOBINNI L3603-4",
//                 "amount": 25,
//                 "price": 2680000,
//                 "description": "TÍNH NĂNG MOONPHASE: Ô cửa sổ với tính năng Moonphase (xem lịch tuần trăng – lịch âm) trên góc 6h có thể coi là điểm nhấn đắt giá của chiếc đồng hồ này. Mặt trăng tròn cùng các vì sao lấp lánh nổi bật trên nền trời đêm xanh thẳm chính là một thiết kế vô cùng bắt mắt.",
//                 "img": "/image/sp8.jpg",
//                 "status": 1,
//                 "lsp": {
//                     "id": 4,
//                     "name": "ĐỒNG HỒ NAM",
//                     "description": "Đồng hồ dành cho nam"
//                 },
//                 "brand": {
//                     "id": 1,
//                     "name": "THƯƠNG HIỆU NAMKIN"
//                 },
//                 "wire": {
//                     "id": 1,
//                     "name": "Dây da"
//                 },
//                 "machine": {
//                     "id": 1,
//                     "name": "Máy cơ"
//                 },
//                 "chitietHDs": [],
//                 "chiTietPNs": []
//             }
//         ],
//         "search": "1",
//         "typeSearch": "",
//         "pageIndex": 1,
//         "pageSize": 9,
//         "count": 111,
//         "range": 9,
//         "totalPage": 13
//     },
//     dataAction: {},
//     message: {
//         type: '',
//         value: ''
//     }
// }

import { CHOOSE_ITEM_IMPORT_GOOD_ADMIN, GET_IMPORT_GOOD_ADMIN } from "../actions/AdminImportGoodsAction";

const initialState = {
    dataLoad: {},
    dataAction: {},
    message: {
        type: '',
        value: ''
    }
}

const AdminImportGoodsReducer = (state = initialState, action) => {
    switch (action.type) {
        case 'RESET_MESSAGE_IMPORT_GOOD_ADMIN':
            return {
                ...state,
                message: action.payload
            }
        case GET_IMPORT_GOOD_ADMIN:
            return {
                ...state,
                dataLoad: action.payload
            }
        case CHOOSE_ITEM_IMPORT_GOOD_ADMIN:
            return {
                ...state,
                dataAction: action.payload.dataAction,
                message : action.payload.message
            };
        
        default:
            return {
                ...state
            }
    }
}

export default AdminImportGoodsReducer