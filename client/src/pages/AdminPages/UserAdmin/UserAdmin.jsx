import React from 'react'

function UserAdmin() {
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
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>Name</th>
                            <th>Price</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Iphone 6</td>
                            <td>6000.0000đ</td>
                            <td>
                                <button type="button" className="btn btn-info">Sửa</button>
                                <button type="button" className="btn btn-warning ml-1">Xóa</button>
                            </td>

                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Iphone 6</td>
                            <td>6000.0000đ</td>
                            <td>
                                <button type="button" className="btn btn-info">Sửa</button>
                                <button type="button" className="btn btn-warning ml-1">Xóa</button>
                            </td>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Iphone 6</td>
                            <td>6000.0000đ</td>
                            <td>
                                <button type="button" className="btn btn-info">Sửa</button>
                                <button type="button" className="btn btn-warning ml-1">Xóa</button>
                            </td>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Iphone 6</td>
                            <td>6000.0000đ</td>
                            <td>
                                <button type="button" className="btn btn-info">Sửa</button>
                                <button type="button" className="btn btn-warning ml-1">Xóa</button>
                            </td>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>Iphone 6</td>
                            <td>6000.0000đ</td>
                            <td>
                                <button type="button" className="btn btn-info">Sửa</button>
                                <button type="button" className="btn btn-warning ml-1">Xóa</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>


            <div className="row mt-3">
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
                        <tr>
                            <td colSpan="2"><button type="submit" className="btn btn-primary mt-4 btn-submit-product-admin">Thêm</button></td>
                        </tr>

                    </tbody>
                </table>
            </div>
        </div>

    )
}

export default UserAdmin
