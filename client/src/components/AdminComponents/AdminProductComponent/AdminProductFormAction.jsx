import React, { useState } from 'react'

function AdminProductFormAction(props) {

    const [Id, setId] = useState(-1);

    return (
        <div style={{width:'100%'}}>
            <div className="row">
                <h3 className="text-center mt-2">Thêm Sản Phẩm</h3>
                <hr />
            </div>
            <table className="table table-hover">
                <tbody>
                    <tr>
                        <td>Id</td>
                        <td>
                            <input type="email" className="form-control" required="required" enabled={Id != -1} />
                        </td>
                    </tr>
                    <tr>
                        <td>Mã loại sản phẩm</td>
                        <td>
                            <input type="email" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Mã thương hiệu</td>
                        <td>
                            <input type="email" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Mã dây</td>
                        <td>
                            <input type="email" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Mã máy</td>
                        <td>
                            <input type="email" className="form-control" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td>Mã nhà cung cấp</td>
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
                        <td>Số lượng</td>
                        <td>
                            <input type="email" className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Giá</td>
                        <td>
                            <input type="email" className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Mô tả</td>
                        <td>
                            <input type="email" className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Hình ảnh</td>
                        <td>
                            <input type="email" className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Trạng thái</td>
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
    )
}

export default AdminProductFormAction
