import React from 'react'

function AdminStaffFormAction() {
    return (
        <div className="row mt-3 ml-3 mr-3">
            <div>
                <h3 className="text-center mt-2">Thêm nhân viên</h3>
                <hr />
            </div>
            <table className="table table-hover ">
                <tbody>
                    <tr>
                        <td>Tài khoản</td>
                        <td>
                            <input type="text" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Mật khẩu</td>
                        <td>
                            <input type="password" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Họ tên</td>
                        <td>
                            <input type="text" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Số điện thoại</td>
                        <td>
                            <input type="text" className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Địa chỉ</td>
                        <td>
                            <input type="text" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Giới tính</td>
                        <td>
                            <label className="ml-1">
                                <input type="radio" name="gender" value="Nam" />&nbsp;
                                Nam
                            </label>
                            <label className="ml-3">
                                <input type="radio" name="gender" value="Nữ" />&nbsp;
                                Nữ
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>Ngày sinh</td>
                        <td>
                            <input type="date" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Quyền</td>
                        <td>
                            <input type="text" className="form-control" required="required" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <div className="mb-3">
                <button type="button" className="btn btn-primary mr-2">Thêm</button>
                <button type="button" className="btn btn-danger mr-2">Hủy</button>
            </div>
        </div>
    )
}

export default AdminStaffFormAction
