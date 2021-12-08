import axios from "axios";
import { API_URL } from "../../constants/Config";

export const GET_IMPORT_GOOD_ADMIN = 'GET_IMPORT_GOOD_ADMIN';
export const CHOOSE_ITEM_IMPORT_GOOD_ADMIN = 'CHOOSE_ITEM_IMPORT_GOOD_ADMIN';

export const actGetImportGoodsLoadAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}nhaphang/filter-admin`,
        data,
        {
            header: {
                'Content-Type': 'application/json'
            },
            withCredentials: true,
            credentials: 'include'
        }
    ).then((res) => {
        dispatch({
            type: GET_IMPORT_GOOD_ADMIN,
            payload: res.data
        })
    }).catch(error => {
        console.log('actGetImportGoodsLoadAdmin error: ', error);
    })
}

export const actChooseProduct = (data) => (dispatch) => {
    var dataAction = JSON.parse(sessionStorage.getItem("dataAction"));
    if (!dataAction) {
        dataAction = {
            listSP: [],
            amount: 0,
            total: 0
        }
    }
    data.price = 0;
    data.amount = 0;

    let amount = 0, total = 0;
    let temp = false;

    dataAction.listSP.forEach(element => {
        amount += parseInt(element.amount);
        total += parseInt(element.amount) * parseInt(element.price);
        if(element.id === data.id) {
            temp = true;
        }
    });

    dataAction.amount = amount;
    dataAction.total = total;

    if(!temp) {
        dataAction.listSP.push(data);

        sessionStorage.setItem("dataAction", JSON.stringify(dataAction));
        dispatch({
            type : CHOOSE_ITEM_IMPORT_GOOD_ADMIN,
            payload : {
                dataAction : dataAction,
                message : {
                    type : "",
                    value : ""
                }
            }
        })
    }
    else {
        dispatch({
            type : CHOOSE_ITEM_IMPORT_GOOD_ADMIN,
            payload : {
                dataAction : dataAction,
                message : {
                    type : "error",
                    value : "Sản phẩm đã được chọn từ trước!"
                }
            }
        })
    }
    
}