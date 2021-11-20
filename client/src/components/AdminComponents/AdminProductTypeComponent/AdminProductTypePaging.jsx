import React from 'react'
import { Link } from 'react-router-dom'

function AdminProductTypePaging() {
    return (
        <div className='class-phan-trang'>
            <Link className='btn btn-default' to='1'><i className="fa fa-angle-double-left" aria-hidden="true" /></Link>
            <Link className='btn btn-default' to='1'><i className="fa fa-angle-left" aria-hidden="true" /></Link>

            <Link className='btn btn-info' to='1'>1</Link>
            <Link className='btn btn-default' to='2'>2</Link>

            <Link className='btn btn-default' to='1'><i className="fa fa-angle-right" aria-hidden="true" /></Link>
            <Link className='btn btn-default' to='1'><i className="fa fa-angle-double-right" aria-hidden="true" /></Link>

        </div>
    )
}

export default AdminProductTypePaging
