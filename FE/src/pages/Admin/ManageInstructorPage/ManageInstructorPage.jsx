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
  const [userId, setUserId] = useState(null);
  const { user } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (user) {
      setUserId(user.id);
    } else {
      nav("/login");
    }
  }, [user]);

  useEffect(() => {
    const simulateLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };

    simulateLoading();
  }, []);

  return (
    <>
      {userId ? (
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
      ) : (
        <p>No user</p>
      )}
    </>
  );
}
