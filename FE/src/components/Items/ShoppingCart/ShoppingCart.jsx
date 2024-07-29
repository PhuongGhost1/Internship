import React from "react";
import './ShoppingCart.css';
import { MdOutlineShoppingCart } from "react-icons/md";

export default function ShoppingCart() {
    const hanldeClick = () => {
        window.location.href = '/student/cart'
    }
    return (
        <div id="shopping-cart">
            <div className="cart-container">
                <div className="count">
                    0
                </div>
                <div className="icon-container" onClick={hanldeClick}>
                    <MdOutlineShoppingCart />
                </div>
            </div>
        </div>
    )
}