import axios from "axios";
import { API_URL } from "../../constants/Config";
import { ADD_NCC_ERROR, ADD_NCC_SUCCESS, DELETE_NCC_ERROR, DELETE_NCC_SUCCESS, UPDATE_NCC_ERROR, UPDATE_NCC_SUCCESS } from "../../constants/Message";


export const GET_NCC_ADMIN = 'GET_NCC_ADMIN';
export const RESET_MESSAGE_NCC_ADMIN = 'RESET_MESSAGE_NCC_ADMIN';
export const ADD_NCC_ADMIN = 'ADD_NCC_ADMIN';
export const UPDATE_NCC_ADMIN = 'UPDATE_NCC_ADMIN';
export const DELETE_NCC_ADMIN = 'DELETE_NCC_ADMIN';

export const actResetMessageNCCAdmin = () => (dispatch) => {
    dispatch({
        type : RESET_MESSAGE_NCC_ADMIN,
        payload: ''
    })
}

export const actGetNCCAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}ncc/filter-admin`,
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
            type : GET_NCC_ADMIN,
            payload : res.data
        })
    }).catch(error => {
        console.log('actGetNCCAdmin error: ', error);
    })
}

export const actAddNCCAdmin = (data) => (dispatch) => {
    // console.log(data);
    axios.post(
        `${API_URL}ncc`,
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
            type : ADD_NCC_ADMIN,
            payload : ADD_NCC_SUCCESS
        })
        // return res.data;
    }).catch(error => {
        console.log('actAddNCCAdmin - error: ', error);
        dispatch({
            type : ADD_NCC_ADMIN,
            payload : ADD_NCC_ERROR
        })
    });
}

export const actUpdateNCCAdmin = (data, id) => (dispatch) => {
    axios.put(
        `${API_URL}ncc/${id}`,
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
            type : UPDATE_NCC_ADMIN,
            payload : UPDATE_NCC_SUCCESS
        })
    }).catch(error => {
        console.log("actUpdateNCCAdmin error: ", error);
        dispatch({
            type : UPDATE_NCC_ADMIN,
            payload : UPDATE_NCC_ERROR
        })
    });
}

export const actDeleteNCCAdmin = (id) => (dispatch) => {
    axios.delete(
        `${API_URL}ncc/${id}`,
        {
            headers : {
                'Content-Type' : 'application/json'
            },
            withCredentials: true,
            credentials: 'include',
        }
    ).then((result) => {
        dispatch({
            type : DELETE_NCC_ADMIN,
            payload : DELETE_NCC_SUCCESS
        });
    }).catch(error => {
        console.log("actDeleteNCCAdmin error: ", error);
        dispatch({
            type: DELETE_NCC_ADMIN,
            payload: DELETE_NCC_ERROR
        })
    })
}