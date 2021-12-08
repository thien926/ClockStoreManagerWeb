import React from 'react'

function AdminImportGoodItem() {
    return (
        <tr>
            <td>12</td>
            <td>Đồng hồ để bàn chính hãng NAMKIN B945-1</td>
            <td className="col-md-1">
                <img className="img-responsive" src="/image/sp1.jpg" />
            </td>
            <td>
                <input type="number" className="form-control" defaultValue={0} required="required" />
            </td>
            <td>
                <input type="number" className="form-control" defaultValue={0} required="required" />
            </td>
            <td>12</td>
            <td>
                <button type="button" className="btn btn-danger">Xóa</button>
            </td>
        </tr>
    )
}

export default AdminImportGoodItem
