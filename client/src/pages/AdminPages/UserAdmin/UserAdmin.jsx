import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { actGetUser } from '../../../redux/actions/LoginAdminAction';

function UserAdmin() {

    const UserAdmin = useSelector(state => state.LoginAdminReducer)
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(actGetUser());
    }, [dispatch])

    useEffect(() => {
        console.log("Current User Admin : ", UserAdmin);
    }, [UserAdmin])

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý tài khoản</h3>
                <hr />
            </div>
            <div className="row">
                <button type="button" className="btn btn-primary ml-2">Sửa tài khoản <i className="fa fa-plus-circle" aria-hidden="true" /></button>

                <button type="button" className="btn btn-danger ml-2">Thay đổi mật khẩu <i className="fa fa-edit" aria-hidden="true" /></button>

            </div>

            <div className="row mt-3">
                <table className="table table-hover ">
                    <tbody>
                        <tr>
                            <td className="font-weight-bold">Tên tài khoản: </td>
                            <td>{UserAdmin.dataValue.user}</td>
                        </tr>
                        <tr>
                            <td className="font-weight-bold">Họ tên: </td>
                            <td>{UserAdmin.dataValue.name}</td>
                        </tr>
                        <tr>
                            <td className="font-weight-bold">Số điện thoại: </td>
                            <td>{UserAdmin.dataValue.phone}</td>
                        </tr>
                        <tr>
                            <td className="font-weight-bold">Địa chỉ: </td>
                            <td>{UserAdmin.dataValue.address}</td>
                        </tr>
                        <tr>
                            <td className="font-weight-bold">Giới tính: </td>
                            <td>{UserAdmin.dataValue.gender}</td>
                        </tr>
                        <tr>
                            <td className="font-weight-bold">Ngày sinh: </td>
                            <td>{UserAdmin.dataValue.dateborn.split("T")[0]}</td>
                        </tr>
                        <tr>
                            <td className="font-weight-bold">Quyền: </td>
                            <td>{UserAdmin.dataValue.quyen.id} - {UserAdmin.dataValue.quyen.name}</td>
                        </tr>
                    </tbody>
                </table>
            </div>


            <div className="row mt-3 ml-3 mr-3">
                <div>
                    <h3 className="text-center mt-2">Thêm quyền</h3>
                    <hr />
                </div>
                <table className="table table-hover ">
                    <tbody>
                        <tr>
                            <td>Tên</td>
                            <td>
                                <input type="email" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Tên</td>
                            <td>
                                <input type="email" className="form-control" required="required" />

                            </td>
                        </tr>
                    </tbody>
                </table>
                <div className="mb-3">
                <button type="button" className="btn btn-primary mr-2">Thêm</button>
                <button type="button" className="btn btn-danger mr-2">Hủy</button>
            </div>
            </div>
        </div>

    )
}

export default UserAdmin
