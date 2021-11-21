import React from 'react'

function ProductItem() {
    return (
        <div className="col-lg-4 col-sm-6">
            <div className="product-item">
                <div className="pi-pic">
                    <img src="/img/products/product-1.jpg" />
                    <div className="sale pp-sale">Sale</div>
                    <div className="icon">
                        <i className="icon_heart_alt" />
                    </div>
                    <ul>
                        <li className="w-icon active"><a href="#"><i className="icon_bag_alt" /></a></li>
                        <li className="quick-view"><a href="#">+ Quick View</a></li>
                        <li className="w-icon"><a href="#"><i className="fa fa-random" /></a></li>
                    </ul>
                </div>
                <div className="pi-text">
                    <div className="catagory-name">Towel</div>
                    <a href="#">
                        <h5>Pure Pineapple</h5>
                    </a>
                    <div className="product-price">
                        $14.00
                        <span>$35.00</span>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ProductItem
