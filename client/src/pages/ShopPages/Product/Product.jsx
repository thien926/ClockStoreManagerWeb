import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link, useNavigate, useLocation } from "react-router-dom";
import ProductConnexion from "../../../components/ShopComponents/ProductPageComponent/ProductConnexion";
import ProductDetail from "../../../components/ShopComponents/ProductPageComponent/ProductDetail";
import { actGetProductPage } from "../../../redux/actions/ProductPageAction";

function Product() {

  const ProductPageReducer = useSelector(state => state.ProductPageReducer);

  const [elmProductDetail, setElmProductDetail] = useState(null);
  const [elemListConnexion, setElemListConnexion] = useState(null)

  const navigate = useNavigate();
  const location = useLocation();
  const dispatch = useDispatch();

  useEffect(() => {
    var id = parseInt(location.pathname.replace("/product/", ""));
    if (!id) {
      navigate('/notfound');
    }

    dispatch(actGetProductPage(id));
  }, [dispatch, location, navigate])

  useEffect(() => {
    if (ProductPageReducer.product) {
      setElmProductDetail(<ProductDetail product={ProductPageReducer.product} />)
    }
    else {
      setElmProductDetail(null);
    }

    var result = null;
    if (ProductPageReducer.listRelationship) {
      result = ProductPageReducer.listRelationship.map((product, index) => {
        return <ProductConnexion key={index} product={product} />
      })
    }
    setElemListConnexion(result);
  }, [ProductPageReducer])

  return (
    <div>
      <div className="breacrumb-section">
        <div className="container">
          <div className="row">
            <div className="col-lg-12">
              <div className="breadcrumb-text product-more">
                <Link to="/home">
                  <i className="fa fa-home" /> Trang chủ
                </Link>
                <span>Chi tiết sản phẩm</span>
              </div>
            </div>
          </div>
        </div>
      </div>

      {elmProductDetail}

      {/* ListProduct Connexion */}
      <div className="related-products spad">
        <div className="container">
          <div className="row">
            <div className="col-lg-12">
              <div className="section-title">
                <h2>Sản phẩm liên quan</h2>
              </div>
            </div>
          </div>
          <div className="row">
            {elemListConnexion}
          </div>
        </div>
      </div>
    </div>
  );
}

export default Product;
