import React from 'react'

function CustomAdmin() {
    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý khách hàng</h3>
                <hr />
            </div>
            <div className="row">
                <div className="col-xs-7 col-sm-7 col-md-7 col-lg-7">
                    <div className="input-group">
                        <input type="text" className="form-control" id="exampleInputAmount" placeholder="Search" />
                        <span className="input-group-btn">
                            <button type="button" className="btn btn-info ml-2">Tìm kiếm</button>
                        </span>
                    </div>
                </div>
                <div className="col-xs-5 col-sm-5 col-md-5 col-lg-5">
                    <select name id="input" className="form-control" required="required">
                        <option value="a">Sắp xếp theo tên : A-Z</option>
                    </select>
                </div>
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


            <div className="row mt-3 ml-3 mr-3">
                <div>
                    <h3 className="text-center mt-2">Sửa khách hàng</h3>
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
                    <button type="button" className="btn btn-primary mr-2">Sửa</button>
                    <button type="button" className="btn btn-danger mr-2">Hủy</button>
                </div>
            </div>

        </div>
    )
}

export default CustomAdmin
