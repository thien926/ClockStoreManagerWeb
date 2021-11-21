import axios from "axios"
import { API_URL } from '../../constants/Config';

export const GET_PRODUCT_TYPE_ADMIN = 'GET_PRODUCT_TYPE_ADMIN'
export const UPDATE_PRODUCT_TYPE_ADMIN = 'UPDATE_PRODUCT_TYPE_ADMIN';
export const ADD_PRODUCT_TYPE_ADMIN = 'ADD_PRODUCT_TYPE_ADMIN';

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
        // console.log("actGetProductTypeAdmin success");
        dispatch({
            type : GET_PRODUCT_TYPE_ADMIN,
            payload : res.data
        });
    }).catch((error) => {
        console.log("actGetProductTypeAdmin error: ", error);
    })
}

export const actAddProductTypeAdmin = (data, filter) => (dispatch) => {
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
        
        dispatch(actGetProductTypeAdmin(filter));
        // return res.data;
    }).catch(error => {
        console.log('actAddProductTypeAdmin: ', error);
        // return error;
    });
}