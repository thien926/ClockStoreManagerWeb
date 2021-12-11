import axios from "axios";
import { API_URL } from "../../constants/Config";

export const GET_IMPORT_GOOD_ADMIN = 'GET_IMPORT_GOOD_ADMIN';
export const CHOOSE_ITEM_IMPORT_GOOD_ADMIN = 'CHOOSE_ITEM_IMPORT_GOOD_ADMIN';
export const GET_DATA_ACTION_IMPORT_GOOD_ADMIN = 'GET_DATA_ACTION_IMPORT_GOOD_ADMIN';
export const REMOVE_DATA_ACTION_IMPORT_GOOD_ADMIN = 'REMOVE_DATA_ACTION_IMPORT_GOOD_ADMIN'
export const REFRESH_MESSAGE_IMPORT_GOOD_ADMIN = 'REFRESH_MESSAGE_IMPORT_GOOD_ADMIN'
export const CHANGE_DATA_ACTION_IMPORT_GOOD_ADMIN = 'CHANGE_DATA_ACTION_IMPORT_GOOD_ADMIN'
export const CANCEL_IMPORT_GOOD_ADMIN = 'CANCEL_IMPORT_GOOD_ADMIN'


export const actRefreshMessageImportGoodAdmin = () => (dispatch) => {
    dispatch({
        type : REFRESH_MESSAGE_IMPORT_GOOD_ADMIN,
        payload : {
            type : "",
            value : ""
        }
    })
}

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

export const actGetDataActionImportGoodAdmin = () => (dispatch) => {
    var dataAction = JSON.parse(sessionStorage.getItem("dataAction"));
    if (!dataAction) {
        dataAction = {
            listSP: [],
            amount: 0,
            total: 0
        }
    }

    dispatch({
        type : GET_DATA_ACTION_IMPORT_GOOD_ADMIN,
        payload : dataAction
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
}

export const actRemoveDataAction = (id) => (dispatch) => {
    var dataAction = JSON.parse(sessionStorage.getItem("dataAction"));
    let temp = false;
    if (!dataAction) {
        dataAction = {
            listSP: [],
            amount: 0,
            total: 0
        }
    }

    dataAction.listSP.forEach((item, index) => {
        if(item.id === id) {
            temp = true;
            dataAction.listSP.splice(index, 1);
            dispatch({
                type : REMOVE_DATA_ACTION_IMPORT_GOOD_ADMIN,
                payload : {
                    dataAction : dataAction,
                    message : {
                        type : "success",
                        value : "Xóa thành công!"
                    }
                }
            })
            sessionStorage.setItem("dataAction", JSON.stringify(dataAction));
            return;
        }
    })

    if(!temp) {
        dispatch({
            type : REMOVE_DATA_ACTION_IMPORT_GOOD_ADMIN,
            payload : {
                message : {
                    type : "error",
                    value : "Xóa thất bại!"
                }
            }
        })
    }
}

export const actChangeAmountPriceImportGoodAdmin = (id, amount, price) => (dispatch) => {
    var dataAction = JSON.parse(sessionStorage.getItem("dataAction"));
    if (!dataAction) {
        dataAction = {
            listSP: [],
            amount: 0,
            total: 0
        }
    }

    dataAction.listSP.forEach((item, index) => {
        if(item.id === id) {
            item.price = price;
            item.amount = amount;
            dispatch({
                type : CHANGE_DATA_ACTION_IMPORT_GOOD_ADMIN,
                payload : dataAction
            })
            sessionStorage.setItem("dataAction", JSON.stringify(dataAction));
            return;
        }
    })
}

export const actCancelImportGoodAdmin = () => (dispatch) => {
    sessionStorage.removeItem("dataAction")
    dispatch({
        type : CANCEL_IMPORT_GOOD_ADMIN,
        payload : {
            listSP: [],
            amount: 0,
            total: 0
        }
    })
}