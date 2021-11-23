import React from 'react'

function Category() {
    return (
        <div className="col-lg-3 col-md-6 col-sm-8 order-2 order-lg-1 produts-sidebar-filter">
            <div className="filter-widget">
                <h4 className="fw-title">Thương hiệu</h4>
                <ul className="filter-catagories category-scroll">
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                </ul>
            </div>
            <div className="filter-widget">
                <h4 className="fw-title">Kiểu máy</h4>
                <ul className="filter-catagories category-scroll">
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    
                </ul>
            </div>
            <div className="filter-widget">
                <h4 className="fw-title">Kiểu dây</h4>
                <ul className="filter-catagories category-scroll">
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    <li><a href="#">Women</a></li>
                    <li><a href="#">Kids</a></li>
                    <li><a href="#">Men</a></li>
                    
                </ul>
            </div>
            <div className="filter-widget">
                <h4 className="fw-title">Giá</h4>
                <div className="filter-range-wrap">
                    <div className="range-slider">
                        <div className="price-input">
                            <input type="text" id="minamount" />
                            <input type="text" id="maxamount" />
                        </div>
                    </div>
                </div>
                <a href="#" className="filter-btn">Filter</a>
            </div>
            
        </div>
    )
}

export default Category
