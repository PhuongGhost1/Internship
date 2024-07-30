import React, { useState, useEffect, useContext } from "react";
import "./DashBoard.css";
import Header from "../../../components/Admin/Header/Header";
import SideBar from "../../../components/Admin/SideBar/SideBar";
import Weekly from "../../../components/Admin/Weekly/Weekly";
import Statistics from "../../../components/Admin/Statistics/Statistics";
import Analytics from "../../../components/Admin/Analytics/Analytics";
import LoadingOverlay from "../../../components/LoadingOverlay";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function DashBoard() {
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
    <div id="DashBoard">
      <LoadingOverlay loading={loading} />
      <div className="Header-Admin">
        <Header user={user} />
      </div>
      <div className="Layout">
        <div className="SideBar-container">
          <SideBar type="dashboard" />
        </div>
        <div className="Layout-container">
          <div className="Weekly-container">
            <Weekly />
          </div>

          <div className="Sta-Chart">
            <div className="Statistics">
              <Statistics />
            </div>
            <div className="Chart">
              <div className="">
                <Analytics />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
