import React, { useContext, useEffect } from "react";
import "./PaymentPage.css";

import Header from "../../../components/Items/Header/Header";
import PaymentDetail from "../../../components/Student/Payment/PaymentDetail/PaymentDetail";
import Footer from "../../../components/Items/Footer/Footer";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function PaymentPage() {
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
    <div id="payment-page">
      <Header />
      <div className="payment-container">
        <PaymentDetail />
      </div>
      <Footer />
    </div>
  );
}
