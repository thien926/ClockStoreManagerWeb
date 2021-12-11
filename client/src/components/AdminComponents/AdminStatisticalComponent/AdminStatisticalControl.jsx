import React, { useEffect, useState } from 'react'

function AdminStatisticalControl(props) {

    const [search, setSearch] = useState(props.search);

    useEffect(() => {
        setSearch(props.search);
    }, [props.search])

    const onSubmit = (e) => {
        e.preventDefault();
        props.changeSearch(search);
    }

    return (
        <div className="row">
            <div className="col-xs-4 col-sm-4 col-md-4 col-lg-4">
                <select className="form-control" required="required" >
                    <option value={0}>Thống kê doanh thu theo năm</option>
                    <option value={1}>Thống kê doanh thu theo tháng</option>
                    <option value={2}>Thống kê đơn hàng theo năm</option>
                    <option value={3}>Thống kê đơn hàng theo tháng</option>
                    <option value={4}>Thống kê sản phẩm bán ra</option>
                </select>
            </div>

            <div className="col-xs-7 col-sm-7 col-md-7 col-lg-7">
                <form onSubmit={onSubmit} className="form-horizontal">
                    <div className="input-group">
                        <input type="text" className="form-control" id="exampleInputAmount" placeholder="Tìm kiếm theo nhân viên, khách hàng, địa chỉ đơn hàng" value={search} onChange={(e) => setSearch(e.target.value)} />
                        <span className="input-group-btn">
                            <button type="submit" className="btn btn-info ml-2" >Tìm kiếm</button>
                        </span>
                    </div>
                </form>
            </div>
            <div className="col-xs-1 col-sm-1 col-md-1 col-lg-1">
                
                <button type="button" className="btn btn-primary">Lọc</button>
                
            </div>
            
        </div>
    )
}

export default AdminStatisticalControl
