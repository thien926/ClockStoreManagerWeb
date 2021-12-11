import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux';
import { actChooseProduct } from '../../../redux/actions/AdminImportGoodsAction';
import AdminImportGoodItem from './AdminImportGoodItem'

function AdminImportGoodChoose(props) {

    const {itemChoose, dataAction} = props;
    const [totalAmount, setTotalAmount] = useState(0)
    const [totalPrice, setTotalPrice] = useState(0)

    const [elmItems, setElmItems] = useState(null);

    const dispatch = useDispatch();

    useEffect(() => {
        if(itemChoose) {
            dispatch(actChooseProduct(itemChoose));
        }
    }, [dispatch, itemChoose])

    useEffect(() => {
        let result = null, amount = 0, price = 0;
        if(dataAction.listSP && dataAction.listSP.length > 0) {
            
            result = dataAction.listSP.map((item, index) => {
                amount += item.amount;
                price += item.price * item.amount;
                return <AdminImportGoodItem changeDataAction={props.changeDataAction} key={index} item={item} deleteItemAction={props.deleteItemAction}/>
            })
        }
        setElmItems(result);
        setTotalAmount(amount);
        setTotalPrice(price);
    }, [dataAction, props.changeDataAction, props.deleteItemAction])

    return (
        <div>
            <div className="row mb-2 text-center" style={{ fontSize: '150%', fontWeight: 'bold' }}>
                Thông tin phiếu nhập
            </div>
            <div className="row">
                <table className="table table-bordered table-hover">
                    <tbody>
                        <tr>
                            <td>Nhân viên</td>
                            <td>
                                <input type="text" className="form-control" required="required" disabled/>
                            </td>
                        </tr>
                        <tr>
                            <td>Tên người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Số điện thoại người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Email người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                        <tr>
                            <td>Địa chỉ người cung cấp</td>
                            <td>
                                <input type="text" className="form-control" required="required" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div className="row mb-2 text-center" style={{ fontSize: '150%', fontWeight: 'bold' }}>
                Sản phẩm đã chọn
            </div>
            <div className="row table-import-goods-action">
                <table className="table table-hover">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Tên</th>
                            <th>Hình ảnh</th>
                            <th>Số lượng</th>
                            <th>Giá</th>
                            <th>Tổng tiền</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {elmItems}
                        {/* <AdminImportGoodItem /> */}
                    </tbody>
                </table>

            </div>
            <div className="row mt-2">
                <div className="col-lg-4 offset-lg-4">
                    <div className="proceed-checkout">
                        <ul>
                            <li className="subtotal">Tổng sản phẩm <span>{totalAmount}</span></li>
                            <li className="cart-total">Thành tiền <span>{totalPrice}</span></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div className="row d-flex justify-content-center mt-3 mb-3">
                
                <button type="button" className="btn btn-primary">Lập phiếu nhập</button>
                <button onClick={props.submitBtnHuy} type="button" className="btn btn-danger ml-3">Hủy</button>
                
            </div>
        </div>
    )
}

export default AdminImportGoodChoose
