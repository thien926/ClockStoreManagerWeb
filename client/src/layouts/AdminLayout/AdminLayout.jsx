import React from 'react'
import { Outlet } from 'react-router'
import './AdminLayout.css'

function AdminLayout() {
    return (
        <div className='layout-admin'>
            <div id="accordianId" role="tablist" aria-multiselectable="true">
                <div className="card">
                    <div className="card-header" role="tab" id="section1HeaderId">
                        <h5 className="mb-0">
                            <button type="button" className="btn btn-info btn-collapse" data-target="#section1ContentId" data-toggle="collapse" aria-pressed="false" autoComplete="false">
                                <i className="fa fa-align-justify" aria-hidden="true" />
                            </button>
                            <a className="navbar-brand">Admin</a>
                        </h5>
                    </div>
                    <div id="section1ContentId" className="collapse in" role="tabpanel" aria-labelledby="section1HeaderId">
                        <div className="card-body">
                            <a className="text-link">Tài khoản</a>
                        </div>
                        <div className="card-body">
                            <a className="text-link">Khách hàng</a>
                        </div>
                        <div className="card-body">
                            <a className="text-link">Nhân viên</a>
                        </div>
                        <div className="card-body">
                            <a className="text-link">Sản phẩm</a>
                        </div>
                        <div className="card-body">
                            <a className="text-link">Loại sản phẩm</a>
                        </div>
                        <div className="card-body">
                            <a className="text-link">Quyền</a>
                        </div>
                        <div className="card-body">
                            <a className="text-link">Hóa đơn</a>
                        </div>
                    </div>
                </div>
            </div>
            <div className="sidebar">
                <h3>Admin</h3>
                <a className="active" href="#home">Tài khoản</a>
                <a href="#news">Khách hàng</a>
                <a href="#contact">Nhân viên</a>
                <a href="#about">Sản phẩm</a>
                <a href="#about">Loại sản phẩm</a>
                <a href="#about">Quyền</a>
                <a href="#about">Hóa đơn</a>
            </div>
            <div className="content">
                <div>
                    <h3 className="text-center mt-2">Quản lý công việc</h3>
                    <hr />
                </div>

                <Outlet />
            </div>
        </div>
    )
}

export default AdminLayout
