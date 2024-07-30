import React, { useContext, useEffect } from "react";
import "./FollowingPage.css";

import Header from "../../../../components/Items/Header/Header";
import Footer from "../../../../components/Items/Footer/Footer";
import NavBar from "../../../../components/Student/MyLearning/NavBar/NavBar";
import Followed from "../../../../components/Student/MyLearning/NavBar/Followed/Followed";
import { AuthContext } from "../../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function FollowingPage() {
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
    <div id="following-page">
      <Header />
      <NavBar type="following" />
      <Followed user={user} />
      <Footer />
    </div>
  );
}
