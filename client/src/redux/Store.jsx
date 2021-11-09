
import axios from 'axios';

const API_URL = 'http://localhost:3000';

export default function callApi(endpoint, method = 'GET', data) {
    return axios({
        method: method,
        url: `${API_URL}/${endpoint}`,
        data: data
    }).catch((err) => {
        console.log(err);
    });
};