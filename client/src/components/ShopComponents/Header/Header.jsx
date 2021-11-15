import React from 'react'
import { Link } from 'react-router-dom'
import CustomLinkShop from '../CustomLinkShop/CustomLinkShop'
import HeaderControl from '../HeaderControl/HeaderControl'
import './Header.css'

function Header() {



    return (
        <header className="header-section">
            <div className="header-top">
                <div className="container">
                    <div className="ht-left">
                        <div className="mail-service">
                            <i className=" fa fa-envelope" />
                            thienabc926@gmail.com
                        </div>
                        <div className="phone-service">
                            <i className=" fa fa-phone" />
                            036.411.7408
                        </div>
                    </div>
                    <div className="ht-right">
                        <a className="login-panel"><i className="fa fa-user" />Login</a>
                        <div className="top-social">
                            <a href="https://www.facebook.com/thien926"><i className="ti-facebook" /></a>
                            <a ><i className="ti-twitter-alt" /></a>
                            <a ><i className="ti-linkedin" /></a>
                            <a ><i className="ti-pinterest" /></a>
                        </div>
                    </div>
                </div>
            </div>
            <div className="container">
                <div className="inner-header">
                    
                    <HeaderControl />

                </div>
            </div>
            <div className="nav-item">
                <div className="container">
                    {/* <div className="nav-depart">
                        <div className="depart-btn">
                            <i className="ti-menu" />
                            <span>All departments</span>
                            <ul className="depart-hover">
                                <li className="active"><a href="#">Women’s Clothing</a></li>
                                <li><a href="#">Men’s Clothing</a></li>
                                <li><a href="#">Underwear</a></li>
                                <li><a href="#">Kid's Clothing</a></li>
                                <li><a href="#">Brand Fashion</a></li>
                                <li><a href="#">Accessories/Shoes</a></li>
                                <li><a href="#">Luxury Brands</a></li>
                                <li><a href="#">Brand Outdoor Apparel</a></li>
                            </ul>
                        </div>
                    </div> */}
                    <nav className="nav-menu mobile-menu">
                        <ul>
                            <li><a href="./index.html">Home</a></li>
                            <li><a href="./shop.html">Shop</a></li>
                            <li><a href="#">Collection</a>
                                <ul className="dropdown">
                                    <li><a href="#">Men's</a></li>
                                    <li><a href="#">Women's</a></li>
                                    <li><a href="#">Kid's</a></li>
                                </ul>
                            </li>
                            <li><a href="./blog.html">Blog</a></li>
                            <li><a href="./contact.html">Contact</a></li>
                            <li><a href="#">Pages</a>
                                <ul className="dropdown">
                                    <li><a href="./blog-details.html">Blog Details</a></li>
                                    <li><a href="./shopping-cart.html">Shopping Cart</a></li>
                                    <li><a href="./check-out.html">Checkout</a></li>
                                    <li><a href="./faq.html">Faq</a></li>
                                    <li><a href="./register.html">Register</a></li>
                                    <li><a href="./login.html">Login</a></li>
                                </ul>
                            </li>
                            {/* <CustomLinkShop to='/home'>Trang chủ</CustomLinkShop>
                            <CustomLinkShop to='/shop/1'>Đồng hồ nam</CustomLinkShop>
                            <CustomLinkShop to='/shop/2'>Đồng hồ nữ</CustomLinkShop>
                            <CustomLinkShop to='/shop/3'>Đồng hồ để bàn</CustomLinkShop>
                            <CustomLinkShop to='/shop/4'>Đồng hồ treo tường</CustomLinkShop> */}
                        </ul>
                    </nav>
                    <div id="mobile-menu-wrap" />
                </div>
            </div>
        </header>
    )
}

export default Header
