
import axios from 'axios'
import { API_URL } from '../../constants/Config';
import { ACT_LOGIN_ERROR, ACT_LOGIN_SUCCESS } from '../../constants/Message';


export const LOGIN_ADMIN = "LOGIN_ADMIN";
export const GET_USER = "GET_USER";
export const RESET_MESSAGE_USER_NHANVIEN = 'RESET_MESSAGE_USER_NHANVIEN'

export const actResetMessageUserNhanVien = () => (dispatch) => {
    dispatch({
        type: RESET_MESSAGE_USER_NHANVIEN,
        payload: ''
    })
}

export const actLoginAdmin = (data) => (dispatch) => {
    axios.post(`${API_URL}nhanvien/login`,
    data,
    {
        headers : {
            'Content-Type' : 'application/json'
        },
        withCredentials: true,
        credentials: 'include',
    }).then((res) => {
        console.log(res);
        dispatch({
            type : LOGIN_ADMIN,
            payload : {
                nhanvien : res.data,
                message : ACT_LOGIN_SUCCESS
            }
        });
    }).catch((error) => {
        if (error.response.data.message) {
            console.log('actLoginAdmin error: ', error.response.data.message);

            dispatch({
                type: LOGIN_ADMIN,
                payload: {
                    nhanvien: {},
                    message: error.response.data.message
                }
            });
        }
        else {
            console.log('actLoginAdmin error: ', error);

            dispatch({
                type: LOGIN_ADMIN,
                payload: {
                    nhanvien: {},
                    message: ACT_LOGIN_ERROR
                }
            });
        }
        dispatch({
            type : LOGIN_ADMIN,
            payload : ACT_LOGIN_ERROR
        });
        console.log("actLoginAdmin error: ", error);
    })
}

export const actGetUser = () => (dispatch) => {
    axios.get(`${API_URL}nhanvien/user`,
    {
        headers : {
            'Content-Type' : 'application/json'
        },
        withCredentials: true,
        credentials: 'include',
    }).then((res) => {
        dispatch({
            type : GET_USER,
            payload : res.data
        });
    }).catch((error) => {
        console.log(error);
    })
}