import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useLocation, useNavigate } from 'react-router'
import AdminCustomControl from '../../../components/AdminComponents/AdminCustomComponent/AdminCustomControl'
import AdminCustomFormInfoAction from '../../../components/AdminComponents/AdminCustomComponent/AdminCustomFormInfoAction'
import AdminCustomItem from '../../../components/AdminComponents/AdminCustomComponent/AdminCustomItem'
import AdminCustomPaging from '../../../components/AdminComponents/AdminCustomComponent/AdminCustomPaging'
import { actGetCustomAdmin } from '../../../redux/actions/AdminCustomAction'

function CustomAdmin() {

    const AdminCustomReducer = useSelector(state => state.AdminCustomReducer)

    const [search, setSearch] = useState('');
    const [sort, setSort] = useState('name-asc');
    const [pageIndex, setPageIndex] = useState(1);
    const [elmListCustoms, setElmListCustoms] = useState(null);

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
        dispatch(actGetCustomAdmin(data));
    }, [search, sort, pageIndex, dispatch])

    useEffect(() => {
        console.log(AdminCustomReducer.dataValue)
        var result = null;
        if(AdminCustomReducer.dataValue.listKH && AdminCustomReducer.dataValue.listKH.length > 0) {
            result = AdminCustomReducer.dataValue.listKH.map((item, index) => {
                return <AdminCustomItem key={index} custom={item} index={index} />
            })
        }
        setElmListCustoms(result);
    }, [AdminCustomReducer.dataValue])

    // đi đến URL khác khi search
    const changeSearch = (searchValue) => {
        navigate('/admin/custom?search=' + searchValue + '&sort=' + sort + '&pageIndex=' + pageIndex);
    }

    // đi đến URL khác khi sort
    const changeSort = (sortValue) => {
        navigate('/admin/custom?search=' + search + '&sort=' + sortValue + '&pageIndex=' + pageIndex);
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý khách hàng</h3>
                <hr />
            </div>
            
            <AdminCustomControl search={search} sort={sort} changeSearch={changeSearch} changeSort={changeSort}/>

            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>Tài khoản</th>
                            <th>Tên</th>
                            <th>Số điện thoại</th>
                            <th>Mail</th>
                            <th>Địa chỉ</th>
                            <th>Giới tính</th>
                            <th>Ngày sinh</th>
                            <th>Trạng thái</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {elmListCustoms}
                    </tbody>
                </table>
            </div>

            <AdminCustomPaging dataValue={AdminCustomReducer.dataValue} />

            <AdminCustomFormInfoAction />

        </div>
    )
}

export default CustomAdmin
