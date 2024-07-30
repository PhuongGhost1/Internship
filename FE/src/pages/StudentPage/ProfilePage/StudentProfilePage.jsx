import React, { useState, useEffect, useContext } from "react";
import "./StudentProfilePage.css";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import PersonalDetail from "../../../components/Student/Profile/PersonalDetail/PersonalDetail";
import CertificationProfile from "../../../components/Student/Profile/CertificationProfile/CertificationProfile";
import Timeline from "../../../components/Student/Profile/Timeline/Timeline";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function StudentProfilePage() {
  const [loading, setLoading] = useState(true);
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

  useEffect(() => {
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 2500);
    };

    timeLoading();
  }, []);

  return (
    <div id="student-profile-page">
      <LoadingOverlay loading={loading} />
      <Header />
      <div className="student-profile-container">
        <div className="personal-detail-container">
          <PersonalDetail />
          <Timeline />
        </div>
        <div className="courses-certification">
          <CertificationProfile user={user} />
        </div>
      </div>
      <Footer />
    </div>
  );
}
