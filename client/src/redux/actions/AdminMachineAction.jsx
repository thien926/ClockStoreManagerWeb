import axios from "axios";
import { API_URL } from "../../constants/Config";
import { ADD_MACHINE_ERROR, ADD_MACHINE_SUCCESS, DELETE_MACHINE_ERROR, DELETE_MACHINE_SUCCESS, UPDATE_MACHINE_ERROR, UPDATE_MACHINE_SUCCESS } from "../../constants/Message";

export const GET_MACHINE_ADMIN = 'GET_MACHINE_ADMIN';
export const RESET_MESSAGE_MACHINE_ADMIN = 'RESET_MESSAGE_MACHINE_ADMIN';
export const ADD_MACHINE_ADMIN = 'ADD_MACHINE_ADMIN';
export const UPDATE_MACHINE_ADMIN = 'UPDATE_MACHINE_ADMIN';
export const DELETE_MACHINE_ADMIN = 'DELETE_MACHINE_ADMIN';

export const actResetMessageMachineAdmin = () => (dispatch) => {
    dispatch({
        type : RESET_MESSAGE_MACHINE_ADMIN,
        payload: ''
    })
}

export const actGetMachineAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}kieumay/filter-admin`,
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
            type : GET_MACHINE_ADMIN,
            payload : res.data
        })
    }).catch(error => {
        console.log('actGetMachineAdmin error: ', error);
    })
}

export const actAddMachineAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}kieumay`,
        data,
        {
            headers : {
                'Content-Type' : 'application/json'
            },
            withCredentials : true,
            credentials : 'include'
        }
    ).then((res) => {
        dispatch({
            type : ADD_MACHINE_ADMIN,
            payload : ADD_MACHINE_SUCCESS
        })
        // return res.data;
    }).catch(error => {
        console.log('actAddMachineAdmin - error: ', error);
        dispatch({
            type : ADD_MACHINE_ADMIN,
            payload : ADD_MACHINE_ERROR
        })
    });
}

export const actUpdateMachineAdmin = (data, id) => (dispatch) => {
    axios.put(
        `${API_URL}kieumay/${id}`,
        data,
        {
            headers : {
                'Content-Type' : 'application/json'
            },
            withCredentials: true,
            credentials: 'include',
        }
    ).then((res) => {
        dispatch({
            type : UPDATE_MACHINE_ADMIN,
            payload : UPDATE_MACHINE_SUCCESS
        })
    }).catch(error => {
        console.log("actUpdateMachineAdmin error: ", error);
        dispatch({
            type : UPDATE_MACHINE_ADMIN,
            payload : UPDATE_MACHINE_ERROR
        })
    });
}

export const actDeleteMachine = (id) => (dispatch) => {
    axios.delete(
        `${API_URL}kieumay/${id}`,
        {
            headers : {
                'Content-Type' : 'application/json'
            },
            withCredentials: true,
            credentials: 'include',
        }
    ).then((result) => {
        dispatch({
            type : DELETE_MACHINE_ADMIN,
            payload : DELETE_MACHINE_SUCCESS
        });
    }).catch(error => {
        console.log("actDeleteMachine error: ", error);
        dispatch({
            type: DELETE_MACHINE_ADMIN,
            payload: DELETE_MACHINE_ERROR
        })
    })
}