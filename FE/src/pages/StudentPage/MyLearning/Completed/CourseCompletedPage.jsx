import React, { useContext, useEffect } from "react";
import "./CourseCompletedPage.css";

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";
import Completed from "../../../../components/Student/MyLearning/NavBar/Completed/Completed";
import { AuthContext } from "../../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CourseCompletedPage() {
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
    <div id="course-completed-page">
      <Header />
      <NavBar type="completed" />
      <Completed user={user} />
      <Footer />
    </div>
  );
}
