import React from 'react'

function AdminProductTypeControl() {
    return (
        <div className="row">
            <div className="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                <button type="button" className="btn btn-primary">Thêm loại sản phẩm <i className="fa fa-plus-circle" aria-hidden="true" /></button>
            </div>
            <div className="col-xs-6 col-sm-6 col-md-6 col-lg-6">
                <div className="input-group">
                    <input type="text" className="form-control" id="exampleInputAmount" placeholder="Search" />
                    <span className="input-group-btn">
                        <button type="button" className="btn btn-info ml-2">Tìm kiếm</button>
                    </span>
                </div>
            </div>
            <div className="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                <select name id="input" className="form-control" required="required">
                    <option value="a">Sắp xếp theo tên : A-Z</option>
                </select>
            </div>
        </div>
    )
}

export default AdminProductTypeControl
