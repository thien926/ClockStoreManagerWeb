import React from 'react'

function SortComponent() {
    return (
        <div className="row">
            <div className="col-lg-7 col-md-7">

                <div className="select-option">
                    <select className="sorting">
                        <option value>Default Sorting</option>
                    </select>
                    <select className="p-show">
                        <option value>Show:</option>
                    </select>
                </div>
            </div>
            <div className="col-lg-5 col-md-5 text-right">
                <p>Show 01- 09 Of 36 Product</p>
            </div>

        </div>
    )
}

export default SortComponent
