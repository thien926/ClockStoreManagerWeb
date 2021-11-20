import axios from "axios"
import { API_URL } from '../../constants/Config';

export const GET_PRODUCT_TYPE_ADMIN = 'GET_PRODUCT_TYPE_ADMIN'


export const actGetProductTypeAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}filter-admin`,
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