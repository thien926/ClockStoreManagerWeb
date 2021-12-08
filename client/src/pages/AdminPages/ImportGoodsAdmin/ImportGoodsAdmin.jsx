import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux';
import { useLocation, useNavigate } from 'react-router';
import AdminImportGoodChoose from '../../../components/AdminComponents/AdminImportGoodsComponent/AdminImportGoodChoose';
import AdminImportGoodsControl from '../../../components/AdminComponents/AdminImportGoodsComponent/AdminImportGoodsControl'
import AdminImportGoodsPaging from '../../../components/AdminComponents/AdminImportGoodsComponent/AdminImportGoodsPaging';
import AdminImportProductLoadItem from '../../../components/AdminComponents/AdminImportGoodsComponent/AdminImportProductLoadItem';
import { actGetImportGoodsLoadAdmin } from '../../../redux/actions/AdminImportGoodsAction';
import './ImportGoodsAdmin.css'

function ImportGoodsAdmin() {

    const AdminImportGoodsReducer = useSelector(state => state.AdminImportGoodsReducer)

    const [search, setSearch] = useState('');
    const [typeSearch, setTypeSearch] = useState('');
    const [pageIndex, setPageIndex] = useState(1);

    const [elmProductLoad, setElmProductLoad] = useState(null);

    const location = useLocation();
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const utf8_from_str = (s) => {
        var temp = decodeURIComponent(s);
        temp = temp.split("+");
        temp = temp.join(" ");
        return temp;
    }

    // Load typeSearch, search, pageIndex
    useEffect(() => {
        // console.log("location: ", location);
        var { search } = location;
        if(search === "") {
            setTypeSearch('');
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
                    case "typeSearch":
                        setTypeSearch(dauBang[1]);
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
            typeSearch,
            search,
            pageIndex
        }
        dispatch(actGetImportGoodsLoadAdmin(data));
    }, [search, typeSearch, pageIndex, dispatch])

    useEffect(() => {
        // console.log()
        var result = null;
        if(AdminImportGoodsReducer.dataLoad.listSP && AdminImportGoodsReducer.dataLoad.listSP.length > 0) {
            result = AdminImportGoodsReducer.dataLoad.listSP.map((item, index) => {
                return <AdminImportProductLoadItem key={index} item={item} index={index} />
            })
        }
        setElmProductLoad(result);
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [AdminImportGoodsReducer.dataLoad])

    // đi đến URL khác khi search
    const changeSearch = (searchValue, typeSearchValue) => {
        navigate('/admin/import-goods?search=' + searchValue + '&typeSearch=' + typeSearchValue + '&pageIndex=' + 1);
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Nhập hàng</h3>
                <hr />
            </div>
            <AdminImportGoodsControl search={search} typeSearch={typeSearch} changeSearch={changeSearch}/>
            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>ID</th>
                            <th>Tên</th>
                            <th>Loại sản phẩm</th>
                            <th>Thương hiệu</th>
                            <th>Kiểu dây</th>
                            <th>Kiểu máy</th>
                            
                            <th>Hình ảnh</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {elmProductLoad}
                    </tbody>
                </table>
            </div>

            <AdminImportGoodsPaging dataLoad={AdminImportGoodsReducer.dataLoad} />

            <AdminImportGoodChoose />

        </div>
    )
}

export default ImportGoodsAdmin
