import React from 'react'
import { Link } from 'react-router-dom'
import AdminProductTypeControl from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypeControl'
import AdminProductTypeFormAction from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypeFormAction'
import AdminProductTypeItem from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypeItem'
import AdminProductTypePaging from '../../../components/AdminComponents/AdminProductTypeComponent/AdminProductTypePaging'

function ProductTypeAdmin() {
    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Quản lý loại sản phẩm</h3>
                <hr />
            </div>
            
            <AdminProductTypeControl />

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
                        <AdminProductTypeItem />
                        <AdminProductTypeItem />
                        <AdminProductTypeItem />
                        <AdminProductTypeItem />
                        <AdminProductTypeItem />
                        <AdminProductTypeItem />
                    </tbody>
                </table>
            </div>
            
            <AdminProductTypePaging />

            <AdminProductTypeFormAction />

        </div>
    )
}

export default ProductTypeAdmin
