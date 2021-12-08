import React, { useState } from 'react'
import Dropdown from 'react-bootstrap/Dropdown'
import DropdownButton from 'react-bootstrap/DropdownButton';


function AdminImportGoodsControl() {

    const [title, setTitle] = useState('Tất cả')
    const handleSelect = (e) => {
        // console.log(e);
        // setTitle(e)
        switch (e) {
            case "lsp":
                setTitle("Tìm theo loại sản phẩm");
                break;
            case "th":
                setTitle("Tìm theo thương hiệu");
                break;
            case "kd":
                setTitle("Tìm theo kiểu dây");
                break;
            case "km":
                setTitle("Tìm theo kiểu máy");
                break;
            case "name":
                setTitle("Tìm theo tên sản phẩm");
                break;

            default:
                setTitle("Tất cả");
                break;
        }
    }

    return (
        <div className="row">
            {/* <div className="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                <button type="button" className="btn btn-primary">Thêm sản phẩm <i className="fa fa-plus-circle" aria-hidden="true" /></button>
            </div> */}
            <div className="col-xs-9 col-sm-9 col-md-9 col-lg-9">
                <div className="input-group mb-3">
                    <DropdownButton
                        alignRight
                        title={`${title}`}
                        id="dropdown-menu-align-right"
                        onSelect={handleSelect}
                    >
                        <Dropdown.Item eventKey="">Tất cả</Dropdown.Item>
                        <Dropdown.Item eventKey="lsp">Tìm theo loại sản phẩm</Dropdown.Item>
                        <Dropdown.Item eventKey="th">Tìm theo thương hiệu</Dropdown.Item>
                        <Dropdown.Item eventKey="kd">Tìm theo kiểu dây</Dropdown.Item>
                        <Dropdown.Item eventKey="km">Tìm theo kiểu máy</Dropdown.Item>
                        <Dropdown.Item eventKey="name">Tìm theo tên sản phẩm</Dropdown.Item>
                        {/* <Dropdown.Divider />
                        <Dropdown.Item eventKey="some link">some link</Dropdown.Item> */}
                    </DropdownButton>
                    <input type="text" className="form-control" aria-label="Text input with dropdown button" />
                </div>

            </div>
            <div className="col-xs-3 col-sm-3 col-md-3 col-lg-3">
                <select id="input" className="form-control" required="required" >
                    <option value="name-asc">Sắp xếp theo tên : A-Z</option>
                    <option value="name-desc">Sắp xếp theo tên : Z-A</option>
                    <option value="price-asc">Sắp xếp theo giá : Tăng dần</option>
                    <option value="price-desc">Sắp xếp theo giá : Giảm dần</option>
                    <option value="id-asc">Sắp xếp theo Id : Tăng dần</option>
                    <option value="id-desc">Sắp xếp theo Id : Giảm dần</option>
                    <option value="status-asc">Sắp xếp theo trạng thái : Ẩn-Kích hoạt</option>
                    <option value="status-desc">Sắp xếp theo trạng thái : Kích hoạt-Ẩn</option>
                </select>
            </div>
        </div>
    )
}

export default AdminImportGoodsControl
