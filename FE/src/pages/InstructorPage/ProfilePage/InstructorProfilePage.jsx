import React, { useContext, useEffect, useState } from "react";
import "./InstructorProfilePage.css";

import Header from "../../../components/Items/Header/Header";
import Footer from "../../../components/Items/Footer/Footer";
import PersonalDetail from "../../../components/Student/Profile/PersonalDetail/PersonalDetail";
import CertificationProfile from "../../../components/Student/Profile/CertificationProfile/CertificationProfile";
import Timeline from "../../../components/Student/Profile/Timeline/Timeline";
import CreatedCourse from "../../../components/Instructor/Profile/CreatedCourse/CreatedCourse";
import CreatingCourse from "../../../components/Instructor/Profile/CreatingCourse/CreatingCourse";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function InstructorProfilePage() {
  const [pageShow, setPageShow] = useState("process");
  const { user } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (user) {
      console.log(user);
    } else {
      nav("/login");
    }
  }, []);

  useEffect(() => {
    try {
      let process1 = document.querySelector(".activeSB");
      process1.classList.remove("activeSB");
    } catch (error) {}
    if (pageShow === "process") {
      let process2 = document.querySelector(".process");
      process2.classList.add("activeSB");
    } else if (pageShow === "management") {
      let process2 = document.querySelector(".management");
      process2.classList.add("activeSB");
    }
  }, [pageShow]);

  const handleProcessClick = () => {
    setPageShow("process");
  };

  const handleManagementClick = () => {
    setPageShow("management");
  };

  return (
    <div id="instructor-profile-page">
      <Header />
      <div className="instructor-profile-container">
        <div className="personal-detail-container">
          <PersonalDetail />
          <Timeline />
        </div>
        <div className="courses-certification">
          <div className="switch-bar">
            <div className="process bar" onClick={handleProcessClick}>
              Process
            </div>
            <div className="management bar" onClick={handleManagementClick}>
              Management
            </div>
          </div>
          {pageShow === "process" && (
            <React.Fragment>
              <CertificationProfile user={user} />
            </React.Fragment>
          )}
          {pageShow === "management" && (
            <React.Fragment>
              <CreatedCourse user={user} />
              <CreatingCourse user={user} />
            </React.Fragment>
          )}
        </div>
      </div>
      <Footer />
    </div>
  );
}
