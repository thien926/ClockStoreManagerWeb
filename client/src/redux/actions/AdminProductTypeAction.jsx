import axios from "axios"
import { API_URL } from '../../constants/Config';
import { ADD_LSP_SUCCESS, 
        ADD_LSP_ERROR,
        UPDATE_LSP_SUCCESS,
        UPDATE_LSP_ERROR,
        DELETE_LSP_SUCCESS,
        DELETE_LSP_ERROR
} from '../../constants/Message';

export const GET_PRODUCT_TYPE_ADMIN = 'GET_PRODUCT_TYPE_ADMIN'
export const UPDATE_PRODUCT_TYPE_ADMIN = 'UPDATE_PRODUCT_TYPE_ADMIN';
export const ADD_PRODUCT_TYPE_ADMIN = 'ADD_PRODUCT_TYPE_ADMIN';
export const DELETE_PRODUCT_TYPE_ADMIN = 'DELETE_PRODUCT_TYPE_ADMIN';
export const RESET_MESSAGE_LSP = 'RESET_MESSAGE_LSP';

export const actResetMessageLSP = () => (dispatch) => {
    dispatch({
        type : RESET_MESSAGE_LSP,
        payload : ''
    })
}

export const actGetProductTypeAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}loaisanpham/filter-admin`,
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
            type : GET_PRODUCT_TYPE_ADMIN,
            payload : res.data
        });
    }).catch((error) => {
        console.log("actGetProductTypeAdmin error: ", error);
    })
}

export const actAddProductTypeAdmin = (data) => (dispatch) => {
    // console.log(data);
    axios.post(
        `${API_URL}loaisanpham`,
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
            type : ADD_PRODUCT_TYPE_ADMIN,
            payload : ADD_LSP_SUCCESS
        })
        // return res.data;
    }).catch(error => {
        console.log('actAddProductTypeAdmin - error: ', error);
        dispatch({
            type : ADD_PRODUCT_TYPE_ADMIN,
            payload : ADD_LSP_ERROR
        })
    });
}

export const actUpdateProductTypeAdmin = (data, id) => (dispatch) => {
    axios.put(
        `${API_URL}loaisanpham/${id}`,
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
            type : UPDATE_PRODUCT_TYPE_ADMIN,
            payload : UPDATE_LSP_SUCCESS
        })
    }).catch(error => {
        console.log("actUpdateProductTypeAdmin error: ", error);
        dispatch({
            type : UPDATE_PRODUCT_TYPE_ADMIN,
            payload : UPDATE_LSP_ERROR
        })
    });
}

export const actDeleteProductType = (id) => (dispatch) => {
    axios.delete(
        `${API_URL}loaisanpham/${id}`,
        {
            headers : {
                'Content-Type' : 'application/json'
            },
            withCredentials: true,
            credentials: 'include',
        }
    ).then((result) => {
        dispatch({
            type : DELETE_PRODUCT_TYPE_ADMIN,
            payload : DELETE_LSP_SUCCESS
        });
    }).catch(error => {
        console.log("actDeleteProductType error: ", error);
        dispatch({
            type: DELETE_PRODUCT_TYPE_ADMIN,
            payload: DELETE_LSP_ERROR
        })
    })
}