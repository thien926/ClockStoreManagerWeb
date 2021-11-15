import React from 'react'

function AdminProductItem(props) {

    const { index, product } = props;

    return (
        <tr>
            <td>{index + 1}</td>
            <td>{product.Id}</td>
            <td>{product.LSPId}</td>
            <td>{product.brandId}</td>
            <td>{product.wireId}</td>
            <td>{product.machineId}</td>
            <td>{product.nccId}</td>
            <td>{product.name}</td>
            <td>{product.amount}</td>
            <td>{product.price}</td>
            <td>{product.description}</td>
            <td>{product.img}</td>
            <td>
                <button type="button" className="btn btn-info">Sửa</button>
                <button type="button" className="btn btn-warning ml-1">Xóa</button>
            </td>
        </tr>
    )
}

export default AdminProductItem
