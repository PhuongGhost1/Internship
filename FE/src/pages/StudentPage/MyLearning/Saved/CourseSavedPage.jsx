import React, { useContext, useEffect } from "react";
import "./CourseSavedPage.css";

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";
import Saved from "../../../../components/Student/MyLearning/NavBar/Saved/Saved";
import { AuthContext } from "../../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CourseSavedPage() {
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
    <div id="course-saved-page">
      <Header />
      <NavBar type="saved" />
      <Saved user={user} />
      <Footer />
    </div>
  );
}
