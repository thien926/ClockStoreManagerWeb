import React from 'react'

function AdminStaffItem(props) {
    const { staff, index } = props;

    const showStatus = () => {
        if(staff.status === 1) {
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

    const showBtnStatus = () => {
        if(staff.status === 1) {
            return (
                <button onClick={() => props.submitChangeStatus(staff.user)} type="button" className="btn btn-warning">Ẩn</button>
            )
        }
        return (
            <button onClick={() => props.submitChangeStatus(staff.user)} type="button" className="btn btn-info">Kích hoạt</button>
        )
    }

    return (
        <tr>
            <td>{index + 1}</td>
            <td>{staff.user}</td>
            <td>{staff.name}</td>
            <td>{staff.phone}</td>
            {/* <td>{staff.mail}</td> */}
            <td>{staff.address}</td>
            <td>{staff.gender}</td>
            <td>{staff.dateborn.split("T")[0]}</td>
            <td>{showStatus()}</td>
            <td>
                {/* <button type="button" className="btn btn-info">Sửa</button> */}
                {showBtnStatus()}
                {/* <button type="button" className="btn btn-warning ml-1">Sửa pass</button> */}
            </td>

        </tr>
    )
}

export default AdminStaffItem
