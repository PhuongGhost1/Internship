import React, { useContext, useEffect } from "react";
import "./PayoutPage.css";

import Header from "../../../components/Items/Header/Header";
import PayoutDetail from "../../../components/Student/Payout/PayoutDetail/PayoutDetail";
import Footer from "../../../components/Items/Footer/Footer";
import { useLocation, useNavigate } from "react-router-dom";
import { AuthContext } from "../../Context/AuthContext";

export default function PayoutPage() {
  const location = useLocation();
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (
      !roles.some((role) => ["Instructor", "Student"].includes(role))
    ) {
      nav("/login");
    }
  }, [user, roles, nav]);
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
