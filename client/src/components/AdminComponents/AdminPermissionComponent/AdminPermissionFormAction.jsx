import React, { useEffect, useState } from 'react'

function AdminPermissionFormAction(props) {

    const { formValue } = props;

    const [title, setTitle] = useState('Thêm quyền')
    const [id, setId] = useState(null);
    const [name, setName] = useState('');
    const [details, setDetails] = useState('');

    const [NhanVien, setNhanVien] = useState('');
    const [NhapHang, setNhapHang] = useState('');
    const [SanPham, setSanPham] = useState('');
    const [HoaDon, setHoaDon] = useState('');
    const [KhachHang, setKhachHang] = useState('');
    const [PhieuNhap, setPhieuNhap] = useState('');
    const [NCC, setNCC] = useState('');
    const [TaiKhoan, setTaiKhoan] = useState('');
    const [Quyen, setQuyen] = useState('');
    const [LoaiSanPham, setLoaiSanPham] = useState('');
    const [ThuongHieu, setThuongHieu] = useState('');
    const [KieuMay, setKieuMay] = useState('');
    const [KieuDay, setKieuDay] = useState('');
    const [ThongKe, setThongKe] = useState('');

    const [noteName, setNoteName] = useState('');
    const [noteDetails, setNoteDetails] = useState('');

    useEffect(() => {
        setId(formValue.id);
        setName(formValue.name);
        setDetails(formValue.details);

        setNoteName('');
        setNoteDetails('');

        if (formValue.id) {
            setTitle('Sửa quyền có Id = ' + formValue.id);
        }
        else {
            setTitle('Thêm quyền');
        }

    }, [formValue])

    const showBtnSubmit = () => {
        // console.log("showBtnSubmit");
        if (formValue.id) {
            return <button type="button" onClick={actionSubmit} className="btn btn-primary mr-2">Sửa</button>;
        }
        else {
            return <button type="button" onClick={actionSubmit} className="btn btn-primary mr-2">Thêm</button>;
        }
    }

    const actionSubmit = () => {
        setNoteName('');
        setNoteDetails('');

        var temp = true;

        if (!name) {
            setNoteName('Tên quyền là bắt buộc!');
            temp = false;
        }
        else {
            if (name.length < 3) {
                setNoteName('Tên quyền tối thiểu 3 kí tự!');
                temp = false;
            }

            if (name.length > 200) {
                setNoteName('Tên quyền nhiều nhất là 200 kí tự!');
                temp = false;
            }
        }

        if (!details) {
            setNoteDetails('Chi tiết quyền là bắt buộc!');
            temp = false;
        }


        if (!temp) {
            return;
        }

        var data = {
            id: id,
            name: name,
            details: details
        }

        if (!id) {
            data.id = 1;
            props.submitActionForm(data, 'add');
        }
        else {
            props.submitActionForm(data, 'update');
        }

    }

    return (
        <div className="row mt-3 ml-3 mr-3">
            <div>
                <h3 className="text-center mt-2">{title}</h3>
                <hr />
            </div>
            <table className="table table-hover ">
                <tbody>
                    <tr>
                        <td>Tên quyền</td>
                        <td>
                            <input type="text" className="form-control" required="required" value={name} onChange={(e) => setName(e.target.value)} />
                        </td>
                        <td className='note-validate'>
                            {noteName}
                        </td>
                    </tr>
                    <tr>
                        <td>Chi tiết quyền:</td>
                        {/* <td>Tài khoản có ít nhất 1 quyền</td> */}
                    </tr>
                    <tr>
                        <td><span className="ml-4">Quyền quản lý tài khoản</span></td>
                        <td>
                            <select className="form-control" required="required">
                                <option value="">Không có quyền</option>
                                <option value="xemTaiKhoan">Chỉ xem</option>
                                <option value="qlTaiKhoan">Xem và quản lý</option>
                            </select>
                        </td>
                        <td className='note-validate'>
                            {noteName}
                        </td>
                    </tr>
                    
                    {/* <tr>
                        <td>Chi tiết quyền</td>
                        <td>
                            <input type="text" className="form-control" required="required" value={details} onChange={(e) => setDetails(e.target.value)}/>
                        </td>
                        <td className='note-validate'>
                            {noteDetails}
                        </td>
                    </tr> */}
                </tbody>
            </table>
            <div className="mb-3">
                {/* <button type="button" className="btn btn-primary mr-2">Thêm</button> */}
                {showBtnSubmit()}
                <button onClick={() => props.setActionValue('')} type="button" className="btn btn-danger mr-2">Hủy</button>
            </div>
        </div>
    )
}

export default AdminPermissionFormAction
