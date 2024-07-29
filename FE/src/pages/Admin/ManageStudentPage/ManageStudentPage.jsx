import React, { useContext, useEffect, useState } from "react";
import "./ManageStudentPage.css";
import Header from "../../../components/Admin/Header/Header";
import ManageStudent from "../../../components/Admin/ManageStudent/ManageStudent";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function ManageStudentPage() {
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
    const timeLoading = () => {
      setTimeout(() => {
        setLoading(false);
      }, 3000);
    };
    timeLoading();
  }, []);

  return (
    <>
      {userId ? (
        <div id="ManageStudentPage">
          <LoadingOverlay loading={loading} />
          <div className="Header-Admin">
            <Header />
          </div>
          <div className="Layout">
            <div className="SideBar-container">
              <SideBar type="student" />
            </div>
            <div className="Layout-container">
              <div className="ManageStudent-container">
                <ManageStudent />
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
