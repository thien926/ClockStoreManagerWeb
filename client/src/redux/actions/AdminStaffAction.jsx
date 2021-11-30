import axios from "axios";
import { API_URL } from "../../constants/Config";
import { ACT_CHANGE_STATUS_STAFF_ADMIN_ERROR, ACT_OFF_STATUS_STAFF_ADMIN_SUCCESS, ACT_ON_STATUS_STAFF_ADMIN_SUCCESS } from "../../constants/Message";



export const RESET_MESSAGE_STAFF_ADMIN = "RESET_MESSAGE_STAFF_ADMIN";
export const GET_STAFF_ADMIN = "GET_STAFF_ADMIN";
export const CHANGE_STATUS_STAFF_ADMIN = 'CHANGE_STATUS_STAFF_ADMIN';

export const actResetMessageStaffAdmin = () => (dispatch) => {
    dispatch({
        type : RESET_MESSAGE_STAFF_ADMIN,
        payload: ''
    })
}

export const actGetStaffAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}nhanvien/filter-admin`,
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
            type : GET_STAFF_ADMIN,
            payload : res.data
        })
    }).catch(error => {
        console.log('actGetStaffAdmin error: ', error);
    })
}

export const actChangeStatusStaffAdmin = (user) => (dispatch) => {
    axios.put(
        `${API_URL}nhanvien/changeStatus/${user}`,
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
                type : CHANGE_STATUS_STAFF_ADMIN,
                payload : ACT_ON_STATUS_STAFF_ADMIN_SUCCESS
            })
        }
        else {
            dispatch({
                type : CHANGE_STATUS_STAFF_ADMIN,
                payload : ACT_OFF_STATUS_STAFF_ADMIN_SUCCESS
            })
        }
        
    }).catch(error => {
        console.log('actChangeStatusStaffAdmin error: ', error);
        dispatch({
            type : CHANGE_STATUS_STAFF_ADMIN,
            payload : ACT_CHANGE_STATUS_STAFF_ADMIN_ERROR
        })
    })
}