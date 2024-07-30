import React, { useContext, useEffect, useState } from "react";
import "./ManageInstructorPage.css";
import ManageInstructor from "../../../components/Admin/ManageInstructor/ManageInstrutor";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function ManageInstructorPage() {
  const [loading, setLoading] = useState(true);
  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (!roles.includes("Admin")) {
      nav("/login");
    }
  }, [user, roles, nav]);

  useEffect(() => {
    const simulateLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };

    simulateLoading();
  }, []);

  return (
    <div id="ManageInstructorPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="instructor" />
        </div>
        <div className="Layout-container">
          <div className="ManageInstructor-container">
            <ManageInstructor />
          </div>
        </div>
      </div>
    </div>
  );
}
