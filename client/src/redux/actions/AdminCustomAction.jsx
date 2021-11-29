import axios from "axios";
import { API_URL } from "../../constants/Config";


export const RESET_MESSAGE_CUSTOM_ADMIN = "RESET_MESSAGE_CUSTOM_ADMIN";
export const GET_CUSTOM_ADMIN = "GET_CUSTOM_ADMIN";

export const actResetMessageNCCAdmin = () => (dispatch) => {
    dispatch({
        type : RESET_MESSAGE_CUSTOM_ADMIN,
        payload: ''
    })
}

export const actGetCustomAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}khachhang/filter-admin`,
        data,
        {
            header : {
                'Content-Type' : 'application/json'
            },
            withCredentials : true,
            credentials : 'include'
        }
    ).then((res) => {
        dispatch({
            type : GET_CUSTOM_ADMIN,
            payload : res.data
        })
    }).catch(error => {
        console.log('actGetCustomAdmin error: ', error);
    })
}