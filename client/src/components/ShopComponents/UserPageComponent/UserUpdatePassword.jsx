import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router';
import { toast } from 'react-toastify';
import { ACT_KHACHHANG_NOTFOUND_ERROR, ACT_KHACHHANG_NOT_LOGIN_ERROR, ACT_LOGIN_PASSWORD_ERROR, ACT_UPDATE_KHACHHANG_PASSWORD_ERROR, ACT_UPDATE_KHACHHANG_PASSWORD_SUCCESS } from '../../../constants/Message';
import { actResetMessageUserKhachHang, actUpdatePasswordKhachHang } from '../../../redux/actions/UserKhachHangAction';

function UserUpdatePassword() {

    const UserKhachHangReducer = useSelector(state => state.UserKhachHangReducer)

    const [user, setUser] = useState('');
    const [oldPassword, setOldPassword] = useState('');
    const [newPassword, setNewPassword] = useState('');
    const [rePassword, setRePassword] = useState('');

    const [noteOldPassword, setNoteOldPassword] = useState('');
    const [noteNewPassword, setNoteNewPassword] = useState('');
    const [noteRePassword, setNoteRePassword] = useState('');

    const navigate = useNavigate();
    const dispatch = useDispatch();

    useEffect(() => {
        if (UserKhachHangReducer.dataValue.user) {
            setUser(UserKhachHangReducer.dataValue.user);
        }
    }, [UserKhachHangReducer.dataValue])

    useEffect(() => {
        switch (UserKhachHangReducer.message) {
            case ACT_UPDATE_KHACHHANG_PASSWORD_SUCCESS:
                toast.success(UserKhachHangReducer.message);
                dispatch(actResetMessageUserKhachHang());
                break;
            case ACT_KHACHHANG_NOT_LOGIN_ERROR:
            case ACT_KHACHHANG_NOTFOUND_ERROR:
            case ACT_LOGIN_PASSWORD_ERROR:
            case ACT_UPDATE_KHACHHANG_PASSWORD_ERROR:
                toast.error(UserKhachHangReducer.message);
                dispatch(actResetMessageUserKhachHang());
                break;
            default:
                break;
        }
    }, [UserKhachHangReducer.message, dispatch])

    const submitBtnUpdate = () => {
        let temp = true;

        if (!oldPassword) {
            temp = false;
            setNoteOldPassword('M???t kh???u l?? b???t bu???c!');
        }
        else {
            if (oldPassword.length < 4 || oldPassword.length > 25) {
                temp = false;
                setNoteOldPassword('M???t kh???u t??? 4 ?????n 25 k?? t???!');
            }
        }

        if (!newPassword) {
            temp = false;
            setNoteNewPassword('M???t kh???u m???i l?? b???t bu???c!');
        }
        else {
            if (newPassword.length < 4 || newPassword.length > 25) {
                temp = false;
                setNoteNewPassword('M???t kh???u m???i t??? 4 ?????n 25 k?? t???!');
            }
        }

        if (rePassword !== newPassword) {
            temp = false;
            setNoteRePassword('M???t kh???u m???i kh??ng kh???p!');
        }

        if (!temp) {
            return;
        }

        var data = {
            user,
            oldPassword,
            newPassword,
            rePassword
        }

        dispatch(actUpdatePasswordKhachHang(data));

        return;
    }

    const submitBtnHuy = () => {
        navigate('/user/detail');
    }

    return (
        <div className="col-lg-9 order-1 order-lg-2">
            <div className="product-show-option">
                <h4>S???a m???t kh???u c?? nh??n</h4>
            </div>
            <form>
                <table className="table table-hover">
                    <tbody>
                        <tr>
                            <td>Nh???p m???t kh???u c??: </td>
                            <td>
                                <input value={oldPassword} onChange={(e) => setOldPassword(e.target.value)} type="password" className="form-control" required="required" />
                            </td>
                            <td className="note-validate">{noteOldPassword}</td>
                        </tr>
                        <tr>
                            <td>Nh???p m???t kh???u m???i: </td>
                            <td>
                                <input value={newPassword} onChange={(e) => setNewPassword(e.target.value)} type="password" className="form-control" required="required" />
                            </td>
                            <td className="note-validate">{noteNewPassword}</td>
                        </tr>
                        <tr>
                            <td>Nh???p l???i m???t kh???u m???i: </td>
                            <td>
                                <input value={rePassword} onChange={(e) => setRePassword(e.target.value)} type="password" className="form-control" required="required" />
                            </td>
                            <td className="note-validate">{noteRePassword}</td>
                        </tr>

                    </tbody>
                </table>
                <button onClick={submitBtnUpdate} type="button" className="btn btn-primary">S???a</button>
                <button onClick={submitBtnHuy} type="button" className="btn btn-danger ml-3">H???y</button>
            </form>
        </div>
    )
}

export default UserUpdatePassword
