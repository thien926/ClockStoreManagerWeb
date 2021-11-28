import React from 'react'

function AdminNCCItem(props) {

    const { ncc, index } = props;

    const actionBtnSua = () => {
        var data = {
            id : ncc.id,
            name : ncc.name,
            address : ncc.address,
            phone : ncc.phone,
            fax : ncc.fax
        }
        props.actionUpdate(data);
    }
    
    return (
        <tr>
            <td>{index+1}</td>
            <td>{ncc.id}</td>
            <td>{ncc.name}</td>
            <td>{ncc.address}</td>
            <td>{ncc.phone}</td>
            <td>{ncc.fax}</td>
            <td>
                <button onClick={actionBtnSua} type="button" className="btn btn-info">Sửa</button>
                <button onClick={() => props.actionDelete(ncc.id)} type="button" className="btn btn-warning ml-1">Xóa</button>
            </td>
        </tr>
    )
}

export default AdminNCCItem
