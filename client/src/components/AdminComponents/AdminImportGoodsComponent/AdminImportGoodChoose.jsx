import React from 'react'
import AdminImportGoodItem from './AdminImportGoodItem'

function AdminImportGoodChoose() {
    return (
        <div>
            <div className="row mb-2 text-center" style={{ fontSize: '150%', fontWeight: 'bold' }}>
                Thông tin phiếu nhập
            </div>
            <div className="row">
                <table className="table table-bordered table-hover">
                    <tbody>
                        <tr>
                            <td>Nhân viên</td>
                            <td>
                                <input type="text" className="form-control" required="required" disabled/>
                            </td>
                        </tr>
                        <tr>
                            <td>Tên người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Số điện thoại người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Email người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Địa chỉ người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div className="row mb-2 text-center" style={{ fontSize: '150%', fontWeight: 'bold' }}>
                Sản phẩm đã chọn
            </div>
            <div className="row table-import-goods-action">
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Tên</th>
                            <th>Hình ảnh</th>
                            <th>Số lượng</th>
                            <th>Giá</th>
                            <th>Tổng tiền</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        <AdminImportGoodItem />
                        {/* <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem />
                        <AdminImportGoodItem /> */}
                    </tbody>
                </table>

            </div>
            <div className="row">
                <div className="col-lg-4 offset-lg-4">
                    <div className="proceed-checkout">
                        <ul>
                            <li className="subtotal">Tổng sản phẩm <span>120</span></li>
                            <li className="cart-total">Thành tiền <span>432432432</span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div className="row d-flex justify-content-center mt-3 mb-3">
                
                <button type="button" className="btn btn-primary">Lập phiếu nhập</button>
                <button type="button" className="btn btn-danger ml-3">Hủy</button>
                
            </div>
        </div>
    )
}

export default AdminImportGoodChoose
