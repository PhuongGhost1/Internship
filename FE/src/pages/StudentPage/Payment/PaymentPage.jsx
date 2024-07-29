import React, { useContext, useEffect } from "react";
import "./PaymentPage.css";

import Header from "../../../components/Items/Header/Header";
import PaymentDetail from "../../../components/Student/Payment/PaymentDetail/PaymentDetail";
import Footer from "../../../components/Items/Footer/Footer";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function PaymentPage() {
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
    <div id="payment-page">
      <Header />
      <div className="payment-container">
        <PaymentDetail />
      </div>
      <Footer />
    </div>
  );
}
