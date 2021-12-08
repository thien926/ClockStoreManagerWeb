import React from 'react'
import AdminImportGoodsControl from '../../../components/AdminComponents/AdminImportGoodsComponent/AdminImportGoodsControl'

function ImportGoodsAdmin() {
    return (
        <div>
            <div>
                <h3 className="text-center mt-2">Nhập hàng</h3>
                <hr />
            </div>
            <AdminImportGoodsControl />
            <div className="row mt-3">
                <table className="table table-hover ">
                    <thead>
                        <tr>
                            <th>STT</th>
                            <th>ID</th>
                            <th>Loại sản phẩm</th>
                            <th>Thương hiệu</th>
                            <th>Kiểu dây</th>
                            <th>Kiểu máy</th>
                            <th>Tên</th>
                            <th>Hình ảnh</th>
                            <th>Hành động</th>
                        </tr>
                    </thead>
                    <tbody>
                        {/* {elmsListSP} */}
                    </tbody>
                </table>
            </div>

            <div className='class-phan-trang'>
                {/* {previous}
                {elmsPhanTrang}
                {next} */}
            </div>

            <div className="row mt-3 ml-3 mr-3">
                {/* <AdminProductFormActionAdd submitActionAddForm={submitActionAddForm} /> */}
                {/* {showForm()} */}
            </div>

        </div>
    )
}

export default ImportGoodsAdmin
