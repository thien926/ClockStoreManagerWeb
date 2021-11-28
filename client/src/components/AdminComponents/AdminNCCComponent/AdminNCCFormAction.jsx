import React, { useEffect, useState } from 'react'

function AdminNCCFormAction(props) {

    const { formValue } = props;

    const [id, setId] = useState(null);
    const [name, setName] = useState('');
    const [address, setAddress] = useState('');
    const [phone, setPhone] = useState('');
    const [fax, setFax] = useState('');
    const [title, setTitle] = useState('Thêm nhà cung cấp')

    const [noteName, setNoteName] = useState('');
    const [noteAddress, setNoteAddress] = useState('');
    const [notePhone, setNotePhone] = useState('');
    const [noteFax, setNoteFax] = useState('');

    useEffect(() => {
        setId(formValue.id);
        setName(formValue.name);
        setAddress(formValue.address);
        setPhone(formValue.phone);
        setFax(formValue.fax);

        setNoteName('');
        setNoteAddress('');
        setNotePhone('');
        setNoteFax('');

        if(formValue.id) {
            setTitle('Sửa nhà cung cấp có Id = ' + formValue.id);
        }
        else {
            setTitle('Thêm nhà cung cấp');
        }
        
    }, [formValue])

    const showBtnSubmit = () => {
        // console.log("showBtnSubmit");
        if(formValue.id) {
            return <button type="button" onClick={actionSubmit} className="btn btn-primary mr-2">Sửa</button>;
        }
        else {
            return <button type="button" onClick={actionSubmit} className="btn btn-primary mr-2">Thêm</button>;
        }
    }

    const actionSubmit = () => {
        setNoteName('');
        setNoteAddress('');
        setNotePhone('');
        setNoteFax('');

        var temp = true;

        if(!name) {
            setNoteName('Tên nhà cung cấp là bắt buộc!');
            temp = false;
        }
        else {
            if(name.length < 3) {
                setNoteName('Tên nhà cung cấp tối thiểu 3 kí tự!');
                temp = false;
            }
    
            if(name.length > 200) {
                setNoteName('Tên nhà cung cấp nhiều nhất là 200 kí tự!');
                temp = false;
            }
        }

        if(!address) {
            setNoteAddress('Địa chỉ là bắt buộc!');
            temp = false;
        }

        if(!phone) {
            setNotePhone('Số điện thoại là bắt buộc!');
            temp = false;
        }
        else {
            // let format = /\D/g;
            // if(format.test(phone)){
            //     setNotePhone("Số điện thoại phải là chữ số!");
            //     temp = false;
            // }
            let format = /(09|03|07|08|05)[0-9]{8}/ig;
            if(!format.test(phone)){
                setNotePhone("Số điện thoại không phù hợp!");
                temp = false;
            }
            else {
                
                if(phone.length !== 10) {
                    setNotePhone('Số điện thoại phải có 10 kí tự!');
                    temp = false;
                }
            }
        }

        if(fax) {
            let format = /[1-9]{4}-[1-9]{4}-[1-9]{4}-[1-9]{4}/g;
            if(!format.test(fax)){
                setNoteFax("Số fax không hợp lệ!");
                temp = false;
            }
        }

        if(!temp){
            return;
        }

        var data = {
            id : id,
            name : name,
            address: address,
            phone: phone,
            fax: fax
        }

        if(!id) {
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
                        <td>Tên nhà cung cấp</td>
                        <td>
                            <input type="text" className="form-control" required="required" value={name} onChange={(e) => setName(e.target.value)}/>
                        </td>
                        <td className='note-validate'>
                            {noteName}
                        </td>
                    </tr>
                    <tr>
                        <td>Địa chỉ</td>
                        <td>
                            <input type="text" className="form-control" required="required" value={address} onChange={(e) => setAddress(e.target.value)}/>
                        </td>
                        <td className='note-validate'>
                            {noteAddress}
                        </td>
                    </tr>
                    <tr>
                        <td>Số điện thoại</td>
                        <td>
                            <input type="text" className="form-control" required="required" value={phone} onChange={(e) => setPhone(e.target.value)}/>
                        </td>
                        <td className='note-validate'>
                            {notePhone}
                        </td>
                    </tr>
                    <tr>
                        <td>Số fax</td>
                        <td>
                            <input type="text" className="form-control" required="required" value={fax} onChange={(e) => setFax(e.target.value)}/>
                        </td>
                        <td className='note-validate'>
                            {noteFax}
                        </td>
                    </tr>
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

export default AdminNCCFormAction
