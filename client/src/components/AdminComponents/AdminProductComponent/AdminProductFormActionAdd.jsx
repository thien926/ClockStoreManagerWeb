import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { actGetAllBrandAdmin } from '../../../redux/actions/AdminBrandAction';
import { actGetAllMachineAdmin } from '../../../redux/actions/AdminMachineAction';
import { actGetAllProductTypeAdmin } from '../../../redux/actions/AdminProductTypeAction';
import { actGetAllWireAdmin } from '../../../redux/actions/AdminWireAction';

const defaultImgSrc = '/img/null.png';

const initialFieldValues = {
    lspId: '',
    brandId: '',
    wireId: '',
    machineId: '',
    nccId: '',
    name: '',
    amount: 0,
    description: '',
    img: defaultImgSrc,
    imgFile: null
}

function AdminProductFormActionAdd(props) {

    const AdminWireReducer = useSelector(state => state.AdminWireReducer)
    const AdminProductTypeReducer = useSelector(state => state.AdminProductTypeReducer);
    const AdminBrandReducer = useSelector(state => state.AdminBrandReducer);
    const AdminMachineReducer = useSelector(state => state.AdminMachineReducer);

    const [elmListWire, setElmListWire] = useState(null);
    const [elmListProductType, setElmListProductType] = useState(null);
    const [elmListBrand, setElmListBrand] = useState(null);
    const [elmListMachine, setElmListMachine] = useState(null);
    // const [elmListNCC, setElmListNCC] = useState(null);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(actGetAllWireAdmin());
        dispatch(actGetAllProductTypeAdmin());
        dispatch(actGetAllBrandAdmin());
        dispatch(actGetAllMachineAdmin());
    }, [dispatch])

    useEffect(() => {
        var result = null;
        setElmListWire(null);
        setElmListProductType(null);
        setElmListBrand(null);
        setElmListMachine(null);
        // setElmListNCC(null);

        if (AdminWireReducer.dataValue && AdminWireReducer.dataValue.length > 0) {
            // console.log(AdminWireReducer.dataValue);
            result = AdminWireReducer.dataValue.map((item, index) => {
                return <option key={index} value={`${item.id}`}>{item.id} - {item.name}</option>
            })
            setElmListWire(result);
        }

        if (AdminProductTypeReducer.dataValue && AdminProductTypeReducer.dataValue.length > 0) {
            // console.log(AdminProductTypeReducer.dataValue);
            result = AdminProductTypeReducer.dataValue.map((item, index) => {
                return <option key={index} value={`${item.id}`}>{item.id} - {item.name}</option>
            })
            setElmListProductType(result);
        }

        if (AdminBrandReducer.dataValue && AdminBrandReducer.dataValue.length > 0) {
            // console.log(AdminBrandReducer.dataValue);
            result = AdminBrandReducer.dataValue.map((item, index) => {
                return <option key={index} value={`${item.id}`}>{item.id} - {item.name}</option>
            })
            setElmListBrand(result);
        }

        if (AdminMachineReducer.dataValue && AdminMachineReducer.dataValue.length > 0) {
            // console.log(AdminMachineReducer.dataValue);
            result = AdminMachineReducer.dataValue.map((item, index) => {
                return <option key={index} value={`${item.id}`}>{item.id} - {item.name}</option>
            })
            setElmListMachine(result);
        }

        // if (AdminNCCReducer.dataValue && AdminNCCReducer.dataValue.length > 0) {
        //     // console.log(AdminNCCReducer.dataValue);
        //     result = AdminNCCReducer.dataValue.map((item, index) => {
        //         return <option key={index} value={`${item.id}`}>{item.id} - {item.name}</option>
        //     })
        //     setElmListNCC(result);
        // }
    }, [AdminWireReducer.dataValue, AdminProductTypeReducer.dataValue, AdminBrandReducer.dataValue, AdminMachineReducer.dataValue])

    const [values, setValues] = useState(initialFieldValues);

    const handleInputChange = (e) => {
        // console.log(values);
        const { name, value } = e.target;
        setValues({
            ...values,
            [name]: value
        });
    }

    const showPreview = (e) => {
        if(e.target.files && e.target.files[0]) {
            let imageFile = e.target.files[0];

            const reader = new FileReader();
            reader.onload = x => {
                setValues({
                    ...values,
                    imgFile : imageFile,
                    // img : imageFile.name
                    img : x.target.result
                })
            };
            reader.readAsDataURL(imageFile)
        }
        else {
            setValues({
                ...values,
                imgFile : null,
                img : defaultImgSrc
            })
        }
        console.log(values);
    }

    const handleFormSubmit = () => {

    }

    return (
        <div style={{ width: '100%' }}>
            <div className="row">
                <h3 className="text-center mt-2">Thêm Sản Phẩm</h3>
                <hr />
            </div>
            <table className="table table-hover">
                <tbody>
                    <tr>
                        <td>Mã loại sản phẩm</td>
                        <td>
                            <select name="lspId" value={values.lspId} onChange={handleInputChange} className="form-control" required="required">
                                <option value="">Null</option>
                                {elmListProductType}
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>Mã thương hiệu</td>
                        <td>
                            <select name="brandId" value={values.brandId} onChange={handleInputChange} className="form-control" required="required">
                                <option value="">Null</option>
                                {elmListBrand}
                            </select>
                            {/* <input type="text" name="brandId" value={values.brandId} onChange={handleInputChange} className="form-control" required="required" /> */}
                        </td>
                    </tr>
                    <tr>
                        <td>Mã dây</td>
                        <td>
                            <select name="wireId" value={values.wireId} onChange={handleInputChange} className="form-control" required="required">
                                <option value="">Null</option>
                                {elmListWire}
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>Mã máy</td>
                        <td>
                            <select name="machineId" value={values.machineId} onChange={handleInputChange} className="form-control" required="required">
                                <option value="">Null</option>
                                {elmListMachine}
                            </select>
                            {/* <input type="text" name="machineId" value={values.machineId} onChange={handleInputChange} className="form-control" required="required" /> */}
                        </td>
                    </tr>
                    <tr>
                        <td>Tên</td>
                        <td>
                            <input type="text" name="name" value={values.name} onChange={handleInputChange} className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Số lượng</td>
                        <td>
                            <input type="email" className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Mô tả</td>
                        <td>
                            <textarea type="text" name="description" value={values.description} onChange={handleInputChange} className="form-control" required="required" />

                        </td>
                    </tr>
                    <tr>
                        <td>Hình ảnh</td>
                        <td>
                            <input onChange={showPreview} type="file" accept="image/*" name="imgFile" className="form-control-file" required="required" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <img src={`${values.img}`} />
                        </td>
                        
                    </tr>
                </tbody>
            </table>
            <div className="mb-3">
                <button type="button" className="btn btn-primary mr-2">Thêm</button>
                <button type="button" className="btn btn-danger mr-2">Hủy</button>
            </div>
        </div>
    )
}

export default AdminProductFormActionAdd
