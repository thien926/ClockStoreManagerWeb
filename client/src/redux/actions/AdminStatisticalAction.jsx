import axios from "axios";
import { API_URL } from "../../constants/Config";

export const DOANH_THU_IN_YEAR_THONG_KE = 'DOANH_THU_IN_YEAR_THONG_KE';
export const DOANH_THU_IN_MONTH_THONG_KE = 'DOANH_THU_IN_MONTH_THONG_KE';

function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
  

export const actDoanhThuYearAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}thongke/doanhthu-year`,
        data,
        {
            header : {
                'Content-Type' : 'application/json'
            },
            withCredentials : true,
            credentials : 'include'
        }
    ).then((res) => {
        var labels = new Array();
        data = new Array();
        var backgroundColor = new Array();
        res.data.forEach(element => {
            labels.push("Năm " + element.key);
            data.push(element.value);
            backgroundColor.push(getRandomColor());
        });
        
        dispatch({
            type : DOANH_THU_IN_YEAR_THONG_KE,
            payload : {
                labels: labels,
                datasets: [
                    {
                        label: "Doanh thu",
                        data : data,
                        backgroundColor: backgroundColor
                    }
                ]
            }
        })
    }).catch(error => {
        console.log('actDoanhThuYearAdmin error: ', error);
    })
}

export const actDoanhThuMonthAdmin = (data) => (dispatch) => {
    axios.post(
        `${API_URL}thongke/doanhthu-month`,
        data,
        {
            header : {
                'Content-Type' : 'application/json'
            },
            withCredentials : true,
            credentials : 'include'
        }
    ).then((res) => {
        var labels = new Array();
        data = new Array();
        var backgroundColor = new Array();
        res.data.forEach(element => {
            // console.log(element)
            labels.push("Tháng " + element.key);
            data.push(element.value);
            backgroundColor.push(getRandomColor());
        });
        
        dispatch({
            type : DOANH_THU_IN_MONTH_THONG_KE,
            payload : {
                labels: labels,
                datasets: [
                    {
                        label: "Doanh thu",
                        data : data,
                        backgroundColor: backgroundColor
                    }
                ]
            }
        })
    }).catch(error => {
        console.log('actDoanhThuMonthAdmin error: ', error);
    })
}