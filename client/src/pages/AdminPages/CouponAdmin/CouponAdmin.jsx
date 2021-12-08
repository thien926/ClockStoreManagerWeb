import React, { useCallback, useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useLocation, useNavigate } from 'react-router';
import { toast } from 'react-toastify';
import AdmimCouponFormAction from '../../../components/AdminComponents/AdminCouponComponent/AdmimCouponFormAction';
import AdminCouponControl from '../../../components/AdminComponents/AdminCouponComponent/AdminCouponControl';
import AdminCouponItem from '../../../components/AdminComponents/AdminCouponComponent/AdminCouponItem';
import AdminCouponPaging from '../../../components/AdminComponents/AdminCouponComponent/AdminCouponPaging';
import { DELETE_COUPON_ERROR } from '../../../constants/Message';
import { actDeleteCouponAdmin, actGetCouponAdmin, actResetMessageCouponAdmin, actUpdateCouponStatusAdmin } from '../../../redux/actions/AdminCouponAction';

function CouponAdmin() {
    const AdminCouponReducer = useSelector(state => state.AdminCouponReducer)

    const [search, setSearch] = useState('');
    const [status, setStatus] = useState(0);
    const [pageIndex, setPageIndex] = useState(1);
    const [elmListBills, setElmListBills] = useState(null);
    const [itemEdit, setItemEdit] = useState('');

    const location = useLocation();
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const utf8_from_str = (s) => {
        var temp = decodeURIComponent(s);
        temp = temp.split("+");
        temp = temp.join(" ");
        return temp;
    }

    // Load status, search, pageIndex
    useEffect(() => {
        // console.log("location: ", location);
        var { search } = location;
        if(search === "") {
            setStatus(0);
            setPageIndex(1);
            setSearch('');
        } 
        else {
            var dauHoi = search.split('?');
            var dauVa = dauHoi[dauHoi.length-1].split('&');
            var dauBang, value;
            for(let i = 0; i < dauVa.length; ++i) {
                dauBang = dauVa[i].split('=');
                switch (dauBang[0]) {
                    case "status":
                        value = parseInt(dauBang[1]);
                        if(value) {
                            setStatus(value);
                        }
                        else {
                            setStatus(0);
                        }
                        break;
                    case "pageIndex":
                        value = parseInt(dauBang[1]);
                        if(value) {
                            setPageIndex(value);
                        }
                        else {
                            setPageIndex(1);
                        }
                        
                        break;
                    case "search":
                        setSearch(utf8_from_str(dauBang[1]));
                        break;
                    default:
                        break;
                }
            }
        }
    }, [location])

    useEffect(() => {
        var data = {
            status,
            search,
            pageIndex
        }
        dispatch(actGetCouponAdmin(data));
    }, [search, status, pageIndex, dispatch])

    useEffect(() => {
        // console.log()
        var result = null;
        if(AdminCouponReducer.dataValue.listPN && AdminCouponReducer.dataValue.listPN.length > 0) {
            result = AdminCouponReducer.dataValue.listPN.map((item, index) => {
                return <AdminCouponItem key={index} coupon={item} index={index} actionDelete={actionDelete} setItemEdit={setItemEdit}/>
            })
        }
        setElmListBills(result);
    }, [AdminCouponReducer.dataValue])

    // Hiên thông báo các sự kiện
    useEffect(() => {
        if(AdminCouponReducer.message) {
            if(AdminCouponReducer.message.type === "success") {
                toast.success(AdminCouponReducer.message.value);
                var filter = {
                    search : search,
                    status: status,
                    pageIndex:pageIndex
                }
                // console.log(filter);
                dispatch(actGetCouponAdmin(filter));
                dispatch(actResetMessageCouponAdmin());
            }
            else if(AdminCouponReducer.message.type === "error") {
                toast.error(AdminCouponReducer.message.value); 
                dispatch(actResetMessageCouponAdmin());
            }
        }
    }, [AdminCouponReducer.message, dispatch])

    // đi đến URL khác khi search
    const changeSearch = (searchValue) => {
        navigate('/admin/coupon?search=' + searchValue + '&status=' + status + '&pageIndex=' + pageIndex);
    }

    // đi đến URL khác khi status
    const changeStatus = (statusValue) => {
        navigate('/admin/coupon?search=' + search + '&status=' + statusValue + '&pageIndex=' + pageIndex);
    }

    // Thực hiện thao tác xóa
    const actionDelete = (id) => {
        var res = window.confirm("Bạn có chắc muốn xóa phiếu nhập có Id = " + id + " không?");
        if(res) {
            dispatch(actDeleteCouponAdmin(id));
        }
        else {
            toast.error(DELETE_COUPON_ERROR);
        }
    }

    const showForm = useCallback(
        () => {
            if(itemEdit) {
                return <AdmimCouponFormAction itemEdit={itemEdit} setItemEdit={setItemEdit} submitUpdateCouponStatus={submitUpdateCouponStatus}/>
            }
            return null;
        },
        [itemEdit],
    )

    const submitUpdateCouponStatus = (data, id) => {
        dispatch(actUpdateCouponStatusAdmin(data, id));
        setItemEdit('');
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý phiếu nhập</h3>
                <hr />
            </div>
            
            <AdminCouponControl search={search} status={status} changeSearch={changeSearch} changeStatus={changeStatus} />
            
            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>Id</th>
                            <th>Nhân viên</th>
                            <th>Người cung cấp</th>
                            <th>Số điện thoại</th>
                            <th>Thư điện tử</th>
                            <th>Địa chỉ</th>
                            <th>Ngày nhận</th>
                            <th>Tổng</th>
                            <th>Trạng thái</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* <AdminWireItem /> */}
                        {elmListBills}
                    </tbody>
                </table>
            </div>

            <AdminCouponPaging dataValue={AdminCouponReducer.dataValue}/>

            {showForm()}

        </div>
    )
}

export default CouponAdmin
