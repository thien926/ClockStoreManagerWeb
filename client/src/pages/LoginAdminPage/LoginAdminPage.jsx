import React, { useEffect, useState } from 'react'
import './LoginAdminPage.css'
import { useDispatch, useSelector } from 'react-redux'
import { actGetUser, actLoginAdmin } from '../../redux/actions/LoginAdminAction';

function LoginAdmin() {

    const loginAdmin = useSelector(state => state.LoginAdminReducer)
    // console.log("login", loginAdmin);
    const [user, setUser] = useState(loginAdmin.user);
    const [password, setPassword] = useState(loginAdmin.password);

    const dispatch = useDispatch();

    const onSubmit = (e) => {
        e.preventDefault();
        const data = {
            user: user,
            password : password
        }

        dispatch(actLoginAdmin(data));
        setUser('');
        setPassword('');
    }

    return (
        <div className="bg">
            <div className="row">
                <form className="form" onSubmit={onSubmit}>
                    <div className="form-group mx-auto">
                        <legend>Đăng nhập</legend>
                    </div>

                    <div className="form-group mt-4">
                        <label htmlFor="exampleInputEmail1">Tên đăng nhập : </label>
                        <input type="text" className="form-control" placeholder="Username" value={user} onChange={(e) => setUser(e.target.value)}/>
                        <small className="note form-text text-muted">We'll never share your email with anyone else.</small>
                    </div>
                    <div className="form-group mt-4">
                        <label htmlFor="exampleInputPassword1">Mật khẩu : </label>
                        <input type="password" className="form-control" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                        <small className="note form-text text-muted">We'll never share your email with anyone else.</small>
                    </div>
                    <button type="submit" className="btn btn-primary mt-4">Đăng nhập</button>
                </form>
            </div>
        </div>

    )
}

export default LoginAdmin
