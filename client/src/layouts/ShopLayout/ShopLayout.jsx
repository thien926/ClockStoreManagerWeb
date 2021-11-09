import React from 'react'
import Footer from '../../components/ShopComponents/Footer/Footer'
import Header from '../../components/ShopComponents/Header/Header'
import Shop from '../../pages/ShopPages/Shop/Shop'
import './ShopLayout.css'

function ShopLayout() {
    return (
        <div>
            {/* <div id="preloder">
                <div className="loader" />
            </div> */}

            <Header />

            <Shop />

            <Footer />
        </div>
    )
}

export default ShopLayout
