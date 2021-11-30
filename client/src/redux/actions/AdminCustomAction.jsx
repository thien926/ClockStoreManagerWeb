import axios from "axios";
import { API_URL } from "../../constants/Config";
import { ACT_CHANGE_STATUS_KHACHHANG_ADMIN_ERROR, ACT_OFF_STATUS_KHACHHANG_ADMIN_SUCCESS, ACT_ON_STATUS_KHACHHANG_ADMIN_SUCCESS } from "../../constants/Message";


export const RESET_MESSAGE_CUSTOM_ADMIN = "RESET_MESSAGE_CUSTOM_ADMIN";
export const GET_CUSTOM_ADMIN = "GET_CUSTOM_ADMIN";
export const CHANGE_STATUS_CUSTOM_ADMIN = 'CHANGE_STATUS_CUSTOM_ADMIN';

export const actResetMessageCustomAdmin = () => (dispatch) => {
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

export const actChangeStatusCustomAdmin = (user) => (dispatch) => {
    axios.put(
        `${API_URL}khachhang/changeStatus/${user}`,
        {
            header : {
                'Content-Type' : 'application/json'
            },
            withCredentials : true,
            credentials : 'include'
        }
    ).then((res) => {
        if(res.data.status === 1) {
            dispatch({
                type : CHANGE_STATUS_CUSTOM_ADMIN,
                payload : ACT_ON_STATUS_KHACHHANG_ADMIN_SUCCESS
            })
        }
        else {
            dispatch({
                type : CHANGE_STATUS_CUSTOM_ADMIN,
                payload : ACT_OFF_STATUS_KHACHHANG_ADMIN_SUCCESS
            })
        }
        
    }).catch(error => {
        console.log('actChangeStatusCustomAdmin error: ', error);
        dispatch({
            type : CHANGE_STATUS_CUSTOM_ADMIN,
            payload : ACT_CHANGE_STATUS_KHACHHANG_ADMIN_ERROR
        })
    })
}