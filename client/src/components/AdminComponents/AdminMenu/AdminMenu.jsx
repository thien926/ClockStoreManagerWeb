import React from 'react'
import CustomLinkAdmin from '../CustomLinkAdmin/CustomLinkAdmin'
import { CustomLinkMobileMenuAdmin } from '../CustomLinkAdmin/CustomLinkAdmin'

function AdminMenu() {
    return (
        <div>
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

                        <CustomLinkMobileMenuAdmin to='/admin/account'>Tài khoản</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/custom'>Khách hàng</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/staff'>Nhân viên</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/ncc'>Nhà cung cấp</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/brand'>Thương hiệu</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/products'>Sản phẩm</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/product-type'>Loại sản phẩm</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to="/admin/machine">Kiểu máy</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to="/admin/wire">Kiểu dây</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/permission'>Quyền</CustomLinkMobileMenuAdmin>
                        <CustomLinkMobileMenuAdmin to='/admin/bill'>Hóa đơn</CustomLinkMobileMenuAdmin>

                    </div>
                </div>
            </div>
            <div className="sidebar">
                <h3>Admin</h3>
                <CustomLinkAdmin to='/admin/account'>Tài khoản</CustomLinkAdmin>
                <CustomLinkAdmin to='/admin/custom'>Khách hàng</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/staff">Nhân viên</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/ncc">Nhà cung cấp</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/brand">Thương hiệu</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/products">Sản phẩm</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/product-type">Loại sản phẩm</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/machine">Kiểu máy</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/wire">Kiểu dây</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/permission">Quyền</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/bill">Hóa đơn</CustomLinkAdmin>
            </div>
        </div>
    )
}

export default AdminMenu
