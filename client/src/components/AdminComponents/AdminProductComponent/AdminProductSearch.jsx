import React, { useState } from 'react'

function AdminProductSearch(props) {

    const [search, setSearch] = useState('');

    const changeSearch = () => {
        // console.log(search);
        props.changeSearch(search);
    }

    return (
        <div className="input-group">
            <input type="text" className="form-control" id="exampleInputAmount" placeholder="Tìm theo tên" onChange={(e) => setSearch(e.target.value)}/>
            <span className="input-group-btn">
                <button type="button" className="btn btn-info ml-2" onClick={changeSearch}>Tìm kiếm</button>
            </span>
        </div>
    )
}

export default AdminProductSearch
