import React from 'react'

function AdminCustomItem(props) {
    const { custom, index } = props;

    const showStatus = () => {
        if(custom.status === 1) {
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

    return (
        <tr>
            <td>{index + 1}</td>
            <td>{custom.user}</td>
            <td>{custom.name}</td>
            <td>{custom.phone}</td>
            <td>{custom.mail}</td>
            <td>{custom.address}</td>
            <td>{custom.gender}</td>
            <td>{custom.dateborn.split("T")[0]}</td>
            <td>{showStatus()}</td>
            <td>
                <button type="button" className="btn btn-info">Sửa</button>
                <button type="button" className="btn btn-warning ml-1">Xóa</button>
            </td>

        </tr>
    )
}

export default AdminCustomItem
