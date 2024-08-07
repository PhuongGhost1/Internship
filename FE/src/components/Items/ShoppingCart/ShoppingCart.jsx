import React, { useContext, useEffect, useState } from "react";
import "./ShoppingCart.css";
import { MdOutlineShoppingCart } from "react-icons/md";
import { AuthContext } from "../../../pages/Context/AuthContext";
import ApiService from "../../../api/ApiService";

export default function ShoppingCart() {
  const { user } = useContext(AuthContext);
  const [numberInCart, setNumberInCart] = useState(null);

  useEffect(() => {
    const fetchNumberInCart = async () => {
      if (user && user.id) {
        try {
          const response = await ApiService.GetNumberInCart(user.id);
          setNumberInCart(response);
        } catch (error) {
          console.error("Error fetching number in cart:", error);
        }
      }
    };

    fetchNumberInCart();
  }, [user]);

  const handleClick = () => {
    window.location.href = "/student/cart";
  };

  return (
    <div id="shopping-cart">
      <div className="cart-container">
        <div className="count">{numberInCart !== null ? numberInCart : 0}</div>
        <div className="icon-container" onClick={handleClick}>
          <MdOutlineShoppingCart />
        </div>
      </div>
    </div>
  );
}
