import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { toast } from 'react-toastify'
import { ACT_LOGOUT_ERROR, ACT_LOGOUT_SUCCESS } from '../../../constants/Message'
import { actGetUser, actLogoutAdmin, actResetMessageUserNhanVien } from '../../../redux/actions/LoginAdminAction'
import CustomLinkAdmin from '../CustomLinkAdmin/CustomLinkAdmin'
import { CustomLinkMobileMenuAdmin } from '../CustomLinkAdmin/CustomLinkAdmin'

function AdminMenu() {
    const UserAdmin = useSelector(state => state.LoginAdminReducer)
    const [user, setUser] = useState('');

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(actGetUser());
    }, [dispatch])

    useEffect(() => {
        // console.log("Current User Admin : ", UserAdmin);
        if (UserAdmin.dataValue.name) {
            setUser(UserAdmin.dataValue.name);
        }
    }, [UserAdmin.dataValue])

    useEffect(() => {
        switch (UserAdmin.message) {
            case ACT_LOGOUT_SUCCESS:
                toast.success(UserAdmin.message);
                dispatch(actResetMessageUserNhanVien());
                break;
            case ACT_LOGOUT_ERROR:
                toast.error(UserAdmin.message);
                dispatch(actResetMessageUserNhanVien());
                break;

            default:
                break;
        }
    }, [UserAdmin.message])

    const submitLogout = () => {
        dispatch(actLogoutAdmin());
    }

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
                <CustomLinkAdmin to="/admin/brand">Thương hiệu</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/products">Sản phẩm</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/product-type">Loại sản phẩm</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/machine">Kiểu máy</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/wire">Kiểu dây</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/permission">Quyền</CustomLinkAdmin>
                <CustomLinkAdmin to="/admin/bill">Hóa đơn</CustomLinkAdmin>
            </div>

            <nav className="navbar navbar-inverse border-bottom">
                <ul className="nav navbar-nav">
                </ul>
                <p className="navbar-text"><span>{user}</span> | <button onClick={submitLogout}>Đăng xuất</button></p>
            </nav>
        </div>
    )
}

export default AdminMenu
