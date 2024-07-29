import React, { useContext, useEffect, useState } from "react";
import "./RequestsPage.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Requests from "../../../components/Admin/Requests/Requests";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function RequestsPage() {
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
    <div id="RequestsPage">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="requests" />
        </div>
        <div className="Layout-container">
          <div className="Requests-container">
            <Requests />
          </div>
        </div>
      </div>
    </div>
  );
}
