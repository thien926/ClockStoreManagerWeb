import axios from "axios";
import { API_URL } from "../../constants/Config";

export const GET_PRODUCT_SHOP_PAGE = 'GET_PRODUCT_SHOP_PAGE';

export const actGetProductShopPage = (data) => (dispatch) => {
    axios.post(
        `${API_URL}sanpham/filter-shop`,
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
            type : GET_PRODUCT_SHOP_PAGE,
            payload : res.data
        })
    }).catch(error => {
        console.log('actGetProductShopPage error: ', error);
    })
}
