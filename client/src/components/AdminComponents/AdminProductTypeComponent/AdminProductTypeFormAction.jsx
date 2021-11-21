import React, { useCallback, useEffect, useState } from 'react'

function AdminProductTypeFormAction(props) {

    const { formAction } = props;

    const [id, setId] = useState(null);
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [title, setTitle] = useState('Thêm loại sản phẩm');

    useEffect(() => {
        setId(formAction.id);
        setName(formAction.name);
        setDescription(formAction.description);

        if(formAction.id) {
            setTitle("Sửa loại sản phẩm có Id = " + formAction.id);
        }
        else {
            setTitle("Thêm loại sản phẩm");
        }
    }, [formAction])

    const actionSubmit = () => {
        var data = {
            id : id,
            name : name,
            description : description
        }
        if(!id) {
            data.id = 1;
        }
        props.submitActionForm(data);
        // console.log(data);
    }

    const showBtnSubmit = () => {
        // console.log("showBtnSubmit");
        if(formAction.id) {
            return <button type="button" onClick={actionSubmit} className="btn btn-primary mr-2">Sửa</button>
        }
        return <button type="button" onClick={actionSubmit} className="btn btn-primary mr-2">Thêm</button>;
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
                        <td>Tên loại sản phẩm: </td>
                        <td>
                            <input type="text" className="form-control" required="required" value={name} onChange={(e) => setName(e.target.value)}/>
                        </td>
                    </tr>
                    <tr>
                        <td>Mô tả: </td>
                        <td>
                            <input type="text" className="form-control" required="required" value={description} onChange={(e) => setDescription(e.target.value)}/>

                        </td>
                    </tr>
                </tbody>
            </table>
            <div className="mb-3">
                {showBtnSubmit()}
                <button type="button" className="btn btn-danger mr-2" onClick={() => props.setActionValue('')}>Hủy</button>
            </div>
        </div>
    )
}

export default AdminProductTypeFormAction
