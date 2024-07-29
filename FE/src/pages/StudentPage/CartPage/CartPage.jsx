import React, { useContext, useEffect, useState } from "react";
import "./CartPage.css";
import Cart from "../../../components/Student/Cart/Cart";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CartPage() {
  const { user } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (user) {
      console.log(user);
    } else {
      nav("/login");
    }
  }, []);
  return (
    <div id="CartPage">
      <div className="cartpage-container">
        <Cart user={user} />
      </div>
      <Header />
      <Footer />
    </div>
  );
}
