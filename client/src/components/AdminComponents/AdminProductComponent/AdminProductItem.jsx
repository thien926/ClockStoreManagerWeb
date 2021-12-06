import React from 'react'

import { API_URL_IMG } from '../../../constants/Config';

function AdminProductItem(props) {

    const { index, product } = props;

    const showStatus = () => {
        if(product.status == 1) {
            return (
                <span className="label label-success">
                    Kích hoạt
                </span>
            )
        }
        return (
            <span className="label label-danger">
                Ẩn
            </span>
        )
    }

    const handleDeleteClick = () => {
        // alert()
    }

    return (
        <tr>
            <td>{index + 1}</td>
            <td>{product.id}</td>
            <td>{product.lspId}</td>
            <td>{product.brandId}</td>
            <td>{product.wireId}</td>
            <td>{product.machineId}</td>
            {/* <td>{product.nccId}</td> */}
            <td>{product.name}</td>
            <td>{product.amount}</td>
            <td>{product.price}</td>
            <td>{product.description}</td>
            <td>
                <img src={`${API_URL_IMG + product.img}`} />
            </td>
            <td>
                {showStatus()}
            </td>
            <td>
                <button type="button" className="btn btn-info">Sửa</button>
                <button type="button" className="btn btn-warning ml-1">Xóa</button>
            </td>
        </tr>
    )
}

export default AdminProductItem
