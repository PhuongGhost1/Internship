import React from "react";
import './CartPage.css';
import Cart from "../../../components/Student/Cart/Cart";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";

export default function CartPage() {
    return (
        <div id="CartPage">
            <div className="cartpage-container">
                <Cart />
            </div>
            <Header />
            <Footer />
        </div>
    );
}