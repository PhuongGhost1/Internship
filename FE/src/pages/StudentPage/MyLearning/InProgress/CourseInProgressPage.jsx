import React, { useContext, useEffect } from "react";
import "./CourseInProgressPage.css";

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";
import InProgess from "../../../../components/Student/MyLearning/NavBar/InProgress/InProgress";
import { AuthContext } from "../../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CourseInProgressPage() {
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
  return (
    <div id="course-in-progress-page">
      <Header />
      <NavBar type="in-progress" />
      <InProgess user={user} />
      <Footer />
    </div>
  );
}
