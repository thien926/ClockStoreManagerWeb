import React from 'react'
import { Link } from 'react-router-dom'
import './ProductsAdmin.css'
function ProductsAdmin() {

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý sản phẩm</h3>
                <hr />
            </div>
            <div className="row">
                <div className="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                    <button type="button" className="btn btn-primary">Thêm sản phẩm <i className="fa fa-plus-circle" aria-hidden="true" /></button>
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

            <div className='class-phan-trang'>
                
                <Link className='btn btn-info' to='1'>1</Link>
                <a className='btn btn-default' href='1'>2</a>
                <a className='btn btn-default' href='1'>3</a>
                <a className='btn btn-default' href='1'>4</a>
                <a className='btn btn-default' href='1'>5</a>
            </div>

            <div className="row mt-3">
                <div>
                    <h3 className="text-center mt-2">Thêm công việc</h3>
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

export default ProductsAdmin
