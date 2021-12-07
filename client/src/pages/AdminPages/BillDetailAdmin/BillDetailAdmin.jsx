import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useLocation } from 'react-router';
import BillDetailItemAdmin from '../../../components/AdminComponents/BillDetailItemAdmin/BillDetailItemAdmin';
import { actGetBillDetailAdmin } from '../../../redux/actions/BillDetailAction';

function BillDetailAdmin() {

    const BillDetailReducer = useSelector(state => state.BillDetailReducer)

    const [amount, setAmount] = useState(0)
    const [total, setTotal] = useState(0)
    const [elmListItem, setelmListItem] = useState(null);
    const [Id, setId] = useState('');

    const location = useLocation();
    const dispatch = useDispatch();

    useEffect(() => {
        setId('');
        let Id = parseInt(location.pathname.replace("/admin/bill-detail/", ""));
        // console.log("Id", Id);
        if(Id) {
            setId(Id);
            dispatch(actGetBillDetailAdmin(Id));
        }
    }, [dispatch, location])

    useEffect(() => {
        var numberAmount = 0;
        var numberTotal = 0;
        var result = null;
        if(BillDetailReducer && BillDetailReducer.length > 0) {
            result = BillDetailReducer.map((item, index) => {
                numberAmount += item.amount;
                numberTotal += item.price * item.amount;
                return <BillDetailItemAdmin key={index} item={item} />
            })
            
        }

        setAmount(numberAmount);
        setTotal(numberTotal);
        setelmListItem(result);
    }, [BillDetailReducer])

    return (
        <div>
            <div className="breacrumb-section">
                <div className="container">
                    <div className="row">
                        <div className="col-lg-12">
                            <div className="breadcrumb-text product-more text-center">
                                <h4>Hóa đơn Id = {Id}</h4>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <section className="shopping-cart spad">
                <div className="container">
                    <div className="row">
                        <div className="col-lg-12">
                            <div className="cart-table">
                                <table>
                                    <thead>
                                        <tr>
                                            <th>Hình ảnh</th>
                                            <th className="p-name">Tên sản phẩm</th>
                                            <th>Giá</th>
                                            <th>Số lượng</th>
                                            <th>Tổng tiền</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {elmListItem}
                                    </tbody>
                                </table>
                            </div>
                            <div className="row">
                                {/* <div className="col-lg-4">
                                    <div className="discount-coupon">
                                        <h6>Phương thức giao hàng</h6>

                                        <select id="input" className="form-control" required="required">
                                            <option value>Thanh toán khi nhận hàng</option>
                                            <option disabled value={1}>Thanh toán online - Đang xây dựng</option>
                                        </select>


                                    </div>
                                    <div className="discount-coupon">
                                        <h6>Địa chỉ giao hàng</h6>
                                        <form className="coupon-form">
                                            <input value={address} onChange={(e) => setAddress(e.target.value)} style={{ color: 'black' }} type="text" placeholder="Nhập địa chỉ giao hàng" />
                                        </form>
                                    </div>
                                </div> */}
                                <div className="col-lg-4 offset-lg-4">
                                    <div className="proceed-checkout">
                                        <ul>
                                            <li className="subtotal">Tổng sản phẩm <span>{amount}</span></li>
                                            <li className="cart-total">Thành tiền <span>{total.toLocaleString('it-IT', { style: 'currency', currency: 'VND' })}</span></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    )
}

export default BillDetailAdmin