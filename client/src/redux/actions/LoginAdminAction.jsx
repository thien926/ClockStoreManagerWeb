
import axios from 'axios'
import { API_URL } from '../../constants/Config';


export const LOGIN_ADMIN = "LOGIN_ADMIN";
export const GET_USER = "GET_USER";

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
            payload : res.data
        });
    }).catch((err) => {
        console.log(err);
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
    }).catch((err) => {
        console.log(err);
    })
}