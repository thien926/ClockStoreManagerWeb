import React from 'react'
import { Link } from 'react-router-dom'

function HeaderControl() {
    return (
        <div className="row">
            <div className="col-lg-2 col-md-2">
                <div className="logo">
                    <Link to='/'>
                        <img src="/img/logo.png" />
                    </Link>
                </div>
            </div>
            <div className="col-lg-7 col-md-7">
                <div className="advanced-search">
                    <form action="#" className="input-group form-search-shop">
                        <input type="text" className="input-search-shop" placeholder="Tên sản phẩm" />
                        <button type="button"><i className="ti-search" /></button>
                    </form>
                </div>
            </div>
            <div className="col-lg-3 text-right col-md-3">
                <ul className="nav-right">
                    <li className="cart-icon"><a href="#">
                        <i className="icon_bag_alt" />
                        <span>3</span>
                    </a>
                        <div className="cart-hover">
                            <div className="select-items">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td className="si-pic"><img src="/img/select-product-1.jpg" alt /></td>
                                            <td className="si-text">
                                                <div className="product-selected">
                                                    <p>$60.00 x 1</p>
                                                    <h6>Kabino Bedside Table</h6>
                                                </div>
                                            </td>
                                            <td className="si-close">
                                                <i className="ti-close" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td className="si-pic"><img src="/img/select-product-2.jpg" alt /></td>
                                            <td className="si-text">
                                                <div className="product-selected">
                                                    <p>$60.00 x 1</p>
                                                    <h6>Kabino Bedside Table</h6>
                                                </div>
                                            </td>
                                            <td className="si-close">
                                                <i className="ti-close" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div className="select-total">
                                <span>total:</span>
                                <h5>$120.00</h5>
                            </div>
                            <div className="select-button">
                                <a href="#" className="primary-btn view-card">VIEW CARD</a>
                                <a href="#" className="primary-btn checkout-btn">CHECK OUT</a>
                            </div>
                        </div>
                    </li>
                    <li className="cart-price">$150.00</li>
                </ul>
            </div>
        </div>
    )
}

export default HeaderControl
