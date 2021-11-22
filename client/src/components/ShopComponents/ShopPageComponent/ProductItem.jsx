import React from 'react'

function ProductItem() {
    return (
        <div className="col-lg-4 col-sm-6">
            <div className="product-item">
                <div className="pi-pic">
                    <img src="/img/products/product-1.jpg" />
                    <ul>
                        <li className="w-icon active"><a href="#"><i className="icon_bag_alt" /></a></li>
                        <li className="quick-view"><a href="#">Xem chi tiết</a></li>
                    </ul>
                </div>
                <div className="pi-text">
                    <div className="catagory-name">Towel</div>
                    <a href="#">
                        <h5>Pure Pineapple</h5>
                    </a>
                    <div className="product-price">
                        $14.00
                        <br />
                        <span>$35.00</span>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ProductItem
