import React, { useCallback, useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useLocation, useNavigate } from 'react-router';
import { toast } from 'react-toastify';
import { ADD_NCC_ERROR, ADD_NCC_SUCCESS, DELETE_NCC_ERROR, DELETE_NCC_SUCCESS, UPDATE_NCC_ERROR, UPDATE_NCC_SUCCESS } from '../../../constants/Message';
import AdminNCCItem from '../../../components/AdminComponents/AdminNCCComponent/AdminNCCItem'
import AdminNCCFormAction from '../../../components/AdminComponents/AdminNCCComponent/AdminNCCFormAction'
import AdminNCCControl from '../../../components/AdminComponents/AdminNCCComponent/AdminNCCControl'
import AdminNCCPaging from '../../../components/AdminComponents/AdminNCCComponent/AdminNCCPaging'
import { actAddNCCAdmin, actDeleteNCCAdmin, actGetNCCAdmin, actResetMessageNCCAdmin, actUpdateNCCAdmin } from '../../../redux/actions/AdminNCCAction'

function NCCAdmin() {
    const AdminNCCReducer = useSelector(state => state.AdminNCCReducer)

    const [search, setSearch] = useState('');
    const [sort, setSort] = useState('name-asc');
    const [pageIndex, setPageIndex] = useState(1);
    const [elmListNCCs, setElmListNCCs] = useState(null);

    const [actionValue, setActionValue] = useState('');
    const [formValue, setFormValue] = useState({id: null, name: ''});

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
        dispatch(actGetNCCAdmin(data));
    }, [search, sort, pageIndex, dispatch])

    useEffect(() => {
        // console.log(AdminNCCReducer.dataValue)
        var result = null;
        if(AdminNCCReducer.dataValue.listNCC && AdminNCCReducer.dataValue.listNCC.length > 0) {
            result = AdminNCCReducer.dataValue.listNCC.map((item, index) => {
                return <AdminNCCItem key={index} ncc={item} index={index} actionUpdate={actionUpdate} actionDelete={actionDelete}/>
            })
        }
        setElmListNCCs(result);
    }, [AdminNCCReducer.dataValue])

    // Hiên thông báo các sự kiện
    useEffect(() => {
        switch (AdminNCCReducer.message) {
            case ADD_NCC_SUCCESS:
            case DELETE_NCC_SUCCESS:
            case UPDATE_NCC_SUCCESS:
                toast.success(AdminNCCReducer.message);
                var filter = {
                    search : search,
                    sort: sort,
                    pageIndex:pageIndex
                }
                // console.log(filter);
                dispatch(actGetNCCAdmin(filter));
                dispatch(actResetMessageNCCAdmin());
                break;
            case ADD_NCC_ERROR : 
            case DELETE_NCC_ERROR:
            case UPDATE_NCC_ERROR :
                toast.error(AdminNCCReducer.message); 
                dispatch(actResetMessageNCCAdmin());
                break;
            default:
                break;
        }
    }, [AdminNCCReducer.message])

    // đi đến URL khác khi search
    const changeSearch = (searchValue) => {
        navigate('/admin/ncc?search=' + searchValue + '&sort=' + sort + '&pageIndex=' + pageIndex);
    }

    // đi đến URL khác khi sort
    const changeSort = (sortValue) => {
        navigate('/admin/ncc?search=' + search + '&sort=' + sortValue + '&pageIndex=' + pageIndex);
    }

    const showForm = useCallback(
        () => {
            switch (actionValue) {
                case 'add':
                case 'update':
                    return <AdminNCCFormAction formValue={formValue} setActionValue={setActionValue} submitActionForm={submitActionForm}/>
            
                default:
                    return null;
            }
        },
        [actionValue, formValue],
    )

    const actionAdd = () => {
        setFormValue({id: null, name:'', address:'', phone: '', fax:''});
        setActionValue("add");
    }

    const actionUpdate = (data) => {
        setFormValue(data);
        setActionValue("update");
    }

    const submitActionForm = (data, action) => {
        switch (action) {
            case 'add':
                dispatch(actAddNCCAdmin(data));
                setActionValue('');
                break;
            case 'update':
                dispatch(actUpdateNCCAdmin(data, data.id))
                setActionValue('');
                break;
            default:
                break;
        }
    }

    // Thực hiện thao tác xóa
    const actionDelete = (id) => {
        var res = window.confirm("Bạn có chắc muốn xóa nhà cung cấp có Id = " + id + " không?");
        if(res) {
            dispatch(actDeleteNCCAdmin(id));
        }
        else {
            toast.error(DELETE_NCC_ERROR);
        }
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý nhà cung cấp</h3>
                <hr />
            </div>
            
            <AdminNCCControl search={search} sort={sort} changeSearch={changeSearch} changeSort={changeSort} actionAdd={actionAdd}/>

            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>Id</th>
                            <th>Tên</th>
                            <th>Địa chỉ</th>
                            <th>Số điện thoại</th>
                            <th>Fax</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* <AdminNCCItem /> */}
                        {elmListNCCs}
                    </tbody>
                </table>
            </div>

            <AdminNCCPaging dataValue={AdminNCCReducer.dataValue}/>

            {showForm()}

        </div>
    )
}

export default NCCAdmin
