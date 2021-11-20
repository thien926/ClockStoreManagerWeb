import React from 'react'

function AdminProductTypeItem(props) {

    const { index, productType } = props;

    return (
        <tr>
            <td>{index + 1}</td>
            <td>{ productType.id }</td>
            <td>{ productType.name }</td>
            <td>{ productType.description }</td>
            <td>
                <button type="button" className="btn btn-info">Sửa</button>
                <button type="button" className="btn btn-warning ml-1">Xóa</button>
            </td>

        </tr>
    )
}

export default AdminProductTypeItem
