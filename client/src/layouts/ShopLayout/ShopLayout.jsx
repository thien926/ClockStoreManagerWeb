import React from 'react'
import Footer from '../../components/Shop/Footer/Footer'
import Header from '../../components/Shop/Header/Header'
import Shop from '../../pages/Shop/Shop/Shop'
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
