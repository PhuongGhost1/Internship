import React, { useContext, useEffect } from "react";
import "./PayoutPage.css";

import Header from "../../../components/Items/Header/Header";
import PayoutDetail from "../../../components/Student/Payout/PayoutDetail/PayoutDetail";
import Footer from "../../../components/Items/Footer/Footer";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../../Context/AuthContext";

export default function PayoutPage() {
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
    <div id="payout-page">
      <Header />
      <div className="payout-container">
        <PayoutDetail user={user} />
      </div>
      <Footer />
    </div>
  );
}
