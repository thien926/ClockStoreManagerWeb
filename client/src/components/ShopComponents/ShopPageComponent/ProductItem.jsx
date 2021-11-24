import React from 'react'
import { API_URL_IMG } from '../../../constants/Config';

function ProductItem(props) {
    const { product } = props;
    console.log(product);
    return (
        <div className="col-lg-4 col-sm-6">
            <div className="product-item">
                <div className="pi-pic">
                    <img src={`${API_URL_IMG}${product.img}`} />
                    <ul>
                        <li className="w-icon active"><a href="#"><i className="icon_bag_alt" /></a></li>
                        <li className="quick-view"><a href="#">Xem chi tiết</a></li>
                    </ul>
                </div>
                <div className="pi-text">
                    {/* <div className="catagory-name">{product.name}</div> */}
                    <a href="#">
                        <h5>{product.name}</h5>
                    </a>
                    <div className="product-price">
                        {product.price} đ
                        <br />
                        {/* <span>$35.00</span> */}
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ProductItem
