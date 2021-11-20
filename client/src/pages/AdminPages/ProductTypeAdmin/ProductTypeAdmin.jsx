import React, { useEffect, useState } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useLocation, useNavigate } from 'react-router'
import AdminProductTypeControl from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypeControl'
import AdminProductTypeFormAction from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypeFormAction'
import AdminProductTypeItem from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypeItem'
import AdminProductTypePaging from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypePaging'
import { actGetProductTypeAdmin } from '../../../redux/actions/AdminProductTypeAction'

function ProductTypeAdmin() {

    // Load Reducer
    const productTypeReducer = useSelector(state => state.AdminProductTypeReducer);

    // State URL
    const [search, setSearch] = useState('');
    const [sort, setSort] = useState('');
    const [pageIndex, setPageIndex] = useState('');

    //State Html
    const [elmListLSP, setElmListLSP] = useState(null);

    const location = useLocation();
    const dispatch = useDispatch();
    const navigate = useNavigate();

    const utf8_from_str = (s) => {
        var temp = decodeURIComponent(s);
        temp = temp.split("+");
        temp = temp.join(" ");
        return temp;
    }

    const str_from_utf8 = (s) => {
        var temp = s.split(" ");
        temp = temp.join("+");
        temp = encodeURIComponent(temp);
        return temp;
    }

    // Load State URL khi URL thay đổi
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
                        setSearch(dauBang[1]);
                        break;
                    default:
                        break;
                }
            }
        }
    }, [location])

    useEffect(() => {
        // console.log("search: ", utf8_from_str(search));
        var data = {
            search : utf8_from_str(search),
            sort : sort,
            pageIndex : pageIndex
        }

        dispatch(actGetProductTypeAdmin(data));
    }, [sort, search, pageIndex, dispatch])

    useEffect(() => {
        // console.log("productTypeReducer: ", productTypeReducer);

        var result = null;
        if(productTypeReducer.listLSP) {
            result = productTypeReducer.listLSP.map((productType, index) => {
                return <AdminProductTypeItem key={index} index={index} productType={productType}/>
            })
        }
        setElmListLSP(result);
    }, [productTypeReducer])

    const changeSearch = (searchValue) => {
        navigate('/admin/product-type?search=' + searchValue + '&sort=' + sort + '&pageIndex=' + pageIndex);
    }

    const changeSort = (sortValue) => {
        navigate('/admin/product-type?search=' + search + '&sort=' + sortValue + '&pageIndex=' + pageIndex);
    }

    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý loại sản phẩm</h3>
                <hr />
            </div>
            
            <AdminProductTypeControl search={search} changeSearch={changeSearch} sort={sort} changeSort={changeSort}/>

            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>Id</th>
                            <th>Tên</th>
                            <th>Mô tả</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {elmListLSP}
                    </tbody>
                </table>
            </div>
            
            <AdminProductTypePaging productTypeReducer={productTypeReducer}/>

            <AdminProductTypeFormAction />

        </div>
    )
}

export default ProductTypeAdmin
