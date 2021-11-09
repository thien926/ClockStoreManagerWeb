
import axios from 'axios'
import { API_URL } from '../../constants/Config';
import Cookies from 'js-cookie';


export const LOGIN_ADMIN = "LOGIN_ADMIN";
export const GET_USER = "GET_USER";

export const actLoginAdmin = (data) => (dispatch) => {
    axios.post(`${API_URL}nhanvien/login`,
    data,
    {
        headers : {
            // accept: 'application/json'
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
        // console.log("Cookie", Cookies.get('jwt-nhanvien'));
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
        // console.log("cookie",res);
        dispatch({
            type : GET_USER,
            payload : res.data
        });
    }).catch((err) => {
        console.log(err);
    })
}