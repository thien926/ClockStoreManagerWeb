import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useLocation, Link, useNavigate } from 'react-router-dom'
import { actChangeStatusStaffAdmin, actGetStaffAdmin, actResetMessageStaffAdmin } from '../../../redux/actions/AdminStaffAction';
import { ACT_CHANGE_STATUS_STAFF_ADMIN_ERROR, ACT_OFF_STATUS_STAFF_ADMIN_SUCCESS, ACT_ON_STATUS_STAFF_ADMIN_SUCCESS } from '../../../constants/Message';
import { toast } from 'react-toastify';
import AdminStaffControl from '../../../components/AdminComponents/AdminStaffComponent/AdminStaffControl'
import AdminStaffItem from '../../../components/AdminComponents/AdminStaffComponent/AdminStaffItem'
import AdminStaffPaging from '../../../components/AdminComponents/AdminStaffComponent/AdminStaffPaging'
import AdminStaffFormAction from '../../../components/AdminComponents/AdminStaffComponent/AdminStaffFormAction';


function StaffAdmin() {
    const AdminStaffReducer = useSelector(state => state.AdminStaffReducer)

    const [search, setSearch] = useState('');
    const [sort, setSort] = useState('name-asc');
    const [pageIndex, setPageIndex] = useState(1);
    const [elmListStaffs, setElmListStaffs] = useState(null);

    const location = useLocation();
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const utf8_from_str = (s) => {
        var temp = decodeURIComponent(s);
        temp = temp.split("+");
        temp = temp.join(" ");
        return temp;
    }

    // Load sort, search, pageIndex
    useEffect(() => {
        // console.log("location: ", location);
        var { search } = location;
        if(search === "") {
            setSort('name-asc');
            setPageIndex(1);
            setSearch('');
        } 
        else {
            var dauHoi = search.split('?');
            var dauVa = dauHoi[dauHoi.length-1].split('&');
            var dauBang;
            for(let i = 0; i < dauVa.length; ++i) {
                dauBang = dauVa[i].split('=');
                switch (dauBang[0]) {
                    case "sort":
                        setSort(dauBang[1]);
                        break;
                    case "pageIndex":
                        var value = parseInt(dauBang[1]);
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
            sort,
            search,
            pageIndex
        }
        dispatch(actGetStaffAdmin(data));
    }, [search, sort, pageIndex, dispatch])

    useEffect(() => {
        // console.log(AdminStaffReducer.dataValue)
        var result = null;
        if(AdminStaffReducer.dataValue.listNV && AdminStaffReducer.dataValue.listNV.length > 0) {
            result = AdminStaffReducer.dataValue.listNV.map((item, index) => {
                return <AdminStaffItem key={index} staff={item} index={index} submitChangeStatus={submitChangeStatus}/>
            })
        }
        setElmListStaffs(result);
    }, [AdminStaffReducer.dataValue])

    // Hiên thông báo các sự kiện
    useEffect(() => {
        switch (AdminStaffReducer.message) {
            case ACT_OFF_STATUS_STAFF_ADMIN_SUCCESS:
            case ACT_ON_STATUS_STAFF_ADMIN_SUCCESS:
                toast.success(AdminStaffReducer.message);
                var filter = {
                    search : search,
                    sort: sort,
                    pageIndex:pageIndex
                }
                // console.log(filter);
                dispatch(actGetStaffAdmin(filter));
                dispatch(actResetMessageStaffAdmin());
                break;
            case ACT_CHANGE_STATUS_STAFF_ADMIN_ERROR : 
                toast.error(AdminStaffReducer.message); 
                dispatch(actResetMessageStaffAdmin());
                break;
            default:
                break;
        }
    }, [AdminStaffReducer.message])

    // đi đến URL khác khi search
    const changeSearch = (searchValue) => {
        navigate('/admin/staff?search=' + searchValue + '&sort=' + sort + '&pageIndex=' + pageIndex);
    }

    // đi đến URL khác khi sort
    const changeSort = (sortValue) => {
        navigate('/admin/staff?search=' + search + '&sort=' + sortValue + '&pageIndex=' + pageIndex);
    }

    const submitChangeStatus = (user) => {
        // console.log(user);
        dispatch(actChangeStatusStaffAdmin(user));
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý khách hàng</h3>
                <hr />
            </div>
            
            <AdminStaffControl search={search} sort={sort} changeSearch={changeSearch} changeSort={changeSort}/>

            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>Tài khoản</th>
                            <th>Tên</th>
                            <th>Số điện thoại</th>
                            {/* <th>Thư điện tử</th> */}
                            <th>Địa chỉ</th>
                            <th>Giới tính</th>
                            <th>Ngày sinh</th>
                            <th>Trạng thái</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {elmListStaffs}
                    </tbody>
                </table>
            </div>

            <AdminStaffPaging dataValue={AdminStaffReducer.dataValue} />

            <AdminStaffFormAction />

        </div>
    )
}

export default StaffAdmin
