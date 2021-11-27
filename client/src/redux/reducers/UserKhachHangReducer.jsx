// const initialState = {
//     dataValue : {
//         "user": "thong",
//         "password": "$2a$11$B9Td1efkOvZGI5OhszCqtuauydej8WfkGolJo45oqCb.9tj690Wue",
//         "name": "Nguyễn Tấn Thông",
//         "phone": "0364117408",
//         "mail": "tructruong.070202@gmail.com",
//         "address": "Bình Định",
//         "gender": "Nam",
//         "dateborn": "2000-05-08T00:00:00",
//         "status": 1,
//         "hoadons": []
//     },
//     message : ''
// }

import { ACT_KHACHHANG_LOGIN, ACT_KHACHHANG_REGISTER, RESET_MESSAGE_USER_KHACHHANG } from "../actions/UserKhachHangAction";

var data = JSON.parse(localStorage.getItem("khachhang"));

const initialState = {
    dataValue: data ? data : {},
    message: '',
    cart : {}
}

const UserKhachHangReducer = (state = initialState, action) => {
    switch (action.type) {
        case ACT_KHACHHANG_REGISTER:
            return {
                ...state,
                message: action.payload
            }
        case RESET_MESSAGE_USER_KHACHHANG:
            return {
                ...state,
                message: action.payload
            }
        case ACT_KHACHHANG_LOGIN:
            return {
                ...state,
                dataValue : action.payload.khachhang,
                message : action.payload.message
            }
        default:
            return {
                ...state
            }
    }
}

export default UserKhachHangReducer
