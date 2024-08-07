import React, { useContext, useEffect } from "react";
import "./CertificationPage.css";
import Certification from "../../../components/Student/Certification/Certification";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CertificationPage() {
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
    <div id="CertificationPage">
      <div className="certification-container">
        <Certification />
      </div>
      <Header />
      <Footer />
    </div>
  );
}
