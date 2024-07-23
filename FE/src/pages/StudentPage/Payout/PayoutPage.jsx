import React from "react";
import "./PayoutPage.css";

import Header from "../../../components/Items/Header/Header";
import PayoutDetail from "../../../components/Student/Payout/PayoutDetail/PayoutDetail";
import Footer from "../../../components/Items/Footer/Footer";
import { useLocation } from "react-router-dom";

export default function PayoutPage() {
  const location = useLocation();
  console.log("Location state:", location.state);
  const { total, courseName } = location.state || {};

  return (
    <div id="payout-page">
      <Header />
      <div className="payout-container">
        <PayoutDetail total={total} courseName={courseName} />
      </div>
      <Footer />
    </div>
  );
}
