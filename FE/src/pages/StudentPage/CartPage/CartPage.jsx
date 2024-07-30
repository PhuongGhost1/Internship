import React, { useContext, useEffect, useState } from "react";
import "./CartPage.css";
import Cart from "../../../components/Student/Cart/Cart";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CartPage() {
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (
      !roles.some((role) => ["Instructor", "Student"].includes(role))
    ) {
      nav("/error");
    }
  }, [user, roles, nav]);
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
