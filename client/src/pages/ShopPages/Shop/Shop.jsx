import React from "react";
import { useLocation } from "react-router-dom";
import Category from "../../../components/ShopComponents/ShopPageComponent/Category";
import ProductItem from "../../../components/ShopComponents/ShopPageComponent/ProductItem";
import ResultSearch from "../../../components/ShopComponents/ShopPageComponent/ResultSearch";
import ShopPaging from "../../../components/ShopComponents/ShopPageComponent/ShopPaging";
import Sort from "../../../components/ShopComponents/ShopPageComponent/Sort";

function Shop(props) {
  // let match = useMatch();

  console.log("Param: ", useLocation());

  return (
    <div>
      <div className="breacrumb-section">
        <div className="container">
          <div className="row">
            <div className="col-lg-12">
              <div className="breadcrumb-text">
                <a href="#"><i className="fa fa-home" /> Trang chủ</a>
                <span>Cửa hàng</span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <section className="product-shop spad">
        <div className="container">
          <div className="row">

            <Category />

            <div className="col-lg-9 order-1 order-lg-2">
              <div className="product-show-option">
                <div className="row">

                  <ResultSearch />
                  
                </div>

                <Sort />

              </div>
              <div className="product-list">
                <div className="row">
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                  <ProductItem />
                </div>
              </div>
              
              <ShopPaging />

            </div>
          </div>
        </div>
      </section>
    </div>

  );
}

export default Shop;
