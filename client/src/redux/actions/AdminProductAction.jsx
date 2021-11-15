
import axios from 'axios'
import { API_URL } from '../../constants/Config';


export const GET_PRODUCT_ADMIN = "GET_PRODUCT_ADMIN";

export const actGetProductAdmin = (data) => (dispatch) => {
    axios.get(`${API_URL}sanpham/filter-admin`,
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
            type : GET_PRODUCT_ADMIN,
            payload : res.data
        });
    }).catch((err) => {
        console.log(err);
    })
}
